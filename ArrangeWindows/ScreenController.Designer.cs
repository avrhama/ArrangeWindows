namespace ArrangeWindows
{
    partial class ScreenController
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
            this.scrnPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scrnPanel
            // 
            this.scrnPanel.Location = new System.Drawing.Point(26, 27);
            this.scrnPanel.Name = "scrnPanel";
            this.scrnPanel.Size = new System.Drawing.Size(1377, 770);
            this.scrnPanel.TabIndex = 0;
            this.scrnPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownClicked);
            this.scrnPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            this.scrnPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1432, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1432, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // ScreenController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scrnPanel);
            this.Name = "ScreenController";
            this.Size = new System.Drawing.Size(1644, 834);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel scrnPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}
