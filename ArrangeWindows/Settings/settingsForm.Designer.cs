namespace ArrangeWindows.Settings
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.favoritesWinsList = new System.Windows.Forms.ListBox();
            this.addWinTxt = new System.Windows.Forms.TextBox();
            this.favoritesListPathLbl = new System.Windows.Forms.Label();
            this.workSetsPathLbl = new System.Windows.Forms.Label();
            this.workSetPathBrowserBtn = new ArrangeWindows.WindowButton();
            this.favoritesListPathBrowserBtn = new ArrangeWindows.WindowButton();
            this.programsBrowserBtn = new ArrangeWindows.WindowButton();
            this.addWinNameBtn = new ArrangeWindows.WindowButton();
            ((System.ComponentModel.ISupportInitialize)(this.workSetPathBrowserBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.favoritesListPathBrowserBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programsBrowserBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addWinNameBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // favoritesWinsList
            // 
            this.favoritesWinsList.FormattingEnabled = true;
            this.favoritesWinsList.ItemHeight = 31;
            this.favoritesWinsList.Location = new System.Drawing.Point(230, 88);
            this.favoritesWinsList.Name = "favoritesWinsList";
            this.favoritesWinsList.Size = new System.Drawing.Size(273, 221);
            this.favoritesWinsList.TabIndex = 10;
            this.favoritesWinsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.favoritesListMouseUp);
            // 
            // addWinTxt
            // 
            this.addWinTxt.Location = new System.Drawing.Point(230, 24);
            this.addWinTxt.Name = "addWinTxt";
            this.addWinTxt.Size = new System.Drawing.Size(273, 38);
            this.addWinTxt.TabIndex = 9;
            // 
            // favoritesListPathLbl
            // 
            this.favoritesListPathLbl.AutoSize = true;
            this.favoritesListPathLbl.Location = new System.Drawing.Point(527, 24);
            this.favoritesListPathLbl.Name = "favoritesListPathLbl";
            this.favoritesListPathLbl.Size = new System.Drawing.Size(93, 32);
            this.favoritesListPathLbl.TabIndex = 16;
            this.favoritesListPathLbl.Text = "label1";
            // 
            // workSetPathLbl
            // 
            this.workSetsPathLbl.AutoSize = true;
            this.workSetsPathLbl.Location = new System.Drawing.Point(527, 134);
            this.workSetsPathLbl.Name = "workSetPathLbl";
            this.workSetsPathLbl.Size = new System.Drawing.Size(93, 32);
            this.workSetsPathLbl.TabIndex = 18;
            this.workSetsPathLbl.Text = "label1";
            // 
            // workSetPathBrowserBtn
            // 
            this.workSetPathBrowserBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.browserOff,
        global::ArrangeWindows.Resource1.browserOn};
            this.workSetPathBrowserBtn.Image = global::ArrangeWindows.Resource1.browserOff;
            this.workSetPathBrowserBtn.Location = new System.Drawing.Point(533, 169);
            this.workSetPathBrowserBtn.Name = "workSetPathBrowserBtn";
            this.workSetPathBrowserBtn.Size = new System.Drawing.Size(200, 50);
            this.workSetPathBrowserBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.workSetPathBrowserBtn.TabIndex = 19;
            this.workSetPathBrowserBtn.TabStop = false;
            this.workSetPathBrowserBtn.Type = ArrangeWindows.WindowButtonType.Add;
            this.workSetPathBrowserBtn.Click += new System.EventHandler(this.workSetsPathBrowserBtn_Click);
            // 
            // favoritesListPathBrowserBtn
            // 
            this.favoritesListPathBrowserBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.browserOff,
        global::ArrangeWindows.Resource1.browserOn};
            this.favoritesListPathBrowserBtn.Image = global::ArrangeWindows.Resource1.browserOff;
            this.favoritesListPathBrowserBtn.Location = new System.Drawing.Point(533, 65);
            this.favoritesListPathBrowserBtn.Name = "favoritesListPathBrowserBtn";
            this.favoritesListPathBrowserBtn.Size = new System.Drawing.Size(200, 50);
            this.favoritesListPathBrowserBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.favoritesListPathBrowserBtn.TabIndex = 17;
            this.favoritesListPathBrowserBtn.TabStop = false;
            this.favoritesListPathBrowserBtn.Type = ArrangeWindows.WindowButtonType.Add;
            this.favoritesListPathBrowserBtn.Click += new System.EventHandler(this.favoritesListBrowserBtn_Click);
            // 
            // programsBrowserBtn
            // 
            this.programsBrowserBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.browserOff,
        global::ArrangeWindows.Resource1.browserOn};
            this.programsBrowserBtn.Image = global::ArrangeWindows.Resource1.browserOff;
            this.programsBrowserBtn.Location = new System.Drawing.Point(15, 97);
            this.programsBrowserBtn.Name = "programsBrowserBtn";
            this.programsBrowserBtn.Size = new System.Drawing.Size(200, 50);
            this.programsBrowserBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.programsBrowserBtn.TabIndex = 15;
            this.programsBrowserBtn.TabStop = false;
            this.programsBrowserBtn.Type = ArrangeWindows.WindowButtonType.Add;
            this.programsBrowserBtn.Click += new System.EventHandler(this.browserBtn_Click);
            // 
            // addWinNameBtn
            // 
            this.addWinNameBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.addBtnOff,
        global::ArrangeWindows.Resource1.addBtnOn};
            this.addWinNameBtn.Image = global::ArrangeWindows.Resource1.addBtnOff;
            this.addWinNameBtn.Location = new System.Drawing.Point(15, 28);
            this.addWinNameBtn.Name = "addWinNameBtn";
            this.addWinNameBtn.Size = new System.Drawing.Size(200, 50);
            this.addWinNameBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addWinNameBtn.TabIndex = 14;
            this.addWinNameBtn.TabStop = false;
            this.addWinNameBtn.Type = ArrangeWindows.WindowButtonType.Add;
            this.addWinNameBtn.Click += new System.EventHandler(this.addWinNameBtn_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 333);
            this.Controls.Add(this.workSetPathBrowserBtn);
            this.Controls.Add(this.workSetsPathLbl);
            this.Controls.Add(this.favoritesListPathBrowserBtn);
            this.Controls.Add(this.favoritesListPathLbl);
            this.Controls.Add(this.programsBrowserBtn);
            this.Controls.Add(this.addWinNameBtn);
            this.Controls.Add(this.favoritesWinsList);
            this.Controls.Add(this.addWinTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsForm";
            this.Text = "settingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.workSetPathBrowserBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.favoritesListPathBrowserBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programsBrowserBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addWinNameBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox favoritesWinsList;
        private System.Windows.Forms.TextBox addWinTxt;
        private WindowButton addWinNameBtn;
        private WindowButton programsBrowserBtn;
        private WindowButton favoritesListPathBrowserBtn;
        private System.Windows.Forms.Label favoritesListPathLbl;
        private WindowButton workSetPathBrowserBtn;
        private System.Windows.Forms.Label workSetsPathLbl;
    }
}