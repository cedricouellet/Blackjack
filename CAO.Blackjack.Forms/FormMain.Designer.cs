namespace CAO.Blackjack.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            btnStart.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(388, 224);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(168, 40);
            btnStart.TabIndex = 4;
            btnStart.Text = "Play";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // btnResetSave
            // 
            btnResetSave.BackColor = Color.Black;
            btnResetSave.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetSave.ForeColor = Color.White;
            btnResetSave.Location = new Point(407, 433);
            btnResetSave.Name = "btnResetSave";
            btnResetSave.Size = new Size(131, 34);
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
            btnAbout.Location = new Point(407, 312);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(131, 34);
            btnAbout.TabIndex = 6;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += BtnAbout_Click;
            // 
            // btnShop
            // 
            btnShop.BackColor = Color.SteelBlue;
            btnShop.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnShop.ForeColor = Color.White;
            btnShop.Location = new Point(407, 352);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(131, 34);
            btnShop.TabIndex = 7;
            btnShop.Text = "Shop";
            btnShop.UseVisualStyleBackColor = false;
            btnShop.Click += BtnShop_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(407, 392);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(131, 34);
            btnExit.TabIndex = 8;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // FormMain
            // 
            AcceptButton = btnStart;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackgroundImage = Properties.Resources.bg_casino;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(944, 501);
            Controls.Add(btnExit);
            Controls.Add(btnShop);
            Controls.Add(btnAbout);
            Controls.Add(btnResetSave);
            Controls.Add(btnStart);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormMain";
            Text = "Blackjack";
            VisibleChanged += FormMain_VisibleChanged;
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
    }
}