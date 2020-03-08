namespace ArrangeWindows
{
    partial class WindowItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.windowTitleLbl = new System.Windows.Forms.Label();
            this.windowIconPic = new System.Windows.Forms.PictureBox();
            this.addWindowPic = new ArrangeWindows.WindowButton();
            ((System.ComponentModel.ISupportInitialize)(this.windowIconPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addWindowPic)).BeginInit();
            this.SuspendLayout();
            // 
            // windowTitleLbl
            // 
            this.windowTitleLbl.AutoSize = true;
            this.windowTitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.windowTitleLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowTitleLbl.Location = new System.Drawing.Point(96, 21);
            this.windowTitleLbl.Name = "windowTitleLbl";
            this.windowTitleLbl.Size = new System.Drawing.Size(93, 32);
            this.windowTitleLbl.TabIndex = 1;
            this.windowTitleLbl.Text = "label1";
            // 
            // windowIconPic
            // 
            this.windowIconPic.BackColor = System.Drawing.Color.Transparent;
            this.windowIconPic.Location = new System.Drawing.Point(32, 9);
            this.windowIconPic.Name = "windowIconPic";
            this.windowIconPic.Size = new System.Drawing.Size(48, 48);
            this.windowIconPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.windowIconPic.TabIndex = 0;
            this.windowIconPic.TabStop = false;
            // 
            // addWindowPic
            // 
            this.addWindowPic.BackColor = System.Drawing.Color.Transparent;
            this.addWindowPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addWindowPic.Image = global::ArrangeWindows.Resource1.addOff;
            this.addWindowPic.Location = new System.Drawing.Point(400, 9);
            this.addWindowPic.Name = "addWindowPic";
            this.addWindowPic.Size = new System.Drawing.Size(48, 48);
            this.addWindowPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addWindowPic.TabIndex = 2;
            this.addWindowPic.TabStop = false;
            
            // 
            // WindowItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ArrangeWindows.Resource1.windowCaseOffBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.addWindowPic);
            this.Controls.Add(this.windowTitleLbl);
            this.Controls.Add(this.windowIconPic);
            this.DoubleBuffered = true;
            this.Name = "WindowItem";
            this.Size = new System.Drawing.Size(474, 71);
            ((System.ComponentModel.ISupportInitialize)(this.windowIconPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addWindowPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox windowIconPic;
        private WindowButton addWindowPic;
        private System.Windows.Forms.Label windowTitleLbl;
    }
}
