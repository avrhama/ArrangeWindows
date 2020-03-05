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
            this.screenController1 = new ArrangeWindows.ScreenController();
            this.SuspendLayout();
            // 
            // screenController1
            // 
            this.screenController1.Location = new System.Drawing.Point(74, 76);
            this.screenController1.Name = "screenController1";
            this.screenController1.Size = new System.Drawing.Size(1646, 836);
            this.screenController1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2038, 1067);
            this.Controls.Add(this.screenController1);
            this.Name = "Main";
            this.Text = "Arrange Windows";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScreenController screenController1;
    }
}

