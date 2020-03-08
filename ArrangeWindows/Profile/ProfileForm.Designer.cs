namespace ArrangeWindows.Profile
{
    partial class ProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.profilesLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.monitorsCombo = new System.Windows.Forms.ComboBox();
            this.profileNameTxt = new System.Windows.Forms.TextBox();
            this.loadBtn = new ArrangeWindows.WindowButton();
            this.saveBtn = new ArrangeWindows.WindowButton();
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // profilesLayout
            // 
            this.profilesLayout.Location = new System.Drawing.Point(25, 115);
            this.profilesLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profilesLayout.Name = "profilesLayout";
            this.profilesLayout.Size = new System.Drawing.Size(600, 273);
            this.profilesLayout.TabIndex = 11;
            // 
            // monitosCombo
            // 
            this.monitorsCombo.FormattingEnabled = true;
            this.monitorsCombo.Location = new System.Drawing.Point(25, 10);
            this.monitorsCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.monitorsCombo.Name = "monitosCombo";
            this.monitorsCombo.Size = new System.Drawing.Size(600, 39);
            this.monitorsCombo.TabIndex = 12;
            // 
            // profileNameTxt
            // 
            this.profileNameTxt.Location = new System.Drawing.Point(29, 60);
            this.profileNameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.profileNameTxt.Name = "profileNameTxt";
            this.profileNameTxt.Size = new System.Drawing.Size(595, 38);
            this.profileNameTxt.TabIndex = 13;
            // 
            // loadBtn
            // 
            this.loadBtn.BtnImages = new System.Drawing.Bitmap[] {
        global::ArrangeWindows.Resource1.LoadOff,
        global::ArrangeWindows.Resource1.LoadOn};
            this.loadBtn.Image = global::ArrangeWindows.Resource1.LoadOff;
            this.loadBtn.Location = new System.Drawing.Point(25, 408);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(200, 50);
            this.loadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadBtn.TabIndex = 10;
            this.loadBtn.TabStop = false;
            this.loadBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // saveBtn
            // 
            this.saveBtn.BtnImages = new System.Drawing.Bitmap[] {
        ((System.Drawing.Bitmap)(resources.GetObject("saveBtn.BtnImages"))),
        ((System.Drawing.Bitmap)(resources.GetObject("saveBtn.BtnImages1")))};
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.Location = new System.Drawing.Point(425, 408);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 50);
            this.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saveBtn.TabIndex = 9;
            this.saveBtn.TabStop = false;
            this.saveBtn.Type = ArrangeWindows.WindowButtonType.Add;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 464);
            this.Controls.Add(this.profileNameTxt);
            this.Controls.Add(this.monitorsCombo);
            this.Controls.Add(this.profilesLayout);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProfileForm";
            this.Text = "ProfileLoadForm";
            ((System.ComponentModel.ISupportInitialize)(this.loadBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowButton loadBtn;
        private WindowButton saveBtn;
        private System.Windows.Forms.FlowLayoutPanel profilesLayout;
        private System.Windows.Forms.ComboBox monitorsCombo;
        private System.Windows.Forms.TextBox profileNameTxt;
    }
}