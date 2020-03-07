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
            this.components = new System.ComponentModel.Container();
            this.scrnPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingTimer = new System.Windows.Forms.Timer(this.components);
            this.scrnCtrlNameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scrnPanel
            // 
            this.scrnPanel.Location = new System.Drawing.Point(26, 44);
            this.scrnPanel.Name = "scrnPanel";
            this.scrnPanel.Size = new System.Drawing.Size(1152, 648);
            this.scrnPanel.TabIndex = 0;
            this.scrnPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownClicked);
            this.scrnPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            this.scrnPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1184, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // drawingTimer
            // 
            this.drawingTimer.Tick += new System.EventHandler(this.drawingTimer_Tick);
            // 
            // scrnCtrlNameLbl
            // 
            this.scrnCtrlNameLbl.AutoSize = true;
            this.scrnCtrlNameLbl.Location = new System.Drawing.Point(29, 9);
            this.scrnCtrlNameLbl.Name = "scrnCtrlNameLbl";
            this.scrnCtrlNameLbl.Size = new System.Drawing.Size(90, 32);
            this.scrnCtrlNameLbl.TabIndex = 3;
            this.scrnCtrlNameLbl.Text = "Name";
            // 
            // ScreenController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.scrnCtrlNameLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scrnPanel);
            this.Name = "ScreenController";
            this.Size = new System.Drawing.Size(1339, 699);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel scrnPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer drawingTimer;
        private System.Windows.Forms.Label scrnCtrlNameLbl;
    }
}
