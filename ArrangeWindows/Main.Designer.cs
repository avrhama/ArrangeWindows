namespace ArrangeWindows
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.winsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.showAllCheck = new System.Windows.Forms.CheckBox();
            this.scrnCtrlsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.settingsBtn = new ArrangeWindows.WindowButton();
            this.saveBtn = new ArrangeWindows.WindowButton();
            this.loadBtn = new ArrangeWindows.WindowButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // winsLayout
            // 
            this.winsLayout.AutoScroll = true;
            this.winsLayout.Location = new System.Drawing.Point(1262, 12);
            this.winsLayout.Name = "winsLayout";
            this.winsLayout.Size = new System.Drawing.Size(543, 836);
            this.winsLayout.TabIndex = 7;
            // 
            // showAllCheck
            // 
            this.showAllCheck.AutoSize = true;
            this.showAllCheck.Location = new System.Drawing.Point(1262, 855);
            this.showAllCheck.Name = "showAllCheck";
            this.showAllCheck.Size = new System.Drawing.Size(156, 36);
            this.showAllCheck.TabIndex = 9;
            this.showAllCheck.Text = "show all";
            this.showAllCheck.UseVisualStyleBackColor = true;
            this.showAllCheck.CheckedChanged += new System.EventHandler(this.showAllCheck_CheckedChanged);
            // 
            // scrnCtrlsLayout
            // 
            this.scrnCtrlsLayout.AutoScroll = true;
            this.scrnCtrlsLayout.Location = new System.Drawing.Point(12, 12);
            this.scrnCtrlsLayout.Name = "scrnCtrlsLayout";
            this.scrnCtrlsLayout.Size = new System.Drawing.Size(1216, 837);
            this.scrnCtrlsLayout.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.loadBtn);
            this.groupBox1.Location = new System.Drawing.Point(1885, 527);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WorkingSets";
            // 
            // settingsBtn
            // 
            this.settingsBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.settingsOff,
        ((System.Drawing.Bitmap)(resources.GetObject("settingsBtn.BtnImages")))};
            this.settingsBtn.Image = global::ArrangeWindows.Resource1.settingsOff;
            this.settingsBtn.Location = new System.Drawing.Point(1891, 683);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(207, 50);
            this.settingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsBtn.TabIndex = 15;
            this.settingsBtn.TabStop = false;
            this.settingsBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // saveBtn
            // 
            this.saveBtn.BtnImages = new System.Drawing.Bitmap[] {
        ((System.Drawing.Bitmap)(resources.GetObject("saveBtn.BtnImages"))),
        ((System.Drawing.Bitmap)(resources.GetObject("saveBtn.BtnImages1")))};
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.Location = new System.Drawing.Point(222, 37);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 50);
            this.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saveBtn.TabIndex = 15;
            this.saveBtn.TabStop = false;
            this.saveBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // loadBtn
            // 
            this.loadBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.LoadOff,
        global::ArrangeWindows.Resource1.LoadOn};
            this.loadBtn.Image = global::ArrangeWindows.Resource1.LoadOff;
            this.loadBtn.Location = new System.Drawing.Point(6, 37);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(200, 50);
            this.loadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadBtn.TabIndex = 16;
            this.loadBtn.TabStop = false;
            this.loadBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2363, 984);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scrnCtrlsLayout);
            this.Controls.Add(this.showAllCheck);
            this.Controls.Add(this.winsLayout);
            this.Name = "Main";
            this.Text = "Arrange Windows";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel winsLayout;
        private System.Windows.Forms.CheckBox showAllCheck;
        private System.Windows.Forms.FlowLayoutPanel scrnCtrlsLayout;
        private System.Windows.Forms.GroupBox groupBox1;
        private WindowButton saveBtn;
        private WindowButton loadBtn;
        private WindowButton settingsBtn;
    }
}

