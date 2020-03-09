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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.addWinTxt = new System.Windows.Forms.TextBox();
            this.favoritesWinsList = new System.Windows.Forms.ListBox();
            this.addWinNameBtn = new System.Windows.Forms.Button();
            this.winsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.updateWinsBtn = new System.Windows.Forms.Button();
            this.showAllCheck = new System.Windows.Forms.CheckBox();
            this.scrnCtrlsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveBtn = new ArrangeWindows.WindowButton();
            this.loadBtn = new ArrangeWindows.WindowButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(1885, 433);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(444, 283);
            this.listBox1.TabIndex = 1;
            // 
            // addWinTxt
            // 
            this.addWinTxt.Location = new System.Drawing.Point(1885, 12);
            this.addWinTxt.Name = "addWinTxt";
            this.addWinTxt.Size = new System.Drawing.Size(273, 38);
            this.addWinTxt.TabIndex = 4;
            // 
            // favoritesWinsList
            // 
            this.favoritesWinsList.FormattingEnabled = true;
            this.favoritesWinsList.ItemHeight = 31;
            this.favoritesWinsList.Location = new System.Drawing.Point(1885, 85);
            this.favoritesWinsList.Name = "favoritesWinsList";
            this.favoritesWinsList.Size = new System.Drawing.Size(273, 221);
            this.favoritesWinsList.TabIndex = 5;
            this.favoritesWinsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.filterListMouseUp);
            // 
            // addWinNameBtn
            // 
            this.addWinNameBtn.Location = new System.Drawing.Point(2176, 12);
            this.addWinNameBtn.Name = "addWinNameBtn";
            this.addWinNameBtn.Size = new System.Drawing.Size(100, 51);
            this.addWinNameBtn.TabIndex = 6;
            this.addWinNameBtn.Text = "add";
            this.addWinNameBtn.UseVisualStyleBackColor = true;
            this.addWinNameBtn.Click += new System.EventHandler(this.addWinNameBtn_Click);
            // 
            // winsLayout
            // 
            this.winsLayout.AutoScroll = true;
            this.winsLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winsLayout.Location = new System.Drawing.Point(1262, 12);
            this.winsLayout.Name = "winsLayout";
            this.winsLayout.Size = new System.Drawing.Size(543, 836);
            this.winsLayout.TabIndex = 7;
            // 
            // updateWinsBtn
            // 
            this.updateWinsBtn.Location = new System.Drawing.Point(1885, 344);
            this.updateWinsBtn.Name = "updateWinsBtn";
            this.updateWinsBtn.Size = new System.Drawing.Size(146, 58);
            this.updateWinsBtn.TabIndex = 8;
            this.updateWinsBtn.Text = "update";
            this.updateWinsBtn.UseVisualStyleBackColor = true;
            this.updateWinsBtn.Click += new System.EventHandler(this.updateWinsBtn_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(1894, 868);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WorkingSets";
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scrnCtrlsLayout);
            this.Controls.Add(this.showAllCheck);
            this.Controls.Add(this.updateWinsBtn);
            this.Controls.Add(this.winsLayout);
            this.Controls.Add(this.addWinNameBtn);
            this.Controls.Add(this.favoritesWinsList);
            this.Controls.Add(this.addWinTxt);
            this.Controls.Add(this.listBox1);
            this.Name = "Main";
            this.Text = "Arrange Windows";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox addWinTxt;
        private System.Windows.Forms.ListBox favoritesWinsList;
        private System.Windows.Forms.Button addWinNameBtn;
        private System.Windows.Forms.FlowLayoutPanel winsLayout;
        private System.Windows.Forms.Button updateWinsBtn;
        private System.Windows.Forms.CheckBox showAllCheck;
        private System.Windows.Forms.FlowLayoutPanel scrnCtrlsLayout;
        private System.Windows.Forms.GroupBox groupBox1;
        private WindowButton saveBtn;
        private WindowButton loadBtn;
    }
}

