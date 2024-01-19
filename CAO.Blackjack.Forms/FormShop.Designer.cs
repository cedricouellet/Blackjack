﻿namespace CAO.Blackjack.Forms
{
    partial class FormShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShop));
            listBackgrounds = new ListView();
            lblBackgroundsTitle = new Label();
            btnExit = new Button();
            lblTitle = new Label();
            btnUse = new Button();
            btnPurchase = new Button();
            lblBankTitle = new Label();
            lblBankValue = new Label();
            tipExit = new ToolTip(components);
            tipPurchase = new ToolTip(components);
            tipUse = new ToolTip(components);
            SuspendLayout();
            // 
            // listBackgrounds
            // 
            listBackgrounds.BackColor = Color.Black;
            listBackgrounds.ForeColor = Color.White;
            listBackgrounds.Location = new Point(732, 119);
            listBackgrounds.MultiSelect = false;
            listBackgrounds.Name = "listBackgrounds";
            listBackgrounds.Size = new Size(200, 370);
            listBackgrounds.TabIndex = 0;
            listBackgrounds.UseCompatibleStateImageBehavior = false;
            listBackgrounds.View = View.List;
            listBackgrounds.SelectedIndexChanged += listBackgrounds_SelectedIndexChanged;
            // 
            // lblBackgroundsTitle
            // 
            lblBackgroundsTitle.AutoSize = true;
            lblBackgroundsTitle.BackColor = Color.Transparent;
            lblBackgroundsTitle.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblBackgroundsTitle.ForeColor = Color.White;
            lblBackgroundsTitle.Location = new Point(732, 94);
            lblBackgroundsTitle.Name = "lblBackgroundsTitle";
            lblBackgroundsTitle.Size = new Size(120, 22);
            lblBackgroundsTitle.TabIndex = 1;
            lblBackgroundsTitle.Text = "Backgrounds";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(12, 441);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(113, 48);
            btnExit.TabIndex = 18;
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
            lblTitle.Location = new Point(408, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(128, 56);
            lblTitle.TabIndex = 19;
            lblTitle.Text = "Shop";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUse
            // 
            btnUse.BackColor = Color.SeaGreen;
            btnUse.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUse.ForeColor = Color.White;
            btnUse.Location = new Point(613, 441);
            btnUse.Name = "btnUse";
            btnUse.Size = new Size(113, 48);
            btnUse.TabIndex = 20;
            btnUse.Text = "Use";
            btnUse.UseVisualStyleBackColor = false;
            btnUse.Click += btnUse_Click;
            // 
            // btnPurchase
            // 
            btnPurchase.BackColor = Color.SeaGreen;
            btnPurchase.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPurchase.ForeColor = Color.White;
            btnPurchase.Location = new Point(613, 387);
            btnPurchase.Name = "btnPurchase";
            btnPurchase.Size = new Size(113, 48);
            btnPurchase.TabIndex = 21;
            btnPurchase.Text = "Purchase";
            btnPurchase.UseVisualStyleBackColor = false;
            btnPurchase.Click += btnPurchase_Click;
            // 
            // lblBankTitle
            // 
            lblBankTitle.AutoSize = true;
            lblBankTitle.BackColor = Color.Transparent;
            lblBankTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBankTitle.ForeColor = Color.White;
            lblBankTitle.Location = new Point(12, 9);
            lblBankTitle.Name = "lblBankTitle";
            lblBankTitle.Size = new Size(63, 19);
            lblBankTitle.TabIndex = 22;
            lblBankTitle.Text = "Bank :";
            // 
            // lblBankValue
            // 
            lblBankValue.AutoSize = true;
            lblBankValue.BackColor = Color.Transparent;
            lblBankValue.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBankValue.ForeColor = Color.White;
            lblBankValue.Location = new Point(75, 9);
            lblBankValue.Name = "lblBankValue";
            lblBankValue.Size = new Size(0, 19);
            lblBankValue.TabIndex = 24;
            // 
            // FormShop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_shop;
            ClientSize = new Size(944, 501);
            Controls.Add(lblBankValue);
            Controls.Add(lblBankTitle);
            Controls.Add(btnPurchase);
            Controls.Add(btnUse);
            Controls.Add(lblTitle);
            Controls.Add(btnExit);
            Controls.Add(lblBackgroundsTitle);
            Controls.Add(listBackgrounds);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormShop";
            Text = "Blackjack - Shop";
            FormClosing += FormShop_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listBackgrounds;
        private Label lblBackgroundsTitle;
        private Button btnExit;
        private Label lblTitle;
        private Button btnUse;
        private Button btnPurchase;
        private Label lblBankTitle;
        private Label lblBankValue;
        private ToolTip tipExit;
        private ToolTip tipPurchase;
        private ToolTip tipUse;
    }
}