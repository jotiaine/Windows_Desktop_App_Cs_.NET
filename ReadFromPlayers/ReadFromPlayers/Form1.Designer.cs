namespace ReadFromPlayers
{
    partial class Form1
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
            this.btnSpecificHistory = new System.Windows.Forms.Button();
            this.dtPickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dtPickerStart = new System.Windows.Forms.DateTimePicker();
            this.btnClearLstBox = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnRanking = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewPlayer = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.cmbPlayers = new System.Windows.Forms.ComboBox();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.btnSpecificHistoryAllPlayers = new System.Windows.Forms.Button();
            this.dtPickerEndAllPlayers = new System.Windows.Forms.DateTimePicker();
            this.dtPickerStartAllPlayers = new System.Windows.Forms.DateTimePicker();
            this.btnNewScore = new System.Windows.Forms.Button();
            this.cmbDates = new System.Windows.Forms.ComboBox();
            this.pickDate = new System.Windows.Forms.Label();
            this.btnRankingPDF = new System.Windows.Forms.Button();
            this.btnScoreHistoryPDF = new System.Windows.Forms.Button();
            this.btnPlayerTLPDF = new System.Windows.Forms.Button();
            this.btnPlayersTLPDF = new System.Windows.Forms.Button();
            this.btnRankingTLPDF = new System.Windows.Forms.Button();
            this.btnRankingTL = new System.Windows.Forms.Button();
            this.dtPickerRankingEnd = new System.Windows.Forms.DateTimePicker();
            this.dtPickerRankingStart = new System.Windows.Forms.DateTimePicker();
            this.btnInitForm = new System.Windows.Forms.Button();
            this.btnSelectedPlayerRankingPDF = new System.Windows.Forms.Button();
            this.btnSelectedPlayerRanking = new System.Windows.Forms.Button();
            this.btnSelectedPlayerRankingOnTLPDF = new System.Windows.Forms.Button();
            this.btnSelectedPlayerRankingOnTL = new System.Windows.Forms.Button();
            this.dtPickerPlayerRankTLEnd = new System.Windows.Forms.DateTimePicker();
            this.dtPickerPlayerRankTLStart = new System.Windows.Forms.DateTimePicker();
            this.btnLstPlayers = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSpecificHistory
            // 
            this.btnSpecificHistory.Location = new System.Drawing.Point(1192, 381);
            this.btnSpecificHistory.Name = "btnSpecificHistory";
            this.btnSpecificHistory.Size = new System.Drawing.Size(177, 77);
            this.btnSpecificHistory.TabIndex = 53;
            this.btnSpecificHistory.Text = "Player\'s History on a Timeline";
            this.btnSpecificHistory.UseVisualStyleBackColor = true;
            this.btnSpecificHistory.Click += new System.EventHandler(this.btnSpecificHistory_Click_1);
            // 
            // dtPickerEnd
            // 
            this.dtPickerEnd.Location = new System.Drawing.Point(896, 421);
            this.dtPickerEnd.Name = "dtPickerEnd";
            this.dtPickerEnd.Size = new System.Drawing.Size(282, 26);
            this.dtPickerEnd.TabIndex = 52;
            this.dtPickerEnd.ValueChanged += new System.EventHandler(this.dtPickerEnd_ValueChanged_1);
            // 
            // dtPickerStart
            // 
            this.dtPickerStart.Location = new System.Drawing.Point(896, 391);
            this.dtPickerStart.Name = "dtPickerStart";
            this.dtPickerStart.Size = new System.Drawing.Size(282, 26);
            this.dtPickerStart.TabIndex = 51;
            this.dtPickerStart.ValueChanged += new System.EventHandler(this.dtPickerStart_ValueChanged_1);
            // 
            // btnClearLstBox
            // 
            this.btnClearLstBox.Location = new System.Drawing.Point(1521, 240);
            this.btnClearLstBox.Name = "btnClearLstBox";
            this.btnClearLstBox.Size = new System.Drawing.Size(177, 77);
            this.btnClearLstBox.TabIndex = 50;
            this.btnClearLstBox.Text = "Clear List Box";
            this.btnClearLstBox.UseVisualStyleBackColor = true;
            this.btnClearLstBox.Click += new System.EventHandler(this.btnClearLstBox_Click_1);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(1937, 16);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(177, 77);
            this.btnHistory.TabIndex = 49;
            this.btnHistory.Text = "Show Scores History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click_1);
            // 
            // btnRanking
            // 
            this.btnRanking.Location = new System.Drawing.Point(1521, 16);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(177, 77);
            this.btnRanking.TabIndex = 48;
            this.btnRanking.Text = "List Current Ranking Situation";
            this.btnRanking.UseVisualStyleBackColor = true;
            this.btnRanking.Click += new System.EventHandler(this.btnRanking_Click_1);
            // 
            // lstBox
            // 
            this.lstBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.lstBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lstBox.FormattingEnabled = true;
            this.lstBox.ItemHeight = 20;
            this.lstBox.Location = new System.Drawing.Point(896, 12);
            this.lstBox.Name = "lstBox";
            this.lstBox.ScrollAlwaysVisible = true;
            this.lstBox.Size = new System.Drawing.Size(602, 344);
            this.lstBox.TabIndex = 47;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(302, 291);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(158, 26);
            this.txtDate.TabIndex = 46;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(1614, 154);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 20);
            this.lblDate.TabIndex = 45;
            this.lblDate.Text = "Date";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(111, 291);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(158, 26);
            this.txtScore.TabIndex = 44;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(1021, 135);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(51, 20);
            this.lblScore.TabIndex = 43;
            this.lblScore.Text = "Score";
            // 
            // btnPDF
            // 
            this.btnPDF.AutoSize = true;
            this.btnPDF.Location = new System.Drawing.Point(301, 473);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(186, 62);
            this.btnPDF.TabIndex = 42;
            this.btnPDF.Text = "Players to PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(519, 392);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 41);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnNewPlayer
            // 
            this.btnNewPlayer.Location = new System.Drawing.Point(82, 392);
            this.btnNewPlayer.Name = "btnNewPlayer";
            this.btnNewPlayer.Size = new System.Drawing.Size(141, 41);
            this.btnNewPlayer.TabIndex = 40;
            this.btnNewPlayer.Text = "New Player";
            this.btnNewPlayer.UseVisualStyleBackColor = true;
            this.btnNewPlayer.Click += new System.EventHandler(this.btnNewPlayer_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(388, 392);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 41);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(639, 392);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 41);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(671, 139);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(158, 26);
            this.txtPwd.TabIndex = 37;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(674, 108);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(78, 20);
            this.lblPwd.TabIndex = 36;
            this.lblPwd.Text = "Password";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(487, 140);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(158, 26);
            this.txtEmail.TabIndex = 35;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(489, 108);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 34;
            this.lblEmail.Text = "Email";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(301, 140);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(158, 26);
            this.txtFirstName.TabIndex = 33;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(297, 109);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(84, 20);
            this.lblFirstName.TabIndex = 32;
            this.lblFirstName.Text = "First name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(113, 140);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(158, 26);
            this.txtLastName.TabIndex = 31;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(109, 109);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(84, 20);
            this.lblLastName.TabIndex = 30;
            this.lblLastName.Text = "Last name";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(404, 65);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 20);
            this.lblID.TabIndex = 29;
            this.lblID.Text = "ID";
            // 
            // cmbPlayers
            // 
            this.cmbPlayers.FormattingEnabled = true;
            this.cmbPlayers.Location = new System.Drawing.Point(113, 65);
            this.cmbPlayers.Name = "cmbPlayers";
            this.cmbPlayers.Size = new System.Drawing.Size(285, 28);
            this.cmbPlayers.TabIndex = 28;
            this.cmbPlayers.SelectedIndexChanged += new System.EventHandler(this.cmbPlayers_SelectedIndexChanged_1);
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(109, 32);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(60, 20);
            this.lblPlayers.TabIndex = 27;
            this.lblPlayers.Text = "Players";
            // 
            // btnSpecificHistoryAllPlayers
            // 
            this.btnSpecificHistoryAllPlayers.Location = new System.Drawing.Point(1192, 497);
            this.btnSpecificHistoryAllPlayers.Name = "btnSpecificHistoryAllPlayers";
            this.btnSpecificHistoryAllPlayers.Size = new System.Drawing.Size(177, 77);
            this.btnSpecificHistoryAllPlayers.TabIndex = 56;
            this.btnSpecificHistoryAllPlayers.Text = "Players\' History on a Timeline";
            this.btnSpecificHistoryAllPlayers.UseVisualStyleBackColor = true;
            this.btnSpecificHistoryAllPlayers.Click += new System.EventHandler(this.btnSpecificHistoryAllPlayers_Click);
            // 
            // dtPickerEndAllPlayers
            // 
            this.dtPickerEndAllPlayers.Location = new System.Drawing.Point(896, 540);
            this.dtPickerEndAllPlayers.Name = "dtPickerEndAllPlayers";
            this.dtPickerEndAllPlayers.Size = new System.Drawing.Size(282, 26);
            this.dtPickerEndAllPlayers.TabIndex = 55;
            this.dtPickerEndAllPlayers.ValueChanged += new System.EventHandler(this.dtPickerEndAllPlayers_ValueChanged);
            // 
            // dtPickerStartAllPlayers
            // 
            this.dtPickerStartAllPlayers.Location = new System.Drawing.Point(896, 509);
            this.dtPickerStartAllPlayers.Name = "dtPickerStartAllPlayers";
            this.dtPickerStartAllPlayers.Size = new System.Drawing.Size(282, 26);
            this.dtPickerStartAllPlayers.TabIndex = 54;
            this.dtPickerStartAllPlayers.ValueChanged += new System.EventHandler(this.dtPickerStartAllPlayers_ValueChanged);
            // 
            // btnNewScore
            // 
            this.btnNewScore.Location = new System.Drawing.Point(246, 392);
            this.btnNewScore.Name = "btnNewScore";
            this.btnNewScore.Size = new System.Drawing.Size(119, 41);
            this.btnNewScore.TabIndex = 57;
            this.btnNewScore.Text = "New Score";
            this.btnNewScore.UseVisualStyleBackColor = true;
            this.btnNewScore.Click += new System.EventHandler(this.btnNewScore_Click);
            // 
            // cmbDates
            // 
            this.cmbDates.FormattingEnabled = true;
            this.cmbDates.Location = new System.Drawing.Point(113, 220);
            this.cmbDates.Name = "cmbDates";
            this.cmbDates.Size = new System.Drawing.Size(123, 28);
            this.cmbDates.TabIndex = 59;
            this.cmbDates.SelectedIndexChanged += new System.EventHandler(this.cmbDates_SelectedIndexChanged);
            // 
            // pickDate
            // 
            this.pickDate.AutoSize = true;
            this.pickDate.Location = new System.Drawing.Point(109, 185);
            this.pickDate.Name = "pickDate";
            this.pickDate.Size = new System.Drawing.Size(90, 20);
            this.pickDate.TabIndex = 58;
            this.pickDate.Text = "Pick a Date";
            // 
            // btnRankingPDF
            // 
            this.btnRankingPDF.Location = new System.Drawing.Point(1521, 128);
            this.btnRankingPDF.Name = "btnRankingPDF";
            this.btnRankingPDF.Size = new System.Drawing.Size(177, 77);
            this.btnRankingPDF.TabIndex = 60;
            this.btnRankingPDF.Text = "Get PDF";
            this.btnRankingPDF.UseVisualStyleBackColor = true;
            this.btnRankingPDF.Click += new System.EventHandler(this.btnRankingPDF_Click);
            // 
            // btnScoreHistoryPDF
            // 
            this.btnScoreHistoryPDF.Location = new System.Drawing.Point(1937, 128);
            this.btnScoreHistoryPDF.Name = "btnScoreHistoryPDF";
            this.btnScoreHistoryPDF.Size = new System.Drawing.Size(177, 77);
            this.btnScoreHistoryPDF.TabIndex = 61;
            this.btnScoreHistoryPDF.Text = "Get PDF";
            this.btnScoreHistoryPDF.UseVisualStyleBackColor = true;
            this.btnScoreHistoryPDF.Click += new System.EventHandler(this.btnScoreHistoryPDF_Click);
            // 
            // btnPlayerTLPDF
            // 
            this.btnPlayerTLPDF.Location = new System.Drawing.Point(1394, 381);
            this.btnPlayerTLPDF.Name = "btnPlayerTLPDF";
            this.btnPlayerTLPDF.Size = new System.Drawing.Size(177, 77);
            this.btnPlayerTLPDF.TabIndex = 62;
            this.btnPlayerTLPDF.Text = "Get PDF";
            this.btnPlayerTLPDF.UseVisualStyleBackColor = true;
            this.btnPlayerTLPDF.Click += new System.EventHandler(this.btnPlayerTLPDF_Click);
            // 
            // btnPlayersTLPDF
            // 
            this.btnPlayersTLPDF.Location = new System.Drawing.Point(1394, 497);
            this.btnPlayersTLPDF.Name = "btnPlayersTLPDF";
            this.btnPlayersTLPDF.Size = new System.Drawing.Size(177, 77);
            this.btnPlayersTLPDF.TabIndex = 63;
            this.btnPlayersTLPDF.Text = "Get PDF";
            this.btnPlayersTLPDF.UseVisualStyleBackColor = true;
            this.btnPlayersTLPDF.Click += new System.EventHandler(this.btnPlayersTLPDF_Click);
            // 
            // btnRankingTLPDF
            // 
            this.btnRankingTLPDF.Location = new System.Drawing.Point(1394, 606);
            this.btnRankingTLPDF.Name = "btnRankingTLPDF";
            this.btnRankingTLPDF.Size = new System.Drawing.Size(177, 77);
            this.btnRankingTLPDF.TabIndex = 67;
            this.btnRankingTLPDF.Text = "Get PDF";
            this.btnRankingTLPDF.UseVisualStyleBackColor = true;
            this.btnRankingTLPDF.Click += new System.EventHandler(this.btnRankingTLPDF_Click);
            // 
            // btnRankingTL
            // 
            this.btnRankingTL.Location = new System.Drawing.Point(1192, 606);
            this.btnRankingTL.Name = "btnRankingTL";
            this.btnRankingTL.Size = new System.Drawing.Size(177, 77);
            this.btnRankingTL.TabIndex = 66;
            this.btnRankingTL.Text = "Ranking Situation on a Timeline";
            this.btnRankingTL.UseVisualStyleBackColor = true;
            this.btnRankingTL.Click += new System.EventHandler(this.btnRankingTL_Click);
            // 
            // dtPickerRankingEnd
            // 
            this.dtPickerRankingEnd.Location = new System.Drawing.Point(896, 649);
            this.dtPickerRankingEnd.Name = "dtPickerRankingEnd";
            this.dtPickerRankingEnd.Size = new System.Drawing.Size(282, 26);
            this.dtPickerRankingEnd.TabIndex = 65;
            this.dtPickerRankingEnd.ValueChanged += new System.EventHandler(this.dtPickerRankingEnd_ValueChanged);
            // 
            // dtPickerRankingStart
            // 
            this.dtPickerRankingStart.Location = new System.Drawing.Point(896, 618);
            this.dtPickerRankingStart.Name = "dtPickerRankingStart";
            this.dtPickerRankingStart.Size = new System.Drawing.Size(282, 26);
            this.dtPickerRankingStart.TabIndex = 64;
            this.dtPickerRankingStart.ValueChanged += new System.EventHandler(this.dtPickerRankingStart_ValueChanged);
            // 
            // btnInitForm
            // 
            this.btnInitForm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnInitForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInitForm.Location = new System.Drawing.Point(93, 605);
            this.btnInitForm.Name = "btnInitForm";
            this.btnInitForm.Size = new System.Drawing.Size(623, 113);
            this.btnInitForm.TabIndex = 68;
            this.btnInitForm.Text = "Empty db tables and init form";
            this.btnInitForm.UseVisualStyleBackColor = false;
            this.btnInitForm.Click += new System.EventHandler(this.btnInitForm_Click);
            // 
            // btnSelectedPlayerRankingPDF
            // 
            this.btnSelectedPlayerRankingPDF.Location = new System.Drawing.Point(1734, 128);
            this.btnSelectedPlayerRankingPDF.Name = "btnSelectedPlayerRankingPDF";
            this.btnSelectedPlayerRankingPDF.Size = new System.Drawing.Size(177, 77);
            this.btnSelectedPlayerRankingPDF.TabIndex = 70;
            this.btnSelectedPlayerRankingPDF.Text = "Get PDF";
            this.btnSelectedPlayerRankingPDF.UseVisualStyleBackColor = true;
            this.btnSelectedPlayerRankingPDF.Click += new System.EventHandler(this.btnSelectedPlayerRankingPDF_Click);
            // 
            // btnSelectedPlayerRanking
            // 
            this.btnSelectedPlayerRanking.Location = new System.Drawing.Point(1734, 16);
            this.btnSelectedPlayerRanking.Name = "btnSelectedPlayerRanking";
            this.btnSelectedPlayerRanking.Size = new System.Drawing.Size(177, 77);
            this.btnSelectedPlayerRanking.TabIndex = 69;
            this.btnSelectedPlayerRanking.Text = "Selected Player\'s Current Ranking";
            this.btnSelectedPlayerRanking.UseVisualStyleBackColor = true;
            this.btnSelectedPlayerRanking.Click += new System.EventHandler(this.btnSelectedPlayerRanking_Click_1);
            // 
            // btnSelectedPlayerRankingOnTLPDF
            // 
            this.btnSelectedPlayerRankingOnTLPDF.Location = new System.Drawing.Point(1394, 742);
            this.btnSelectedPlayerRankingOnTLPDF.Name = "btnSelectedPlayerRankingOnTLPDF";
            this.btnSelectedPlayerRankingOnTLPDF.Size = new System.Drawing.Size(177, 77);
            this.btnSelectedPlayerRankingOnTLPDF.TabIndex = 74;
            this.btnSelectedPlayerRankingOnTLPDF.Text = "Get PDF";
            this.btnSelectedPlayerRankingOnTLPDF.UseVisualStyleBackColor = true;
            this.btnSelectedPlayerRankingOnTLPDF.Click += new System.EventHandler(this.btnSelectedPlayerRankingOnTLPDF_Click);
            // 
            // btnSelectedPlayerRankingOnTL
            // 
            this.btnSelectedPlayerRankingOnTL.Location = new System.Drawing.Point(1192, 742);
            this.btnSelectedPlayerRankingOnTL.Name = "btnSelectedPlayerRankingOnTL";
            this.btnSelectedPlayerRankingOnTL.Size = new System.Drawing.Size(177, 77);
            this.btnSelectedPlayerRankingOnTL.TabIndex = 73;
            this.btnSelectedPlayerRankingOnTL.Text = "Selected Player\'s ranking on a Timeline";
            this.btnSelectedPlayerRankingOnTL.UseVisualStyleBackColor = true;
            this.btnSelectedPlayerRankingOnTL.Click += new System.EventHandler(this.btnSelectedPlayerRankingOnTL_Click);
            // 
            // dtPickerPlayerRankTLEnd
            // 
            this.dtPickerPlayerRankTLEnd.Location = new System.Drawing.Point(896, 785);
            this.dtPickerPlayerRankTLEnd.Name = "dtPickerPlayerRankTLEnd";
            this.dtPickerPlayerRankTLEnd.Size = new System.Drawing.Size(282, 26);
            this.dtPickerPlayerRankTLEnd.TabIndex = 72;
            this.dtPickerPlayerRankTLEnd.ValueChanged += new System.EventHandler(this.dtPickerPlayerRankTLEnd_ValueChanged);
            // 
            // dtPickerPlayerRankTLStart
            // 
            this.dtPickerPlayerRankTLStart.Location = new System.Drawing.Point(896, 754);
            this.dtPickerPlayerRankTLStart.Name = "dtPickerPlayerRankTLStart";
            this.dtPickerPlayerRankTLStart.Size = new System.Drawing.Size(282, 26);
            this.dtPickerPlayerRankTLStart.TabIndex = 71;
            this.dtPickerPlayerRankTLStart.ValueChanged += new System.EventHandler(this.dtPickerPlayerRankTLStart_ValueChanged);
            // 
            // btnLstPlayers
            // 
            this.btnLstPlayers.AutoSize = true;
            this.btnLstPlayers.Location = new System.Drawing.Point(83, 473);
            this.btnLstPlayers.Name = "btnLstPlayers";
            this.btnLstPlayers.Size = new System.Drawing.Size(186, 62);
            this.btnLstPlayers.TabIndex = 75;
            this.btnLstPlayers.Text = "List Players to listbox";
            this.btnLstPlayers.UseVisualStyleBackColor = true;
            this.btnLstPlayers.Click += new System.EventHandler(this.btnLstPlayers_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtInfo.Location = new System.Drawing.Point(436, 62);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(393, 26);
            this.txtInfo.TabIndex = 76;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2259, 968);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnLstPlayers);
            this.Controls.Add(this.btnSelectedPlayerRankingOnTLPDF);
            this.Controls.Add(this.btnSelectedPlayerRankingOnTL);
            this.Controls.Add(this.dtPickerPlayerRankTLEnd);
            this.Controls.Add(this.dtPickerPlayerRankTLStart);
            this.Controls.Add(this.btnSelectedPlayerRankingPDF);
            this.Controls.Add(this.btnSelectedPlayerRanking);
            this.Controls.Add(this.btnInitForm);
            this.Controls.Add(this.btnRankingTLPDF);
            this.Controls.Add(this.btnRankingTL);
            this.Controls.Add(this.dtPickerRankingEnd);
            this.Controls.Add(this.dtPickerRankingStart);
            this.Controls.Add(this.btnPlayersTLPDF);
            this.Controls.Add(this.btnPlayerTLPDF);
            this.Controls.Add(this.btnScoreHistoryPDF);
            this.Controls.Add(this.btnRankingPDF);
            this.Controls.Add(this.cmbDates);
            this.Controls.Add(this.pickDate);
            this.Controls.Add(this.btnNewScore);
            this.Controls.Add(this.btnSpecificHistoryAllPlayers);
            this.Controls.Add(this.dtPickerEndAllPlayers);
            this.Controls.Add(this.dtPickerStartAllPlayers);
            this.Controls.Add(this.btnSpecificHistory);
            this.Controls.Add(this.dtPickerEnd);
            this.Controls.Add(this.dtPickerStart);
            this.Controls.Add(this.btnClearLstBox);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnRanking);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNewPlayer);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.cmbPlayers);
            this.Controls.Add(this.lblPlayers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpecificHistory;
        private System.Windows.Forms.DateTimePicker dtPickerEnd;
        private System.Windows.Forms.DateTimePicker dtPickerStart;
        private System.Windows.Forms.Button btnClearLstBox;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnRanking;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewPlayer;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cmbPlayers;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Button btnSpecificHistoryAllPlayers;
        private System.Windows.Forms.DateTimePicker dtPickerEndAllPlayers;
        private System.Windows.Forms.DateTimePicker dtPickerStartAllPlayers;
        private System.Windows.Forms.Button btnNewScore;
        private System.Windows.Forms.ComboBox cmbDates;
        private System.Windows.Forms.Label pickDate;
        private System.Windows.Forms.Button btnRankingPDF;
        private System.Windows.Forms.Button btnScoreHistoryPDF;
        private System.Windows.Forms.Button btnPlayerTLPDF;
        private System.Windows.Forms.Button btnPlayersTLPDF;
        private System.Windows.Forms.Button btnRankingTLPDF;
        private System.Windows.Forms.Button btnRankingTL;
        private System.Windows.Forms.DateTimePicker dtPickerRankingEnd;
        private System.Windows.Forms.DateTimePicker dtPickerRankingStart;
        private System.Windows.Forms.Button btnInitForm;
        private System.Windows.Forms.Button btnSelectedPlayerRankingPDF;
        private System.Windows.Forms.Button btnSelectedPlayerRanking;
        private System.Windows.Forms.Button btnSelectedPlayerRankingOnTLPDF;
        private System.Windows.Forms.Button btnSelectedPlayerRankingOnTL;
        private System.Windows.Forms.DateTimePicker dtPickerPlayerRankTLEnd;
        private System.Windows.Forms.DateTimePicker dtPickerPlayerRankTLStart;
        private System.Windows.Forms.Button btnLstPlayers;
        private System.Windows.Forms.TextBox txtInfo;
    }
}

