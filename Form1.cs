using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinEventHook
{
    public partial class WinEventHook : Form
    {
        internal delegate void WinEventProc(IntPtr hWinEventHook, int iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetWinEventHook(int eventMin, int eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, int idProcess,
            int idThread, SetWinEventHookFlags dwflags);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        private WinEventProc listener = null;
        private IntPtr hWinEventHook = IntPtr.Zero;
        private int lastEventTime = 0;

        const int EVENT_SYSTEM_FOREGROUND = 0x0003;
        const int EVENT_SYSTEM_CONTEXTHELPEND = 0x000D;

        internal enum SetWinEventHookFlags
        {
            WINEVENT_OUTOFCONTEXT = 0,
            WINEVENT_SKIPOWNPROCESS = 2
        }

        public WinEventHook()
        {
            InitializeComponent();
        }

        private void EventCallback(IntPtr hWinEventHook, int iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            string event_string = event_to_str(iEvent);
            if(event_string != null)
            {
                if (lastEventTime == 0)
                {
                    txt_log.Text = txt_log.Text + Environment.NewLine + event_string + " at " + dwmsEventTime;
                }
                else
                {
                    txt_log.Text = txt_log.Text + Environment.NewLine + event_string + " +" + (dwmsEventTime - lastEventTime) + "ms.";
                }
            }
            lastEventTime = dwmsEventTime;
        }

        private void btc_action_Click(object sender, EventArgs e)
        {
            if(hWinEventHook == IntPtr.Zero)
            {
                if(listener == null)
                {
                    listener = new WinEventProc(EventCallback);
                }

                List<Process> processes_find = findProcessesByName(txt_process_name.Text);
                if(processes_find.Count != 1)
                {
                    MessageBox.Show("Processes found: " + processes_find.Count);
                    return;
                }

                hWinEventHook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_CONTEXTHELPEND, IntPtr.Zero, listener, 
                    processes_find[0].Id, 0,SetWinEventHookFlags.WINEVENT_OUTOFCONTEXT | SetWinEventHookFlags.WINEVENT_SKIPOWNPROCESS);
                txt_log.Text = "";
                btn_action.Text = "Stop";
            }
            else
            {
                UnhookWinEvent(hWinEventHook);
                hWinEventHook = IntPtr.Zero;
                btn_action.Text = "Start";
            }
        }

        private void txt_process_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_log_TextChanged(object sender, EventArgs e)
        {

        }

        static string event_to_str(int event_id)
        {
            if (event_id != 0x0009 && event_id != 0x0003)
            {
                return null;
            }
            switch (event_id)
            {
                case 0x0003:
                    return "SYS_FOREGROUND";
                case 0x0004:
                    return "SYS_MENUSTART";
                case 0x0006:
                    return "SYS_MENUPOPUPSTART";
                case 0x0007:
                    return "SYS_MENUPOPUPEND";
                case 0x0008:
                    return "SYS_CAPTURESTART";
                case 0x0009:
                    return "SYS_CAPTUREEND";
                case 0x000a:
                    return "SYS_MOVESIZESTART";
                case 0x000b:
                    return "SYS_MOVESIZEEND";
                case 0x0016:
                    return "SYS_MINIMIZESTART";
                default:
                    return "" + event_id;
            }

        }

        private void Win_Main_Dispose(object sender, EventArgs e)
        {
            if(hWinEventHook != IntPtr.Zero)
            {
                UnhookWinEvent(hWinEventHook);
                hWinEventHook = IntPtr.Zero;
            }
        }

        private void Win_Main_Load(object sender, EventArgs e)
        {

        }

        private List<Process> findProcessesByName(string name)
        {
            if (name.EndsWith(".exe"))
            {
                name = name.Substring(0, name.Length - 4);
            }
            List<Process> processes_find = new List<Process>();
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.ProcessName.Equals(name))
                {
                    processes_find.Add(p);
                }
            }
            return processes_find;
        }
    }
}
