namespace CAO.Blackjack.Forms
{
    partial class FormMenu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            lblTitle = new Label();
            btnStart = new Button();
            tipStart = new ToolTip(components);
            btnResetSave = new Button();
            tipReset = new ToolTip(components);
            btnAbout = new Button();
            tipAbout = new ToolTip(components);
            btnShop = new Button();
            btnExit = new Button();
            tipShop = new ToolTip(components);
            tipExit = new ToolTip(components);
            btnAchievements = new Button();
            tipAchievements = new ToolTip(components);
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Consolas", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(343, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(258, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Blackjack";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Orchid;
            btnStart.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(375, 198);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(195, 63);
            btnStart.TabIndex = 1;
            btnStart.Text = "Play";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // btnResetSave
            // 
            btnResetSave.BackColor = Color.Black;
            btnResetSave.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetSave.ForeColor = Color.White;
            btnResetSave.Location = new Point(12, 434);
            btnResetSave.Name = "btnResetSave";
            btnResetSave.Size = new Size(130, 55);
            btnResetSave.TabIndex = 5;
            btnResetSave.Text = "Reset Save";
            btnResetSave.UseVisualStyleBackColor = false;
            btnResetSave.Click += BtnResetSave_Click;
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.DimGray;
            btnAbout.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAbout.ForeColor = Color.White;
            btnAbout.Location = new Point(403, 434);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(130, 55);
            btnAbout.TabIndex = 4;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += BtnAbout_Click;
            // 
            // btnShop
            // 
            btnShop.BackColor = Color.SteelBlue;
            btnShop.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnShop.ForeColor = Color.White;
            btnShop.Location = new Point(403, 312);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(130, 55);
            btnShop.TabIndex = 2;
            btnShop.Text = "Shop";
            btnShop.UseVisualStyleBackColor = false;
            btnShop.Click += BtnShop_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(802, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 55);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // btnAchievements
            // 
            btnAchievements.BackColor = Color.Indigo;
            btnAchievements.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAchievements.ForeColor = Color.White;
            btnAchievements.Location = new Point(403, 373);
            btnAchievements.Name = "btnAchievements";
            btnAchievements.Size = new Size(130, 55);
            btnAchievements.TabIndex = 3;
            btnAchievements.Text = "Achievements";
            btnAchievements.UseVisualStyleBackColor = false;
            btnAchievements.Click += BtnAchievements_Click;
            // 
            // FormMenu
            // 
            AcceptButton = btnStart;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackgroundImage = Properties.Resources.bg_casino;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(944, 501);
            Controls.Add(btnAchievements);
            Controls.Add(btnExit);
            Controls.Add(btnShop);
            Controls.Add(btnAbout);
            Controls.Add(btnResetSave);
            Controls.Add(btnStart);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blackjack";
            VisibleChanged += FormMenu_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnStart;
        private ToolTip tipStart;
        private Button btnResetSave;
        private ToolTip tipReset;
        private Button btnAbout;
        private ToolTip tipAbout;
        private Button btnShop;
        private Button btnExit;
        private ToolTip tipShop;
        private ToolTip tipExit;
        private Button btnAchievements;
        private ToolTip tipAchievements;
    }
}