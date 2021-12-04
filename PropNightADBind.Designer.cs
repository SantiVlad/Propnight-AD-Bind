
namespace PropNightADBind
{
    partial class PropNightADBind
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropNightADBind));
            this.lblBind = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.lblInterval = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbDelay = new System.Windows.Forms.CheckBox();
            this.txtBind = new ReadOnlyTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBind
            // 
            this.lblBind.AutoSize = true;
            this.lblBind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBind.Location = new System.Drawing.Point(12, 128);
            this.lblBind.Name = "lblBind";
            this.lblBind.Size = new System.Drawing.Size(111, 29);
            this.lblBind.TabIndex = 0;
            this.lblBind.Text = "Bind key:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(124, 92);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(198, 20);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "_____________________";
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInfo.BackgroundImage")));
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInfo.Location = new System.Drawing.Point(536, 92);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(65, 65);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.TabStop = false;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInterval.Location = new System.Drawing.Point(18, 12);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(312, 29);
            this.lblInterval.TabIndex = 5;
            this.lblInterval.Text = "Click Interval (milliseconds):";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(328, 12);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(146, 26);
            this.txtInterval.TabIndex = 6;
            this.txtInterval.TabStop = false;
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(536, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 65);
            this.btnSave.TabIndex = 7;
            this.btnSave.TabStop = false;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbDelay
            // 
            this.cbDelay.AutoSize = true;
            this.cbDelay.Location = new System.Drawing.Point(328, 53);
            this.cbDelay.Name = "cbDelay";
            this.cbDelay.Size = new System.Drawing.Size(194, 24);
            this.cbDelay.TabIndex = 8;
            this.cbDelay.Text = "Enable Random Delay";
            this.cbDelay.UseVisualStyleBackColor = true;
            // 
            // txtBind
            // 
            this.txtBind.BackColor = System.Drawing.Color.White;
            this.txtBind.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtBind.Location = new System.Drawing.Point(128, 128);
            this.txtBind.Name = "txtBind";
            this.txtBind.ReadOnly = true;
            this.txtBind.Size = new System.Drawing.Size(346, 26);
            this.txtBind.TabIndex = 2;
            this.txtBind.TabStop = false;
            this.txtBind.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(13, 168);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "                ";
            // 
            // PropNightADBind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 197);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbDelay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtBind);
            this.Controls.Add(this.lblBind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PropNightADBind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD Bind for Propnight. By LeeSiCzin.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBind;
        private ReadOnlyTextBox txtBind;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbDelay;
        private System.Windows.Forms.Label lblStatus;
    }
}

