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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenController));
            this.scrnPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingTimer = new System.Windows.Forms.Timer(this.components);
            this.scrnCtrlNameLbl = new System.Windows.Forms.Label();
            this.loadBtn = new ArrangeWindows.WindowButton();
            this.saveBtn = new ArrangeWindows.WindowButton();
            this.applayBtn = new ArrangeWindows.WindowButton();
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applayBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // scrnPanel
            // 
            this.scrnPanel.Location = new System.Drawing.Point(5, 55);
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
            this.label1.Location = new System.Drawing.Point(1059, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // drawingTimer
            // 
            this.drawingTimer.Tick += new System.EventHandler(this.drawingTimer_Tick);
            // 
            // scrnCtrlNameLbl
            // 
            this.scrnCtrlNameLbl.AutoSize = true;
            this.scrnCtrlNameLbl.Location = new System.Drawing.Point(626, 15);
            this.scrnCtrlNameLbl.Name = "scrnCtrlNameLbl";
            this.scrnCtrlNameLbl.Size = new System.Drawing.Size(90, 32);
            this.scrnCtrlNameLbl.TabIndex = 3;
            this.scrnCtrlNameLbl.Text = "Name";
            // 
            // loadBtn
            // 
            this.loadBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.LoadOff,
        global::ArrangeWindows.Resource1.LoadOn};
            this.loadBtn.Image = global::ArrangeWindows.Resource1.LoadOff;
            this.loadBtn.Location = new System.Drawing.Point(210, 0);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(200, 50);
            this.loadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadBtn.TabIndex = 8;
            this.loadBtn.TabStop = false;
            this.loadBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // saveBtn
            // 
            this.saveBtn.BtnImages = new System.Drawing.Bitmap[] {
        ((System.Drawing.Bitmap)(resources.GetObject("saveBtn.BtnImages"))),
        ((System.Drawing.Bitmap)(resources.GetObject("saveBtn.BtnImages1")))};
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.Location = new System.Drawing.Point(420, 0);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 50);
            this.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saveBtn.TabIndex = 7;
            this.saveBtn.TabStop = false;
            this.saveBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // applayBtn
            // 
            this.applayBtn.BackColor = System.Drawing.Color.Transparent;
            this.applayBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.applyOff,
        global::ArrangeWindows.Resource1.applyOn};
            this.applayBtn.Image = global::ArrangeWindows.Resource1.applyOff;
            this.applayBtn.Location = new System.Drawing.Point(0, 0);
            this.applayBtn.Name = "applayBtn";
            this.applayBtn.Size = new System.Drawing.Size(200, 50);
            this.applayBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.applayBtn.TabIndex = 6;
            this.applayBtn.TabStop = false;
            this.applayBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // ScreenController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.applayBtn);
            this.Controls.Add(this.scrnCtrlNameLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scrnPanel);
            this.Name = "ScreenController";
            this.Size = new System.Drawing.Size(1162, 708);
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applayBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel scrnPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer drawingTimer;
        private System.Windows.Forms.Label scrnCtrlNameLbl;
        private WindowButton applayBtn;
        private WindowButton saveBtn;
        private WindowButton loadBtn;
    }
}
