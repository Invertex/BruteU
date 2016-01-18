namespace BruteU
{
    partial class bruteWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bruteWindow));
            this.keyInput = new System.Windows.Forms.TextBox();
            this.hashInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.byteLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.startBrute = new System.Windows.Forms.Button();
            this.save2bin = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fastMode = new System.Windows.Forms.CheckBox();
            this.labelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.byteLength)).BeginInit();
            this.SuspendLayout();
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(12, 33);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(249, 20);
            this.keyInput.TabIndex = 0;
            // 
            // hashInput
            // 
            this.hashInput.Location = new System.Drawing.Point(12, 81);
            this.hashInput.MaxLength = 40;
            this.hashInput.Name = "hashInput";
            this.hashInput.Size = new System.Drawing.Size(249, 20);
            this.hashInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key to brute force:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SHA-1 hash to compare to:";
            // 
            // byteLength
            // 
            this.byteLength.Location = new System.Drawing.Point(368, 33);
            this.byteLength.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.byteLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.byteLength.Name = "byteLength";
            this.byteLength.ReadOnly = true;
            this.byteLength.Size = new System.Drawing.Size(33, 20);
            this.byteLength.TabIndex = 4;
            this.byteLength.TabStop = false;
            this.byteLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.byteLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Unknown values:";
            // 
            // labelKey
            // 
            this.labelKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKey.Location = new System.Drawing.Point(93, 139);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(308, 24);
            this.labelKey.TabIndex = 7;
            this.labelKey.Text = "Not running";
            // 
            // startBrute
            // 
            this.startBrute.Location = new System.Drawing.Point(12, 107);
            this.startBrute.Name = "startBrute";
            this.startBrute.Size = new System.Drawing.Size(75, 23);
            this.startBrute.TabIndex = 8;
            this.startBrute.Text = "Start";
            this.startBrute.UseVisualStyleBackColor = true;
            this.startBrute.Click += new System.EventHandler(this.startBrute_Click);
            // 
            // save2bin
            // 
            this.save2bin.Enabled = false;
            this.save2bin.Location = new System.Drawing.Point(12, 136);
            this.save2bin.Name = "save2bin";
            this.save2bin.Size = new System.Drawing.Size(75, 23);
            this.save2bin.TabIndex = 9;
            this.save2bin.Text = "Save to .bin";
            this.save2bin.UseVisualStyleBackColor = true;
            this.save2bin.Click += new System.EventHandler(this.save2bin_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // fastMode
            // 
            this.fastMode.AutoSize = true;
            this.fastMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastMode.Location = new System.Drawing.Point(329, 11);
            this.fastMode.Name = "fastMode";
            this.fastMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fastMode.Size = new System.Drawing.Size(72, 16);
            this.fastMode.TabIndex = 11;
            this.fastMode.Text = ":Fast Mode";
            this.fastMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fastMode.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(93, 110);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(308, 24);
            this.labelInfo.TabIndex = 12;
            // 
            // bruteWindow
            // 
            this.AccessibleDescription = "Disabled the visual feedback of generated keys.";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 170);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.fastMode);
            this.Controls.Add(this.save2bin);
            this.Controls.Add(this.startBrute);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.byteLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hashInput);
            this.Controls.Add(this.keyInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "bruteWindow";
            this.Text = "BruteU - WiiU key brute forcer by Kakkoii";
            ((System.ComponentModel.ISupportInitialize)(this.byteLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keyInput;
        private System.Windows.Forms.TextBox hashInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown byteLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startBrute;
        private System.Windows.Forms.Button save2bin;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.CheckBox fastMode;
        private System.Windows.Forms.Label labelInfo;
    }
}

