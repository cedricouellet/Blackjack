namespace CAO.Blackjack.Forms
{
    partial class FormAchievements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAchievements));
            listAchievements = new ListView();
            btnExit = new Button();
            lblTitle = new Label();
            tipExit = new ToolTip(components);
            tipPurchase = new ToolTip(components);
            tipUse = new ToolTip(components);
            lblDescription = new Label();
            lblStatus = new Label();
            lblProgressionTitle = new Label();
            lblProgressionValue = new Label();
            SuspendLayout();
            // 
            // listAchievements
            // 
            listAchievements.BackColor = Color.Thistle;
            listAchievements.BackgroundImage = Properties.Resources.bg_secondary;
            listAchievements.BorderStyle = BorderStyle.FixedSingle;
            listAchievements.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            listAchievements.ForeColor = Color.White;
            listAchievements.Location = new Point(235, 119);
            listAchievements.MultiSelect = false;
            listAchievements.Name = "listAchievements";
            listAchievements.Size = new Size(249, 370);
            listAchievements.TabIndex = 1;
            listAchievements.UseCompatibleStateImageBehavior = false;
            listAchievements.View = View.List;
            listAchievements.SelectedIndexChanged += ListAchievements_SelectedIndexChanged;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(802, 9);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 55);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Consolas", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(304, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(336, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Achievements";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(490, 168);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(220, 210);
            lblDescription.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(490, 137);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(442, 31);
            lblStatus.TabIndex = 6;
            // 
            // lblProgressionTitle
            // 
            lblProgressionTitle.AutoSize = true;
            lblProgressionTitle.BackColor = Color.Transparent;
            lblProgressionTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblProgressionTitle.ForeColor = Color.Transparent;
            lblProgressionTitle.Location = new Point(343, 65);
            lblProgressionTitle.Name = "lblProgressionTitle";
            lblProgressionTitle.Size = new Size(126, 19);
            lblProgressionTitle.TabIndex = 7;
            lblProgressionTitle.Text = "Progression :";
            // 
            // lblProgressionValue
            // 
            lblProgressionValue.AutoSize = true;
            lblProgressionValue.BackColor = Color.Transparent;
            lblProgressionValue.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblProgressionValue.ForeColor = Color.Transparent;
            lblProgressionValue.Location = new Point(475, 65);
            lblProgressionValue.Name = "lblProgressionValue";
            lblProgressionValue.Size = new Size(0, 19);
            lblProgressionValue.TabIndex = 8;
            // 
            // FormAchievements
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_secondary;
            ClientSize = new Size(944, 501);
            Controls.Add(lblProgressionValue);
            Controls.Add(lblProgressionTitle);
            Controls.Add(lblStatus);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(btnExit);
            Controls.Add(listAchievements);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAchievements";
            Text = "Blackjack - Achievements";
            FormClosing += FormAchievements_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listAchievements;
        private Button btnExit;
        private Label lblTitle;
        private ToolTip tipExit;
        private ToolTip tipPurchase;
        private ToolTip tipUse;
        private Label lblDescription;
        private Label lblStatus;
        private Label lblProgressionTitle;
        private Label lblProgressionValue;
    }
}