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
            this.favoritesWinsList = new System.Windows.Forms.ListBox();
            this.addWinTxt = new System.Windows.Forms.TextBox();
            this.filterListPathLbl = new System.Windows.Forms.Label();
            this.workSetPathLbl = new System.Windows.Forms.Label();
            this.workSetPathBrowserBtn = new ArrangeWindows.WindowButton();
            this.filterListPathBrowserBtn = new ArrangeWindows.WindowButton();
            this.programsBrowserBtn = new ArrangeWindows.WindowButton();
            this.addWinNameBtn = new ArrangeWindows.WindowButton();
            ((System.ComponentModel.ISupportInitialize)(this.workSetPathBrowserBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterListPathBrowserBtn)).BeginInit();
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
            this.favoritesWinsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.filterListMouseUp);
            // 
            // addWinTxt
            // 
            this.addWinTxt.Location = new System.Drawing.Point(230, 24);
            this.addWinTxt.Name = "addWinTxt";
            this.addWinTxt.Size = new System.Drawing.Size(273, 38);
            this.addWinTxt.TabIndex = 9;
            // 
            // filterListPathLbl
            // 
            this.filterListPathLbl.AutoSize = true;
            this.filterListPathLbl.Location = new System.Drawing.Point(749, 38);
            this.filterListPathLbl.Name = "filterListPathLbl";
            this.filterListPathLbl.Size = new System.Drawing.Size(93, 32);
            this.filterListPathLbl.TabIndex = 16;
            this.filterListPathLbl.Text = "label1";
            // 
            // workSetPathLbl
            // 
            this.workSetPathLbl.AutoSize = true;
            this.workSetPathLbl.Location = new System.Drawing.Point(755, 143);
            this.workSetPathLbl.Name = "workSetPathLbl";
            this.workSetPathLbl.Size = new System.Drawing.Size(93, 32);
            this.workSetPathLbl.TabIndex = 18;
            this.workSetPathLbl.Text = "label1";
            // 
            // workSetPathBrowserBtn
            // 
            this.workSetPathBrowserBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.browserOff,
        global::ArrangeWindows.Resource1.browserOn};
            this.workSetPathBrowserBtn.Image = global::ArrangeWindows.Resource1.browserOff;
            this.workSetPathBrowserBtn.Location = new System.Drawing.Point(538, 129);
            this.workSetPathBrowserBtn.Name = "workSetPathBrowserBtn";
            this.workSetPathBrowserBtn.Size = new System.Drawing.Size(200, 50);
            this.workSetPathBrowserBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.workSetPathBrowserBtn.TabIndex = 19;
            this.workSetPathBrowserBtn.TabStop = false;
            this.workSetPathBrowserBtn.Type = ArrangeWindows.WindowButtonType.Add;
            this.workSetPathBrowserBtn.Click += new System.EventHandler(this.workSetPathBrowserBtn_Click);
            // 
            // filterListPathBrowserBtn
            // 
            this.filterListPathBrowserBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.browserOff,
        global::ArrangeWindows.Resource1.browserOn};
            this.filterListPathBrowserBtn.Image = global::ArrangeWindows.Resource1.browserOff;
            this.filterListPathBrowserBtn.Location = new System.Drawing.Point(538, 28);
            this.filterListPathBrowserBtn.Name = "filterListPathBrowserBtn";
            this.filterListPathBrowserBtn.Size = new System.Drawing.Size(200, 50);
            this.filterListPathBrowserBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.filterListPathBrowserBtn.TabIndex = 17;
            this.filterListPathBrowserBtn.TabStop = false;
            this.filterListPathBrowserBtn.Type = ArrangeWindows.WindowButtonType.Add;
            this.filterListPathBrowserBtn.Click += new System.EventHandler(this.filterListBrowserBtn_Click);
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
            this.ClientSize = new System.Drawing.Size(1451, 333);
            this.Controls.Add(this.workSetPathBrowserBtn);
            this.Controls.Add(this.workSetPathLbl);
            this.Controls.Add(this.filterListPathBrowserBtn);
            this.Controls.Add(this.filterListPathLbl);
            this.Controls.Add(this.programsBrowserBtn);
            this.Controls.Add(this.addWinNameBtn);
            this.Controls.Add(this.favoritesWinsList);
            this.Controls.Add(this.addWinTxt);
            this.Name = "settingsForm";
            this.Text = "settingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.workSetPathBrowserBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterListPathBrowserBtn)).EndInit();
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
        private WindowButton filterListPathBrowserBtn;
        private System.Windows.Forms.Label filterListPathLbl;
        private WindowButton workSetPathBrowserBtn;
        private System.Windows.Forms.Label workSetPathLbl;
    }
}