namespace ReadFromPlayers
{
    partial class frmNewScore
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblPlayerID = new System.Windows.Forms.Label();
            this.playerID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(394, 217);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(179, 41);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(145, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 41);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(427, 94);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(237, 26);
            this.txtDate.TabIndex = 34;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(423, 61);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(66, 30);
            this.lblDate.TabIndex = 33;
            this.lblDate.Text = "Date";
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(145, 94);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(237, 26);
            this.txtScore.TabIndex = 32;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(141, 61);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(77, 30);
            this.lblScore.TabIndex = 31;
            this.lblScore.Text = "Score";
            // 
            // lblPlayerID
            // 
            this.lblPlayerID.AutoSize = true;
            this.lblPlayerID.Location = new System.Drawing.Point(21, 100);
            this.lblPlayerID.Name = "lblPlayerID";
            this.lblPlayerID.Size = new System.Drawing.Size(26, 20);
            this.lblPlayerID.TabIndex = 41;
            this.lblPlayerID.Text = "ID";
            // 
            // playerID
            // 
            this.playerID.AutoSize = true;
            this.playerID.Location = new System.Drawing.Point(21, 61);
            this.playerID.Name = "playerID";
            this.playerID.Size = new System.Drawing.Size(68, 20);
            this.playerID.TabIndex = 42;
            this.playerID.Text = "playerID";
            // 
            // frmNewScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 816);
            this.Controls.Add(this.playerID);
            this.Controls.Add(this.lblPlayerID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.lblScore);
            this.Name = "frmNewScore";
            this.Text = "NewScore";
            this.Load += new System.EventHandler(this.frmNewScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPlayerID;
        private System.Windows.Forms.Label playerID;
    }
}