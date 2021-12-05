using Gma.UserActivityMonitor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropNightADBind
{
    public partial class PropNightADBind : Form
    {
        public static readonly Random random = new();

        public const Keys DEFAULT_BIND_KEY = Keys.D9;
        public const int DEFAULT_SLEEP_INTERVAL = 20;

        public static byte keyA = 0x41, keyD = 0x44;
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

        public PropNightADBind()
        {
            InitializeComponent();

            HookManager.KeyDown += HookManager_KeyDown;
            txtBind.DoubleClick += textBox_DoubleClick;
            timer.Tick += timer_Tick;

            txtBind.Text = Properties.Settings.Default.LastBindedKey.ToString();
            txtInterval.Text = Properties.Settings.Default.Interval.ToString();

            new ToolTip().SetToolTip(btnSave, "Save Interval");
            new ToolTip().SetToolTip(btnInfo, "About");
            new ToolTip().SetToolTip(cbDelay, "Adds random delay between clicks");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var timer = (System.Windows.Forms.Timer)sender;
            BindHelper.StopTimer(timer);
            BindHelper.ShowStatusOnLabel(lblStatus, "", Color.Black);
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

                lblInfo.Text = "DoubleClick on TextBox to change the bind key.";
                BindHelper.ShowStatusOnLabel(lblStatus, "Key succesfully accepted.", Color.Green);
                BindHelper.StartTimer(timer);
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
            MessageBox.Show($"This program is an auto-clicker for the game \"Propnight\".\nWhen you press the binded key ({Properties.Settings.Default.LastBindedKey}), the program will start " +
                $"clicking <A> and <D> keys once in {Properties.Settings.Default.Interval} milliseconds.\nThis can help you to set free from killer's hands.", "Clicker info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Interval = int.TryParse(txtInterval.Text, out int interval) ? interval : DEFAULT_SLEEP_INTERVAL;
            Properties.Settings.Default.Save();
            txtInterval.Text = Properties.Settings.Default.Interval.ToString();

            BindHelper.ShowStatusOnLabel(lblStatus, "Interval succesfully saved.", Color.Green);
            BindHelper.StartTimer(timer);
        }

        private void AddDelay(int milliseconds)
        {
            if (cbDelay.Checked)
                Thread.Sleep(milliseconds + random.Next(0, 3));
            else
                Thread.Sleep(milliseconds);
        }

        private async void StartBind()
        {
            await Task.Run(() =>
            {
                while (isEnabled)
                {
                    this.Invoke(new Action(() =>
                    {
                        BindHelper.PressKeyDown(keyA);
                        //Thread.Sleep(1);
                        BindHelper.PressKeyUp(keyA);

                        //Delay between clicks
                        AddDelay(Properties.Settings.Default.Interval);

                        BindHelper.PressKeyDown(keyD);
                        //Thread.Sleep(1);
                        BindHelper.PressKeyUp(keyD);

                        //Delay between clicks
                        AddDelay(Properties.Settings.Default.Interval);
                    }));
                }
            });     
        }
    }
}