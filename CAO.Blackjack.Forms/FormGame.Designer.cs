namespace CAO.Blackjack.Forms
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            groupInfo = new GroupBox();
            lblBetValue = new Label();
            lblBetTitle = new Label();
            lblTiesValue = new Label();
            lblTiesTitle = new Label();
            lblLossesValue = new Label();
            lblLossesTitle = new Label();
            lblWinsValue = new Label();
            lblWinsTitle = new Label();
            lblTurnValue = new Label();
            lblTurnTitle = new Label();
            lblBankValue = new Label();
            lblBankTitle = new Label();
            groupBet = new GroupBox();
            btnBet100 = new Button();
            btnBet50 = new Button();
            btnBet25 = new Button();
            btnBet500 = new Button();
            btnBet5 = new Button();
            btnBet1 = new Button();
            btnDeal = new Button();
            btnHit = new Button();
            btnStand = new Button();
            btnDouble = new Button();
            groupActions = new GroupBox();
            tipHit = new ToolTip(components);
            tipStand = new ToolTip(components);
            tipDouble = new ToolTip(components);
            tipDeal = new ToolTip(components);
            tipBet1 = new ToolTip(components);
            tipBet5 = new ToolTip(components);
            tipBet25 = new ToolTip(components);
            tipBet50 = new ToolTip(components);
            tipBet100 = new ToolTip(components);
            tipBet500 = new ToolTip(components);
            btnExit = new Button();
            pnlPlayerCard1 = new Panel();
            pnlPlayerCard2 = new Panel();
            pnlPlayerCard3 = new Panel();
            pnlPlayerCard4 = new Panel();
            pnlPlayerCard5 = new Panel();
            pnlPlayerCard6 = new Panel();
            pnlPlayerCard7 = new Panel();
            pnlPlayerCard8 = new Panel();
            pnlPlayerCard9 = new Panel();
            pnlPlayerCard10 = new Panel();
            pnlPlayerCard11 = new Panel();
            groupPlayerCards = new GroupBox();
            groupDealerCards = new GroupBox();
            pnlDealerCard1 = new Panel();
            pnlDealerCard11 = new Panel();
            pnlDealerCard2 = new Panel();
            pnlDealerCard10 = new Panel();
            pnlDealerCard5 = new Panel();
            pnlDealerCard9 = new Panel();
            pnlDealerCard3 = new Panel();
            pnlDealerCard8 = new Panel();
            pnlDealerCard4 = new Panel();
            pnlDealerCard7 = new Panel();
            pnlDealerCard6 = new Panel();
            tipExit = new ToolTip(components);
            btnResetBet = new Button();
            tipResetBet = new ToolTip(components);
            lblDealerHand = new Label();
            lblPlayerHand = new Label();
            groupInfo.SuspendLayout();
            groupBet.SuspendLayout();
            groupActions.SuspendLayout();
            groupPlayerCards.SuspendLayout();
            groupDealerCards.SuspendLayout();
            SuspendLayout();
            // 
            // groupInfo
            // 
            groupInfo.BackColor = Color.Transparent;
            groupInfo.Controls.Add(lblBetValue);
            groupInfo.Controls.Add(lblBetTitle);
            groupInfo.Controls.Add(lblTiesValue);
            groupInfo.Controls.Add(lblTiesTitle);
            groupInfo.Controls.Add(lblLossesValue);
            groupInfo.Controls.Add(lblLossesTitle);
            groupInfo.Controls.Add(lblWinsValue);
            groupInfo.Controls.Add(lblWinsTitle);
            groupInfo.Controls.Add(lblTurnValue);
            groupInfo.Controls.Add(lblTurnTitle);
            groupInfo.Controls.Add(lblBankValue);
            groupInfo.Controls.Add(lblBankTitle);
            groupInfo.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            groupInfo.ForeColor = Color.White;
            groupInfo.Location = new Point(12, 12);
            groupInfo.Name = "groupInfo";
            groupInfo.Size = new Size(241, 157);
            groupInfo.TabIndex = 0;
            groupInfo.TabStop = false;
            groupInfo.Text = "Info";
            // 
            // lblBetValue
            // 
            lblBetValue.AutoSize = true;
            lblBetValue.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBetValue.Location = new Point(93, 47);
            lblBetValue.Name = "lblBetValue";
            lblBetValue.Size = new Size(36, 19);
            lblBetValue.TabIndex = 11;
            lblBetValue.Text = "25$";
            // 
            // lblBetTitle
            // 
            lblBetTitle.AutoSize = true;
            lblBetTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBetTitle.Location = new Point(6, 47);
            lblBetTitle.Name = "lblBetTitle";
            lblBetTitle.Size = new Size(81, 19);
            lblBetTitle.TabIndex = 10;
            lblBetTitle.Text = "Bet    :";
            // 
            // lblTiesValue
            // 
            lblTiesValue.AutoSize = true;
            lblTiesValue.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTiesValue.Location = new Point(93, 125);
            lblTiesValue.Name = "lblTiesValue";
            lblTiesValue.Size = new Size(18, 19);
            lblTiesValue.TabIndex = 9;
            lblTiesValue.Text = "2";
            // 
            // lblTiesTitle
            // 
            lblTiesTitle.AutoSize = true;
            lblTiesTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTiesTitle.Location = new Point(6, 125);
            lblTiesTitle.Name = "lblTiesTitle";
            lblTiesTitle.Size = new Size(81, 19);
            lblTiesTitle.TabIndex = 8;
            lblTiesTitle.Text = "Ties   :";
            // 
            // lblLossesValue
            // 
            lblLossesValue.AutoSize = true;
            lblLossesValue.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblLossesValue.Location = new Point(93, 106);
            lblLossesValue.Name = "lblLossesValue";
            lblLossesValue.Size = new Size(18, 19);
            lblLossesValue.TabIndex = 7;
            lblLossesValue.Text = "2";
            // 
            // lblLossesTitle
            // 
            lblLossesTitle.AutoSize = true;
            lblLossesTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLossesTitle.Location = new Point(6, 106);
            lblLossesTitle.Name = "lblLossesTitle";
            lblLossesTitle.Size = new Size(81, 19);
            lblLossesTitle.TabIndex = 6;
            lblLossesTitle.Text = "Losses :";
            // 
            // lblWinsValue
            // 
            lblWinsValue.AutoSize = true;
            lblWinsValue.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblWinsValue.Location = new Point(93, 87);
            lblWinsValue.Name = "lblWinsValue";
            lblWinsValue.Size = new Size(27, 19);
            lblWinsValue.TabIndex = 5;
            lblWinsValue.Text = "10";
            // 
            // lblWinsTitle
            // 
            lblWinsTitle.AutoSize = true;
            lblWinsTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblWinsTitle.Location = new Point(6, 87);
            lblWinsTitle.Name = "lblWinsTitle";
            lblWinsTitle.Size = new Size(81, 19);
            lblWinsTitle.TabIndex = 4;
            lblWinsTitle.Text = "Wins   :";
            // 
            // lblTurnValue
            // 
            lblTurnValue.AutoSize = true;
            lblTurnValue.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTurnValue.Location = new Point(93, 68);
            lblTurnValue.Name = "lblTurnValue";
            lblTurnValue.Size = new Size(36, 19);
            lblTurnValue.TabIndex = 3;
            lblTurnValue.Text = "You";
            // 
            // lblTurnTitle
            // 
            lblTurnTitle.AutoSize = true;
            lblTurnTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTurnTitle.Location = new Point(6, 68);
            lblTurnTitle.Name = "lblTurnTitle";
            lblTurnTitle.Size = new Size(81, 19);
            lblTurnTitle.TabIndex = 2;
            lblTurnTitle.Text = "Turn   :";
            // 
            // lblBankValue
            // 
            lblBankValue.AutoSize = true;
            lblBankValue.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBankValue.Location = new Point(93, 28);
            lblBankValue.Name = "lblBankValue";
            lblBankValue.Size = new Size(45, 19);
            lblBankValue.TabIndex = 1;
            lblBankValue.Text = "900$";
            // 
            // lblBankTitle
            // 
            lblBankTitle.AutoSize = true;
            lblBankTitle.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBankTitle.Location = new Point(6, 28);
            lblBankTitle.Name = "lblBankTitle";
            lblBankTitle.Size = new Size(81, 19);
            lblBankTitle.TabIndex = 0;
            lblBankTitle.Text = "Bank   :";
            // 
            // groupBet
            // 
            groupBet.BackColor = Color.Transparent;
            groupBet.Controls.Add(btnBet100);
            groupBet.Controls.Add(btnBet50);
            groupBet.Controls.Add(btnBet25);
            groupBet.Controls.Add(btnBet500);
            groupBet.Controls.Add(btnBet5);
            groupBet.Controls.Add(btnBet1);
            groupBet.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            groupBet.ForeColor = Color.White;
            groupBet.Location = new Point(12, 175);
            groupBet.Name = "groupBet";
            groupBet.Size = new Size(241, 106);
            groupBet.TabIndex = 10;
            groupBet.TabStop = false;
            groupBet.Text = "Bet";
            // 
            // btnBet100
            // 
            btnBet100.BackColor = Color.MidnightBlue;
            btnBet100.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBet100.ForeColor = Color.White;
            btnBet100.Location = new Point(93, 63);
            btnBet100.Name = "btnBet100";
            btnBet100.Size = new Size(54, 31);
            btnBet100.TabIndex = 5;
            btnBet100.Text = "100$";
            btnBet100.UseVisualStyleBackColor = false;
            btnBet100.Click += BtnBet_Click;
            // 
            // btnBet50
            // 
            btnBet50.BackColor = Color.RoyalBlue;
            btnBet50.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBet50.ForeColor = Color.White;
            btnBet50.Location = new Point(33, 63);
            btnBet50.Name = "btnBet50";
            btnBet50.Size = new Size(54, 31);
            btnBet50.TabIndex = 4;
            btnBet50.Text = "50$";
            btnBet50.UseVisualStyleBackColor = false;
            btnBet50.Click += BtnBet_Click;
            // 
            // btnBet25
            // 
            btnBet25.BackColor = Color.Green;
            btnBet25.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBet25.ForeColor = Color.White;
            btnBet25.Location = new Point(153, 26);
            btnBet25.Name = "btnBet25";
            btnBet25.Size = new Size(54, 31);
            btnBet25.TabIndex = 3;
            btnBet25.Text = "25$";
            btnBet25.UseVisualStyleBackColor = false;
            btnBet25.Click += BtnBet_Click;
            // 
            // btnBet500
            // 
            btnBet500.BackColor = Color.DarkOrchid;
            btnBet500.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBet500.ForeColor = Color.White;
            btnBet500.Location = new Point(153, 63);
            btnBet500.Name = "btnBet500";
            btnBet500.Size = new Size(54, 31);
            btnBet500.TabIndex = 2;
            btnBet500.Text = "500$";
            btnBet500.UseVisualStyleBackColor = false;
            btnBet500.Click += BtnBet_Click;
            // 
            // btnBet5
            // 
            btnBet5.BackColor = Color.DarkRed;
            btnBet5.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBet5.ForeColor = Color.White;
            btnBet5.Location = new Point(93, 26);
            btnBet5.Name = "btnBet5";
            btnBet5.Size = new Size(54, 31);
            btnBet5.TabIndex = 1;
            btnBet5.Text = "5$";
            btnBet5.UseVisualStyleBackColor = false;
            btnBet5.Click += BtnBet_Click;
            // 
            // btnBet1
            // 
            btnBet1.BackColor = Color.LightBlue;
            btnBet1.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBet1.ForeColor = Color.RoyalBlue;
            btnBet1.Location = new Point(33, 26);
            btnBet1.Name = "btnBet1";
            btnBet1.Size = new Size(54, 31);
            btnBet1.TabIndex = 0;
            btnBet1.Text = "1$";
            btnBet1.UseVisualStyleBackColor = false;
            btnBet1.Click += BtnBet_Click;
            // 
            // btnDeal
            // 
            btnDeal.BackColor = Color.SeaGreen;
            btnDeal.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeal.ForeColor = Color.White;
            btnDeal.Location = new Point(43, 287);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new Size(80, 40);
            btnDeal.TabIndex = 11;
            btnDeal.Text = "Deal";
            btnDeal.UseVisualStyleBackColor = false;
            btnDeal.Click += BtnDeal_Click;
            // 
            // btnHit
            // 
            btnHit.BackColor = Color.SeaGreen;
            btnHit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnHit.ForeColor = Color.White;
            btnHit.Location = new Point(10, 28);
            btnHit.Name = "btnHit";
            btnHit.Size = new Size(80, 40);
            btnHit.TabIndex = 13;
            btnHit.Text = "Hit";
            btnHit.UseVisualStyleBackColor = false;
            btnHit.Click += BtnHit_Click;
            // 
            // btnStand
            // 
            btnStand.BackColor = Color.SeaGreen;
            btnStand.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnStand.ForeColor = Color.White;
            btnStand.Location = new Point(10, 74);
            btnStand.Name = "btnStand";
            btnStand.Size = new Size(80, 40);
            btnStand.TabIndex = 14;
            btnStand.Text = "Stand";
            btnStand.UseVisualStyleBackColor = false;
            btnStand.Click += BtnStand_Click;
            // 
            // btnDouble
            // 
            btnDouble.BackColor = Color.SeaGreen;
            btnDouble.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDouble.ForeColor = Color.White;
            btnDouble.Location = new Point(9, 120);
            btnDouble.Name = "btnDouble";
            btnDouble.Size = new Size(80, 40);
            btnDouble.TabIndex = 15;
            btnDouble.Text = "Double";
            btnDouble.UseVisualStyleBackColor = false;
            btnDouble.Click += BtnDouble_Click;
            // 
            // groupActions
            // 
            groupActions.BackColor = Color.Transparent;
            groupActions.Controls.Add(btnHit);
            groupActions.Controls.Add(btnDouble);
            groupActions.Controls.Add(btnStand);
            groupActions.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            groupActions.ForeColor = Color.White;
            groupActions.Location = new Point(12, 322);
            groupActions.Name = "groupActions";
            groupActions.Size = new Size(99, 167);
            groupActions.TabIndex = 16;
            groupActions.TabStop = false;
            groupActions.Text = "Actions";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.SeaGreen;
            btnExit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(852, 449);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(80, 40);
            btnExit.TabIndex = 17;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // pnlPlayerCard1
            // 
            pnlPlayerCard1.BackColor = Color.Transparent;
            pnlPlayerCard1.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard1.Location = new Point(6, 22);
            pnlPlayerCard1.Name = "pnlPlayerCard1";
            pnlPlayerCard1.Size = new Size(62, 89);
            pnlPlayerCard1.TabIndex = 19;
            // 
            // pnlPlayerCard2
            // 
            pnlPlayerCard2.BackColor = Color.Transparent;
            pnlPlayerCard2.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard2.Location = new Point(74, 22);
            pnlPlayerCard2.Name = "pnlPlayerCard2";
            pnlPlayerCard2.Size = new Size(62, 89);
            pnlPlayerCard2.TabIndex = 20;
            // 
            // pnlPlayerCard3
            // 
            pnlPlayerCard3.BackColor = Color.Transparent;
            pnlPlayerCard3.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard3.Location = new Point(142, 22);
            pnlPlayerCard3.Name = "pnlPlayerCard3";
            pnlPlayerCard3.Size = new Size(62, 89);
            pnlPlayerCard3.TabIndex = 21;
            // 
            // pnlPlayerCard4
            // 
            pnlPlayerCard4.BackColor = Color.Transparent;
            pnlPlayerCard4.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard4.Location = new Point(210, 22);
            pnlPlayerCard4.Name = "pnlPlayerCard4";
            pnlPlayerCard4.Size = new Size(62, 89);
            pnlPlayerCard4.TabIndex = 22;
            // 
            // pnlPlayerCard5
            // 
            pnlPlayerCard5.BackColor = Color.Transparent;
            pnlPlayerCard5.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard5.Location = new Point(278, 22);
            pnlPlayerCard5.Name = "pnlPlayerCard5";
            pnlPlayerCard5.Size = new Size(62, 89);
            pnlPlayerCard5.TabIndex = 23;
            // 
            // pnlPlayerCard6
            // 
            pnlPlayerCard6.BackColor = Color.Transparent;
            pnlPlayerCard6.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard6.Location = new Point(346, 22);
            pnlPlayerCard6.Name = "pnlPlayerCard6";
            pnlPlayerCard6.Size = new Size(62, 89);
            pnlPlayerCard6.TabIndex = 25;
            // 
            // pnlPlayerCard7
            // 
            pnlPlayerCard7.BackColor = Color.Transparent;
            pnlPlayerCard7.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard7.Location = new Point(6, 117);
            pnlPlayerCard7.Name = "pnlPlayerCard7";
            pnlPlayerCard7.Size = new Size(62, 89);
            pnlPlayerCard7.TabIndex = 26;
            // 
            // pnlPlayerCard8
            // 
            pnlPlayerCard8.BackColor = Color.Transparent;
            pnlPlayerCard8.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard8.Location = new Point(74, 117);
            pnlPlayerCard8.Name = "pnlPlayerCard8";
            pnlPlayerCard8.Size = new Size(62, 89);
            pnlPlayerCard8.TabIndex = 27;
            // 
            // pnlPlayerCard9
            // 
            pnlPlayerCard9.BackColor = Color.Transparent;
            pnlPlayerCard9.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard9.Location = new Point(142, 117);
            pnlPlayerCard9.Name = "pnlPlayerCard9";
            pnlPlayerCard9.Size = new Size(62, 89);
            pnlPlayerCard9.TabIndex = 28;
            // 
            // pnlPlayerCard10
            // 
            pnlPlayerCard10.BackColor = Color.Transparent;
            pnlPlayerCard10.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard10.Location = new Point(210, 117);
            pnlPlayerCard10.Name = "pnlPlayerCard10";
            pnlPlayerCard10.Size = new Size(62, 89);
            pnlPlayerCard10.TabIndex = 29;
            // 
            // pnlPlayerCard11
            // 
            pnlPlayerCard11.BackColor = Color.Transparent;
            pnlPlayerCard11.BackgroundImageLayout = ImageLayout.Zoom;
            pnlPlayerCard11.Location = new Point(278, 117);
            pnlPlayerCard11.Name = "pnlPlayerCard11";
            pnlPlayerCard11.Size = new Size(62, 89);
            pnlPlayerCard11.TabIndex = 30;
            // 
            // groupPlayerCards
            // 
            groupPlayerCards.BackColor = Color.Transparent;
            groupPlayerCards.Controls.Add(pnlPlayerCard7);
            groupPlayerCards.Controls.Add(pnlPlayerCard1);
            groupPlayerCards.Controls.Add(pnlPlayerCard11);
            groupPlayerCards.Controls.Add(pnlPlayerCard2);
            groupPlayerCards.Controls.Add(pnlPlayerCard10);
            groupPlayerCards.Controls.Add(pnlPlayerCard5);
            groupPlayerCards.Controls.Add(pnlPlayerCard9);
            groupPlayerCards.Controls.Add(pnlPlayerCard3);
            groupPlayerCards.Controls.Add(pnlPlayerCard8);
            groupPlayerCards.Controls.Add(pnlPlayerCard4);
            groupPlayerCards.Controls.Add(pnlPlayerCard6);
            groupPlayerCards.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupPlayerCards.ForeColor = Color.White;
            groupPlayerCards.Location = new Point(283, 287);
            groupPlayerCards.Name = "groupPlayerCards";
            groupPlayerCards.Size = new Size(418, 202);
            groupPlayerCards.TabIndex = 31;
            groupPlayerCards.TabStop = false;
            // 
            // groupDealerCards
            // 
            groupDealerCards.BackColor = Color.Transparent;
            groupDealerCards.Controls.Add(pnlDealerCard1);
            groupDealerCards.Controls.Add(pnlDealerCard11);
            groupDealerCards.Controls.Add(pnlDealerCard2);
            groupDealerCards.Controls.Add(pnlDealerCard10);
            groupDealerCards.Controls.Add(pnlDealerCard5);
            groupDealerCards.Controls.Add(pnlDealerCard9);
            groupDealerCards.Controls.Add(pnlDealerCard3);
            groupDealerCards.Controls.Add(pnlDealerCard8);
            groupDealerCards.Controls.Add(pnlDealerCard4);
            groupDealerCards.Controls.Add(pnlDealerCard7);
            groupDealerCards.Controls.Add(pnlDealerCard6);
            groupDealerCards.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupDealerCards.ForeColor = Color.White;
            groupDealerCards.Location = new Point(283, 37);
            groupDealerCards.Name = "groupDealerCards";
            groupDealerCards.Size = new Size(418, 212);
            groupDealerCards.TabIndex = 32;
            groupDealerCards.TabStop = false;
            // 
            // pnlDealerCard1
            // 
            pnlDealerCard1.BackColor = Color.Transparent;
            pnlDealerCard1.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard1.Location = new Point(6, 22);
            pnlDealerCard1.Name = "pnlDealerCard1";
            pnlDealerCard1.Size = new Size(62, 89);
            pnlDealerCard1.TabIndex = 19;
            // 
            // pnlDealerCard11
            // 
            pnlDealerCard11.BackColor = Color.Transparent;
            pnlDealerCard11.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard11.Location = new Point(278, 117);
            pnlDealerCard11.Name = "pnlDealerCard11";
            pnlDealerCard11.Size = new Size(62, 89);
            pnlDealerCard11.TabIndex = 30;
            // 
            // pnlDealerCard2
            // 
            pnlDealerCard2.BackColor = Color.Transparent;
            pnlDealerCard2.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard2.Location = new Point(74, 22);
            pnlDealerCard2.Name = "pnlDealerCard2";
            pnlDealerCard2.Size = new Size(62, 89);
            pnlDealerCard2.TabIndex = 20;
            // 
            // pnlDealerCard10
            // 
            pnlDealerCard10.BackColor = Color.Transparent;
            pnlDealerCard10.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard10.Location = new Point(210, 117);
            pnlDealerCard10.Name = "pnlDealerCard10";
            pnlDealerCard10.Size = new Size(62, 89);
            pnlDealerCard10.TabIndex = 29;
            // 
            // pnlDealerCard5
            // 
            pnlDealerCard5.BackColor = Color.Transparent;
            pnlDealerCard5.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard5.Location = new Point(278, 22);
            pnlDealerCard5.Name = "pnlDealerCard5";
            pnlDealerCard5.Size = new Size(62, 89);
            pnlDealerCard5.TabIndex = 23;
            // 
            // pnlDealerCard9
            // 
            pnlDealerCard9.BackColor = Color.Transparent;
            pnlDealerCard9.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard9.Location = new Point(142, 117);
            pnlDealerCard9.Name = "pnlDealerCard9";
            pnlDealerCard9.Size = new Size(62, 89);
            pnlDealerCard9.TabIndex = 28;
            // 
            // pnlDealerCard3
            // 
            pnlDealerCard3.BackColor = Color.Transparent;
            pnlDealerCard3.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard3.Location = new Point(142, 22);
            pnlDealerCard3.Name = "pnlDealerCard3";
            pnlDealerCard3.Size = new Size(62, 89);
            pnlDealerCard3.TabIndex = 21;
            // 
            // pnlDealerCard8
            // 
            pnlDealerCard8.BackColor = Color.Transparent;
            pnlDealerCard8.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard8.Location = new Point(74, 117);
            pnlDealerCard8.Name = "pnlDealerCard8";
            pnlDealerCard8.Size = new Size(62, 89);
            pnlDealerCard8.TabIndex = 27;
            // 
            // pnlDealerCard4
            // 
            pnlDealerCard4.BackColor = Color.Transparent;
            pnlDealerCard4.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard4.Location = new Point(210, 22);
            pnlDealerCard4.Name = "pnlDealerCard4";
            pnlDealerCard4.Size = new Size(62, 89);
            pnlDealerCard4.TabIndex = 22;
            // 
            // pnlDealerCard7
            // 
            pnlDealerCard7.BackColor = Color.Transparent;
            pnlDealerCard7.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard7.Location = new Point(6, 117);
            pnlDealerCard7.Name = "pnlDealerCard7";
            pnlDealerCard7.Size = new Size(62, 89);
            pnlDealerCard7.TabIndex = 26;
            // 
            // pnlDealerCard6
            // 
            pnlDealerCard6.BackColor = Color.Transparent;
            pnlDealerCard6.BackgroundImageLayout = ImageLayout.Zoom;
            pnlDealerCard6.Location = new Point(346, 22);
            pnlDealerCard6.Name = "pnlDealerCard6";
            pnlDealerCard6.Size = new Size(62, 89);
            pnlDealerCard6.TabIndex = 25;
            // 
            // btnResetBet
            // 
            btnResetBet.BackColor = Color.SeaGreen;
            btnResetBet.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetBet.ForeColor = Color.White;
            btnResetBet.Location = new Point(129, 287);
            btnResetBet.Name = "btnResetBet";
            btnResetBet.Size = new Size(80, 40);
            btnResetBet.TabIndex = 33;
            btnResetBet.Text = "Reset";
            btnResetBet.UseVisualStyleBackColor = false;
            btnResetBet.Click += BtnResetBet_Click;
            // 
            // lblDealerHand
            // 
            lblDealerHand.AutoSize = true;
            lblDealerHand.BackColor = Color.Transparent;
            lblDealerHand.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblDealerHand.ForeColor = Color.White;
            lblDealerHand.Location = new Point(283, 21);
            lblDealerHand.Name = "lblDealerHand";
            lblDealerHand.Size = new Size(110, 22);
            lblDealerHand.TabIndex = 34;
            lblDealerHand.Text = "Dealer : 0";
            // 
            // lblPlayerHand
            // 
            lblPlayerHand.AutoSize = true;
            lblPlayerHand.BackColor = Color.Transparent;
            lblPlayerHand.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlayerHand.ForeColor = Color.White;
            lblPlayerHand.Location = new Point(283, 272);
            lblPlayerHand.Name = "lblPlayerHand";
            lblPlayerHand.Size = new Size(110, 22);
            lblPlayerHand.TabIndex = 35;
            lblPlayerHand.Text = "Player : 0";
            // 
            // FormGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackgroundImage = Properties.Resources.bg_default;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(944, 501);
            Controls.Add(lblPlayerHand);
            Controls.Add(lblDealerHand);
            Controls.Add(btnResetBet);
            Controls.Add(groupDealerCards);
            Controls.Add(groupPlayerCards);
            Controls.Add(btnExit);
            Controls.Add(groupActions);
            Controls.Add(btnDeal);
            Controls.Add(groupInfo);
            Controls.Add(groupBet);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormGame";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Blackjack";
            FormClosing += FormGame_FormClosing;
            groupInfo.ResumeLayout(false);
            groupInfo.PerformLayout();
            groupBet.ResumeLayout(false);
            groupActions.ResumeLayout(false);
            groupPlayerCards.ResumeLayout(false);
            groupDealerCards.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupInfo;
        private Label lblBankTitle;
        private Label lblBankValue;
        private Label lblWinsTitle;
        private Label lblTurnValue;
        private Label lblTurnTitle;
        private Label lblLossesTitle;
        private Label lblWinsValue;
        private Label lblTiesValue;
        private Label lblTiesTitle;
        private Label lblLossesValue;
        private GroupBox groupBet;
        private Button btnBet100;
        private Button btnBet50;
        private Button btnBet25;
        private Button btnBet500;
        private Button btnBet5;
        private Button btnBet1;
        private Label lblBetValue;
        private Label lblBetTitle;
        private Button btnDeal;
        private Button btnHit;
        private Button btnStand;
        private Button btnDouble;
        private GroupBox groupActions;
        private ToolTip tipHit;
        private ToolTip tipStand;
        private ToolTip tipDouble;
        private ToolTip tipDeal;
        private ToolTip tipBet1;
        private ToolTip tipBet5;
        private ToolTip tipBet25;
        private ToolTip tipBet50;
        private ToolTip tipBet100;
        private ToolTip tipBet500;
        private Button btnExit;
        private Panel pnlPlayerCard1;
        private Panel pnlPlayerCard2;
        private Panel pnlPlayerCard3;
        private Panel pnlPlayerCard4;
        private Panel pnlPlayerCard5;
        private Panel pnlPlayerCard6;
        private Panel pnlPlayerCard7;
        private Panel pnlPlayerCard8;
        private Panel pnlPlayerCard9;
        private Panel pnlPlayerCard10;
        private Panel pnlPlayerCard11;
        private GroupBox groupPlayerCards;
        private GroupBox groupDealerCards;
        private Panel pnlDealerCard1;
        private Panel pnlDealerCard11;
        private Panel pnlDealerCard2;
        private Panel pnlDealerCard10;
        private Panel pnlDealerCard5;
        private Panel pnlDealerCard9;
        private Panel pnlDealerCard3;
        private Panel pnlDealerCard8;
        private Panel pnlDealerCard4;
        private Panel pnlDealerCard7;
        private Panel pnlDealerCard6;
        private ToolTip tipExit;
        private Button btnResetBet;
        private ToolTip tipResetBet;
        private Label lblDealerHand;
        private Label lblPlayerHand;
    }
}