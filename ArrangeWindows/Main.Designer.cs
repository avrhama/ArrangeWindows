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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addWinTxt = new System.Windows.Forms.TextBox();
            this.filteredWinsList = new System.Windows.Forms.ListBox();
            this.addWinNameBtn = new System.Windows.Forms.Button();
            this.winsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.windowItem1 = new ArrangeWindows.WindowItem();
            this.scrnCtrl = new ArrangeWindows.ScreenController();
            this.updateWinsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(2361, 497);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(444, 283);
            this.listBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2361, 949);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 68);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addWinTxt
            // 
            this.addWinTxt.Location = new System.Drawing.Point(2361, 76);
            this.addWinTxt.Name = "addWinTxt";
            this.addWinTxt.Size = new System.Drawing.Size(273, 38);
            this.addWinTxt.TabIndex = 4;
            // 
            // filteredWinsList
            // 
            this.filteredWinsList.FormattingEnabled = true;
            this.filteredWinsList.ItemHeight = 31;
            this.filteredWinsList.Location = new System.Drawing.Point(2361, 149);
            this.filteredWinsList.Name = "filteredWinsList";
            this.filteredWinsList.Size = new System.Drawing.Size(273, 221);
            this.filteredWinsList.TabIndex = 5;
            this.filteredWinsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.filterListMouseUp);
            // 
            // addWinNameBtn
            // 
            this.addWinNameBtn.Location = new System.Drawing.Point(2652, 76);
            this.addWinNameBtn.Name = "addWinNameBtn";
            this.addWinNameBtn.Size = new System.Drawing.Size(100, 51);
            this.addWinNameBtn.TabIndex = 6;
            this.addWinNameBtn.Text = "add";
            this.addWinNameBtn.UseVisualStyleBackColor = true;
            this.addWinNameBtn.Click += new System.EventHandler(this.addWinNameBtn_Click);
            // 
            // winsLayout
            // 
            this.winsLayout.Location = new System.Drawing.Point(1738, 76);
            this.winsLayout.Name = "winsLayout";
            this.winsLayout.Size = new System.Drawing.Size(513, 836);
            this.winsLayout.TabIndex = 7;
            // 
            // windowItem1
            // 
            this.windowItem1.Location = new System.Drawing.Point(780, 949);
            this.windowItem1.Name = "windowItem1";
            this.windowItem1.ScreenBoard = null;
            this.windowItem1.Size = new System.Drawing.Size(443, 51);
            this.windowItem1.TabIndex = 3;
            // 
            // scrnCtrl
            // 
            this.scrnCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scrnCtrl.Location = new System.Drawing.Point(74, 76);
            this.scrnCtrl.Name = "scrnCtrl";
            this.scrnCtrl.Size = new System.Drawing.Size(1622, 836);
            this.scrnCtrl.TabIndex = 0;
            // 
            // updateWinsBtn
            // 
            this.updateWinsBtn.Location = new System.Drawing.Point(2361, 408);
            this.updateWinsBtn.Name = "updateWinsBtn";
            this.updateWinsBtn.Size = new System.Drawing.Size(146, 58);
            this.updateWinsBtn.TabIndex = 8;
            this.updateWinsBtn.Text = "update";
            this.updateWinsBtn.UseVisualStyleBackColor = true;
            this.updateWinsBtn.Click += new System.EventHandler(this.updateWinsBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2944, 1067);
            this.Controls.Add(this.updateWinsBtn);
            this.Controls.Add(this.winsLayout);
            this.Controls.Add(this.addWinNameBtn);
            this.Controls.Add(this.filteredWinsList);
            this.Controls.Add(this.addWinTxt);
            this.Controls.Add(this.windowItem1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.scrnCtrl);
            this.Name = "Main";
            this.Text = "Arrange Windows";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScreenController scrnCtrl;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private WindowItem windowItem1;
        private System.Windows.Forms.TextBox addWinTxt;
        private System.Windows.Forms.ListBox filteredWinsList;
        private System.Windows.Forms.Button addWinNameBtn;
        private System.Windows.Forms.FlowLayoutPanel winsLayout;
        private System.Windows.Forms.Button updateWinsBtn;
    }
}

