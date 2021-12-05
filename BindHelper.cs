using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PropNightADBind
{
    static class BindHelper
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan,
            uint dwFlags, UIntPtr dwExtraInfo);

        public static void ShowStatusOnLabel(Label label, string text, Color color)
        {
            label.Text = text;
            label.ForeColor = color;
        }

        public static void StartTimer(Timer timer)
        {
            if (!timer.Enabled) { timer.Enabled = true; timer.Start(); }
        }

        public static void StopTimer(Timer timer)
        {
            if (timer.Enabled) { timer.Stop(); timer.Enabled = false; }
        }

        public static void PressKeyDown(byte KeyValue)
        {
            keybd_event(KeyValue, 0x02, 0, UIntPtr.Zero);
        }

        public static void PressKeyUp(byte KeyValue)
        {
            keybd_event(KeyValue, 0x82, 0x2, UIntPtr.Zero);
        }
    }
}