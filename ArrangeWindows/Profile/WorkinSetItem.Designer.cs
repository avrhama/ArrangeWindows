namespace ArrangeWindows.Profile
{
    partial class WorkinSetItem
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
            this.workingSetName = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // workingSetName
            // 
            this.workingSetName.AutoSize = true;
            this.workingSetName.BackColor = System.Drawing.Color.Transparent;
            this.workingSetName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.workingSetName.Location = new System.Drawing.Point(38, 10);
            this.workingSetName.Name = "workingSetName";
            this.workingSetName.Size = new System.Drawing.Size(93, 32);
            this.workingSetName.TabIndex = 1;
            this.workingSetName.Text = "label1";
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeBtn.Image = global::ArrangeWindows.Resource1.closeOff;
            this.closeBtn.Location = new System.Drawing.Point(401, 6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(40, 40);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeBtn.TabIndex = 2;
            this.closeBtn.TabStop = false;
            // 
            // WorkinSetItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::ArrangeWindows.Resource1.windowCaseOff;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.workingSetName);
            this.DoubleBuffered = true;
            this.Name = "WorkinSetItem";
            this.Size = new System.Drawing.Size(450, 51);
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label workingSetName;
        private System.Windows.Forms.PictureBox closeBtn;
    }
}
