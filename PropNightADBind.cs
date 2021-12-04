using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.UserActivityMonitor;

namespace PropNightADBind
{
    public partial class PropNightADBind : Form
    {
        public static readonly Random random = new();

        public const Keys DEFAULT_BIND_KEY = Keys.D9;
        public const int DEFAULT_SLEEP_INTERVAL = 20;

        public static bool isEnabled = false, isInEditMode = false;

        public static List<Keys> AllowedKeys = new()
        {
            Keys.B,        
            Keys.C,               
            Keys.E,        
            Keys.F,        
            Keys.G,        
            Keys.H,        
            Keys.I,        
            Keys.J,        
            Keys.K,        
            Keys.L,        
            Keys.M,        
            Keys.N,        
            Keys.O,
            Keys.P,
            Keys.Q,
            Keys.R,
            Keys.T,
            Keys.U,
            Keys.X,      
            Keys.Y,
            Keys.D0,
            Keys.D1,
            Keys.D2,
            Keys.D3,
            Keys.D4,
            Keys.D5,
            Keys.D6,
            Keys.D7,
            Keys.D8,
            Keys.D9,
            Keys.NumPad0,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
            Keys.Add,
            Keys.Subtract,
            Keys.Multiply,
            Keys.Divide
        };

        private static System.Windows.Forms.Timer timer = new() { Interval = 1000, Enabled = false };

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan,
            uint dwFlags, UIntPtr dwExtraInfo);

        public PropNightADBind()
        {
            InitializeComponent();

            HookManager.KeyDown += HookManager_KeyDown;
            txtBind.DoubleClick += textBox_DoubleClick;
            timer.Tick += timer_Tick;

            lblInfo.Text = "DoubleClick on TextBox for changing the bind key.";
            txtBind.Text = Properties.Settings.Default.LastBindedKey.ToString();
            txtInterval.Text = Properties.Settings.Default.Interval.ToString();

            new ToolTip().SetToolTip(btnSave, "Save Interval");
            new ToolTip().SetToolTip(btnInfo, "About");
            new ToolTip().SetToolTip(cbDelay, "Adds random delay between clicks");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var timer = (System.Windows.Forms.Timer)sender;
            timer.Stop(); timer.Enabled = false;
            this.ShowStatus("", Color.Black);
        }

        private void textBox_DoubleClick(object sender, EventArgs e)
        {
            txtBind.ReadOnly = false;
            txtBind.Cursor = Cursors.IBeam;

            isInEditMode = true;
            lblInfo.Text = "Press the bind key:";
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            if(isInEditMode)
            {
                isInEditMode = false;
                Properties.Settings.Default.LastBindedKey = AllowedKeys.Contains(e.KeyCode) ? e.KeyCode : DEFAULT_BIND_KEY;
                Properties.Settings.Default.Save();

                txtBind.Text = Properties.Settings.Default.LastBindedKey.ToString();
                txtBind.ReadOnly = true;
                txtBind.Cursor = Cursors.Arrow;

                lblInfo.Text = "DoubleClick on TextBox for changing the bind key.";
                this.ShowStatus("Key succesfully accepted.", Color.Green);
            }
            else
            {
                if (e.KeyCode == Properties.Settings.Default.LastBindedKey)
                {
                    isEnabled = !isEnabled;

                    if(isEnabled)
                        StartBind();
                }
            }
            GC.Collect();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"This program is an auto-clicker for the game \"Propnight\".\nWhen you press the binded key, the program will start " +
                $"clicking <A> and <D> keys once in 10 milliseconds.\nThis can help you to set free from killer's hands.", "Clicker info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Interval = int.TryParse(txtInterval.Text, out int interval) ? interval : DEFAULT_SLEEP_INTERVAL;
            Properties.Settings.Default.Save();
            txtInterval.Text = Properties.Settings.Default.Interval.ToString();
            this.ShowStatus("Interval succesfully saved.", Color.Green);
        }

        private void ShowStatus(string Text, Color color)
        {
            lblStatus.Text = Text;
            lblStatus.ForeColor = color;
            if (!timer.Enabled) { timer.Start(); timer.Enabled = true; }
        }

        private async void StartBind()
        {
            await Task.Run(() =>
            {
                while (isEnabled)
                {
                    this.Invoke(new Action(() =>
                    {
                        keybd_event(0x41, 0x02, 0, UIntPtr.Zero);
                        //Thread.Sleep(1);
                        keybd_event(0x41, 0x82, 0x2, UIntPtr.Zero);

                        if(cbDelay.Checked)
                            Thread.Sleep(Properties.Settings.Default.Interval + random.Next(0, 3));
                        else
                            Thread.Sleep(Properties.Settings.Default.Interval);

                        keybd_event(0x44, 0x02, 0, UIntPtr.Zero);
                        //Thread.Sleep(1);
                        keybd_event(0x44, 0x82, 0x2, UIntPtr.Zero);

                        if (cbDelay.Checked)
                            Thread.Sleep(Properties.Settings.Default.Interval + random.Next(0, 3));
                        else
                            Thread.Sleep(Properties.Settings.Default.Interval);
                    }));
                }
            });     
        }
    }
}