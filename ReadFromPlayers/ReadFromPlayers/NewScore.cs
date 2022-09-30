using ClassLibraryPlayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromPlayers
{
    public partial class frmNewScore : Form
    {
        // private var
        private string playerSId = "";

        // get sId
        public string playerSID
        {
            get { return playerSId; }
        }

        // Constructor
        public frmNewScore(string sId)
        {
            // set sId
            playerSId = sId;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sId = playerSID;
            string sScore = txtScore.Text;
            string sDate = txtDate.Text;

            // Create a new DataHandling obj
            DataHandling nScore = new DataHandling();

            // Check that score and date is not empty
            if (txtScore.Text != "" && txtDate.Text != "")
            {
                // Check if the score is a number and it is positive
                if (sScore.All(char.IsDigit) && Convert.ToInt32(sScore) >= 0)
                {
                    // Check date correct format yyyy-mm-dd or yyyy-mm-dd hh:mm:ss
                    if (sDate.Length == 10 || sDate.Length == 19)
                    {
                        if (sDate[4] == '-' && sDate[7] == '-')
                        {
                            if (sDate.Length == 19)
                            {
                                if (sDate[10] == ' ' && sDate[13] == ':' && sDate[16] == ':')
                                {
                                    // Save the new score
                                    nScore.addScore(sId, sScore, sDate);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please enter a valid date format yyyy-mm-dd hh:mm:ss or yyyy-mm-dd");
                                    return;
                                }
                            }
                            else
                            {
                                // Save the new score
                                nScore.addScore(sId, sScore, sDate);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid date format yyyy-mm-dd hh:mm:ss or yyyy-mm-dd");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid date format yyyy-mm-dd hh:mm:ss or yyyy-mm-dd");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid >= 0 score or date format yyyy-mm-dd hh:mm:ss or yyyy-mm-dd");
                    return;
                }

                // Check for errors
                if (nScore.Err != "0")
                {
                    MessageBox.Show(nScore.Err);
                    return;
                }

                clearForm();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a score and date");
            }
        }

        private void clearForm()
        {
            txtDate.Text = "";
            txtScore.Text = "";
            lblPlayerID.Text = "";
        }

        private void frmNewScore_Load(object sender, EventArgs e)
        {
            // set the player id as form loads
            lblPlayerID.Text = playerSID;
        }
    }
}
