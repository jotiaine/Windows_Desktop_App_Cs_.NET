using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClassLibraryPlayers;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.StyledXmlParser.Jsoup.Nodes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Document = iText.Layout.Document;

namespace ReadFromPlayers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadCombo();
        }

        private void loadCombo()
        {            
            // Disable dmbDates, txtScore and txtDate
            cmbDates.Enabled = false;
            txtScore.Enabled = false;
            txtDate.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtEmail.Enabled = false;
            txtPwd.Enabled = false;

            // clear cmbDates
            cmbDates.Items.Clear();

            // clear
            txtScore.Text = "";
            txtDate.Text = "";

            // hide txtInfo
            txtInfo.Visible = false;
            txtInfo.Enabled = false;

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getPlayers();

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // If rows are 0, message
            if (stuff.Dt.Rows.Count == 0)
            {
                // cmbPlayer unclickable
                cmbPlayers.Enabled = false;

                // txtInfo visible with info text
                txtInfo.Visible = true;
                txtInfo.Text = "No players found. Please start by adding players first.";

                return;
            }
            else
            {
                // cmbPlayer clickable
                cmbPlayers.Enabled = true;

                // txtInfo invisible
                txtInfo.Visible = false;
            }

            // For loop the data into the cmbPlayers combobox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // cmbPlayers
                cmbPlayers.Items.Add(row["playerID"] + " " + row["firstname"] + " " + row["lastname"]);
            }
        }

        private void clearForm()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtEmail.Text = "";
            txtPwd.Text = "";
            cmbPlayers.Text = "";
            cmbDates.Text = "";
            lblID.Text = "ID";
            txtScore.Text = "";
            txtDate.Text = "";
            cmbDates.Items.Clear();
            lstBox.Items.Clear();

            // Disable cmbDates, txtScore and txtDate, txtFirstname, txtLastname, txtEmail and txtPwd
            cmbDates.Enabled = false;
            txtScore.Enabled = false;
            txtDate.Enabled = false;

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtEmail.Enabled = false;
            txtPwd.Enabled = false;
        }

        private void btnNewPlayer_Click(object sender, EventArgs e)
        {      
            // Create a new player form
            var newPlayer = new frmNewPlayer();

            // show dialog
            newPlayer.ShowDialog();

            // Clear the form
            clearForm();
            // Clear cmbPlayer
            cmbPlayers.Items.Clear();
            // Load updated players
            loadCombo();
        }

        private void btnNewScore_Click(object sender, EventArgs e)
        {
            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Select a player first");
                return;
            }

            // Create a new score form and send lblID there
            var newScore = new frmNewScore(lblID.Text);

            // show dialog
            newScore.ShowDialog();

            // Clear the form
            clearForm();
            // Clear cmbPlayer
            cmbPlayers.Items.Clear();
            // Load updated players
            loadCombo();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // vars
            string sFirstname = txtFirstName.Text;
            string sLastname = txtLastName.Text;
            string sEmail = txtEmail.Text;
            string sPwd = txtPwd.Text;
            string sScore = txtScore.Text;
            string sDate = txtDate.Text;
            string sId = lblID.Text;

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if the user has entered all fields
            if (sFirstname == "" || sLastname == "" || sEmail == "" || sPwd == "")
            {
                MessageBox.Show("Please enter all fields");
                return;
            }

            // Check that firstname and lastname are not numbers and they have a capital letter (I guess some names can have numbers...)
            if (sFirstname.All(char.IsDigit) || sLastname.All(char.IsDigit) || !char.IsUpper(sFirstname[0]) || !char.IsUpper(sLastname[0]))
            {
                MessageBox.Show("Please enter a valid name");
                return;
            }

            // Check if the email is valid and is all lowercased
            if (!sEmail.Contains("@") || !sEmail.Contains(".") || sEmail != sEmail.ToLower())
            {
                MessageBox.Show("Please enter a valid email");
                return;
            }

            // Check if the password is valid and contains at least 1 number, 1 uppercase letter and at least 1 lowercase letter
            if (sPwd.Length < 8 || !sPwd.Any(char.IsDigit) || !sPwd.Any(char.IsUpper) || !sPwd.Any(char.IsLower))
            {
                MessageBox.Show("Please enter a valid password");
                return;
            }           

            // Create a new DataHandling object
            DataHandling uPlayer = new DataHandling();

            // if date is not selected update only player table, else update both tables
            if (cmbDates.SelectedIndex == -1)
            {
                // call method to check if email exist with another player
                uPlayer.checkIfEmailExistsWithAnother(sId, sEmail);
                
                // Check if found
                if (uPlayer.Found == 1)
                {
                    MessageBox.Show("This email is already in use with another player");
                    txtEmail.Text = "";
                    return;
                }
                
                // Call the updatePlayerTable method
                uPlayer.updatePlayerTable(lblID.Text, sLastname, sFirstname, sEmail, sPwd);
            }
            else
            {
                // The selected date
                string selectedDate = cmbDates.SelectedItem.ToString();
                
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
                                        uPlayer.updatePlayer(sId, sLastname, sFirstname, sEmail, sPwd, sScore, sDate, selectedDate);
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
                                    uPlayer.updatePlayer(sId, sLastname, sFirstname, sEmail, sPwd, sScore, sDate, selectedDate);
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
                }
                else
                {
                    MessageBox.Show("Please enter a score and date");
                }
            }

            // Check if there are any errors
            if (uPlayer.Err != "0")
            {
                MessageBox.Show(uPlayer.Err);
                return;
            }

            // Messagebox
            MessageBox.Show("Player information updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form
            clearForm();
            // Clear cmbPlayer
            cmbPlayers.Items.Clear();
            // Clear cmbDates
            cmbDates.Items.Clear();
            // Load updated players
            loadCombo();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if cmbDates is selected
            string selectedDate = "";
            if (cmbDates.Text == "")
            {
                MessageBox.Show("Please select a date if you want to delete a specific score and if dates are empty, create new score");
            }
            else
            {
                selectedDate = cmbDates.SelectedItem.ToString();
            }

            // Ask confirmation from the user
            if (MessageBox.Show("Are you sure you want to delete the player/score", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            else
            {
                // if selectedDate is empty, delete the player else delete specific score
                if (selectedDate == "")
                {
                    // Create a new DataHandling obj
                    DataHandling dPlayer = new DataHandling();

                    // Call deletePlayer method
                    dPlayer.deletePlayer(lblID.Text);

                    // Check if there are any errors
                    if (dPlayer.Err != "0")
                    {
                        MessageBox.Show(dPlayer.Err);
                        return;
                    }

                    // Messagebox
                    MessageBox.Show("The player and all his/her scores has been deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Create a new DataHandling obj
                    DataHandling dScore = new DataHandling();

                    // Call deleteScore method
                    dScore.deleteScore(lblID.Text, selectedDate);

                    // Check if there are any errors
                    if (dScore.Err != "0")
                    {
                        MessageBox.Show(dScore.Err);
                        return;
                    }

                    // Messagebox
                    MessageBox.Show("The score has been deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }             
                
                // Clear the form
                clearForm();
                // Clear cmbPlayer
                cmbPlayers.Items.Clear();
                // Load updated players
                loadCombo();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnPDF_Click_1(object sender, EventArgs e)
        {
            string folder = "MyPDF";

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getPlayers();

            // Check errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // If rows are 0, message
            if (stuff.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("PLAYERS").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);

            document.Add(header);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Create a new Paragraph obj
                Paragraph p = new Paragraph("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "email: " + row["email"] + ", " + "password: " + row["pwd"]);

                document.Add(p);
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void cmbPlayers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Enable player textboxes
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtEmail.Enabled = true;
            txtPwd.Enabled = true;
            
            // Enable cmbDates
            cmbDates.Enabled = true;

            // Empty cmbDates, txtScore, txtDate, lstBox
            cmbDates.Items.Clear();
            cmbDates.Text = "";
            txtScore.Text = "";
            txtDate.Text = "";
            lstBox.Items.Clear();

            string sId, sCmb;

            // Get the selected item from the combobox
            sCmb = cmbPlayers.SelectedItem.ToString();
            // first index is the playerID     
            sId = sCmb.Split(' ')[0];

            // set lblID text to sId
            lblID.Text = sId;

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();
            stuff.getPlayer(sId);

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
            }

            // First row
            DataRow row = stuff.Dt.Rows[0];

            // Set textbox values based on query
            txtLastName.Text = row["lastname"].ToString();
            txtFirstName.Text = row["firstname"].ToString();
            txtEmail.Text = row["email"].ToString();
            txtPwd.Text = row["pwd"].ToString();

            // Create a new DataHandling object
            DataHandling stuff2 = new DataHandling();

            // Call the getScores method
            stuff2.getScores(sId);

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // if scores are empty, disable cmbDates and make a messagebox
            if (stuff2.Dt.Rows.Count == 0)
            {
                cmbDates.Enabled = false;
                MessageBox.Show("There are no scores for this player, you can add scores for the players");
            }
            else
            {
                // Loop scores to the combobox
                for (int i = 0; i < stuff2.Dt.Rows.Count; i++)
                {
                    // One row
                    DataRow row2 = stuff2.Dt.Rows[i];

                    // Add score to the combobox
                    cmbDates.Items.Add(row2["date"]);
                }
            }
        }

        private void btnRanking_Click_1(object sender, EventArgs e)
        {
            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
            
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getPlayersRanking();

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "totalscore: " + row["totalscore"]);
            }
        }

        private void btnHistory_Click_1(object sender, EventArgs e)
        {
            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayersHistory method
            stuff.getPlayersHistory();

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + ", " + "date: " + row["date"]);
            }
        }

        private void btnClearLstBox_Click_1(object sender, EventArgs e)
        {
            // Empty the lstBox
            lstBox.Items.Clear();
        }

        private void btnSpecificHistory_Click_1(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }      

            // Check if the date is in the future
            if (dtPickerStart.Value > DateTime.Now || dtPickerEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayersHistorySpecific method
            stuff.getPlayersHistorySpecific(lblID.Text, dtPickerStart.Value.ToString("yyyy-MM-dd 00:00:00"), dtPickerEnd.Value.ToString("yyyy-MM-dd 23:59:59"));

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + ", " + "date: " + row["date"]);
            }
        }

        private void dtPickerStart_ValueChanged_1(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if the date is in the future
            if (dtPickerStart.Value > DateTime.Now || dtPickerEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void dtPickerEnd_ValueChanged_1(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if the date is in the future
            if (dtPickerStart.Value > DateTime.Now || dtPickerEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void dtPickerStartAllPlayers_ValueChanged(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if the date is in the future
            if (dtPickerStartAllPlayers.Value > DateTime.Now || dtPickerEndAllPlayers.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void dtPickerEndAllPlayers_ValueChanged(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if the date is in the future
            if (dtPickerStartAllPlayers.Value > DateTime.Now || dtPickerEndAllPlayers.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void btnSpecificHistoryAllPlayers_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if the date is in the future
            if (dtPickerStartAllPlayers.Value > DateTime.Now || dtPickerEndAllPlayers.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayersHistorySpecific method
            stuff.getAllPlayersHistorySpecific(dtPickerStartAllPlayers.Value.ToString("yyyy-MM-dd 00:00:00"), dtPickerEndAllPlayers.Value.ToString("yyyy-MM-dd 23:59:59"));

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + ", " + "date: " + row["date"]);
            }
        }

        private void cmbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable txtDate and txtScore
            txtDate.Enabled = true;
            txtScore.Enabled = true;
            
            // check if cmbPlayer is selected
            if (cmbPlayers.SelectedIndex.ToString() == "")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // sId
            string sId = lblID.Text;

            // Get the selected date
            string sCmb = cmbDates.SelectedItem.ToString();

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();
            stuff.getScore(sId, sCmb);

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
            }

            // First row
            DataRow row = stuff.Dt.Rows[0];

            // Set textbox values based on query
            txtDate.Text = row["date"].ToString();
            txtScore.Text = row["score"].ToString();
        }

        private void btnRankingPDF_Click(object sender, EventArgs e)
        {
            string folder = "MyPDF";

            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getPlayersRanking();

            // Check errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("RANKING").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);

            document.Add(header);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Create a new Paragraph obj
                Paragraph p = new Paragraph("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "totalscore: " + row["totalscore"]);

                document.Add(p);
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void btnScoreHistoryPDF_Click(object sender, EventArgs e)
        {
            string folder = "MyPDF";

            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getPlayersHistory();

            // Check errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("Scores History").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);

            document.Add(header);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Create a new Paragraph obj
                Paragraph p = new Paragraph("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + " " + "date: " + row["date"]);

                document.Add(p);
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void btnPlayerTLPDF_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if the date is in the future
            if (dtPickerStart.Value > DateTime.Now || dtPickerEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayersHistorySpecific method
            stuff.getPlayersHistorySpecific(lblID.Text, dtPickerStart.Value.ToString("yyyy-MM-dd 00:00:00"), dtPickerEnd.Value.ToString("yyyy-MM-dd 23:59:59"));

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + " " + "date: " + row["date"]);
            }
            
            string folder = "MyPDF";

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("PLAYER'S Score History On a Timeline").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);

            // Create a new Paragraph obj for timeline
            Paragraph header2 = new Paragraph(dtPickerStart.Value.ToString("yyyy-MM-dd") + " - " + dtPickerEnd.Value.ToString("yyyy-MM-dd")).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16);

            document.Add(header);
            document.Add(header2);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Create a new Paragraph obj
                Paragraph p = new Paragraph("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + ", " + "date: " + row["date"]);

                document.Add(p);
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void btnPlayersTLPDF_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if the date is in the future
            if (dtPickerStartAllPlayers.Value > DateTime.Now || dtPickerEndAllPlayers.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayersHistorySpecific method
            stuff.getAllPlayersHistorySpecific(dtPickerStartAllPlayers.Value.ToString("yyyy-MM-dd 00:00:00"), dtPickerEndAllPlayers.Value.ToString("yyyy-MM-dd 23:59:59"));

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + ", " + "date: " + row["date"]);
            }

            string folder = "MyPDF";

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("PLAYERS' Score History On a Timeline").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
            
            // Create a new Paragraph obj for timeline
            Paragraph header2 = new Paragraph(dtPickerStartAllPlayers.Value.ToString("yyyy-MM-dd") + " - " + dtPickerEndAllPlayers.Value.ToString("yyyy-MM-dd")).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16);

            document.Add(header);
            document.Add(header2);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Create a new Paragraph obj
                Paragraph p = new Paragraph("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "score: " + row["score"] + ", " + "date: " + row["date"]);

                document.Add(p);
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void btnRankingTL_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // start and end date
            string startDate = dtPickerRankingStart.Value.ToString("yyyy-MM-dd 00:00:00");
            string endDate = dtPickerRankingEnd.Value.ToString("yyyy-MM-dd 23:59:59");

            // Check if the date is in the future
            if (dtPickerRankingStart.Value > DateTime.Now || dtPickerRankingEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getPlayersRankingSpecific(startDate, endDate);

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "totalscore: " + row["totalscore"] + ", " + "Ranking: " + (i+1));
            }
        }

        private void btnRankingTLPDF_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if the date is in the future
            if (dtPickerRankingStart.Value > DateTime.Now || dtPickerRankingEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // start and end dates
            string startDate = dtPickerRankingStart.Value.ToString("yyyy-MM-dd 00:00:00");
            string endDate = dtPickerRankingEnd.Value.ToString("yyyy-MM-dd 23:59:59");

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayersRankingSpecific method
            stuff.getPlayersRankingSpecific(startDate, endDate);

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "totalscore: " + row["totalscore"] + ", " + "Ranking: " + (i+1));
            }

            string folder = "MyPDF";

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("RANKING On a Timeline").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
            
            // Create a new Paragraph obj for timeline
            Paragraph header2 = new Paragraph(dtPickerRankingStart.Value.ToString("yyyy-MM-dd") + " - " + dtPickerRankingEnd.Value.ToString("yyyy-MM-dd")).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16);

            document.Add(header);
            document.Add(header2);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Create a new Paragraph obj
                Paragraph p = new Paragraph("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "totalscore: " + row["totalscore"] + ", " + "Ranking: " + (i+1));

                document.Add(p);
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void btnInitForm_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            DataHandling stuff = new DataHandling();

            // Ask confirmation from the user
            if (MessageBox.Show("Are you sure you want to clear player and score tables in the database", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            else
            {
                // Initialize form and empty tables
                stuff.initForm();
                clearForm();
                loadCombo();

                // Clear cmbPlayers
                cmbPlayers.Items.Clear();
            }            
        }

        private void dtPickerRankingStart_ValueChanged(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if the date is in the future
            if (dtPickerRankingStart.Value > DateTime.Now || dtPickerRankingEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void dtPickerRankingEnd_ValueChanged(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if the date is in the future
            if (dtPickerRankingStart.Value > DateTime.Now || dtPickerRankingEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void btnSelectedPlayerRanking_Click_1(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (cmbPlayers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player");
                return;
            }
            
            // sId
            string sId = lblID.Text;

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getSelectedPlayerRanking();

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // check if  playerID = sId
                if (row["playerID"].ToString() == sId)
                {
                    // Add to listBox
                    lstBox.Items.Add("Ranking: " + (i + 1));
                    lstBox.Items.Add("Totalscore: " + row["totalscore"]);
                    lstBox.Items.Add("playerID: " + row["playerID"]); 
                }
            }
        }

        private void btnSelectedPlayerRankingPDF_Click(object sender, EventArgs e)
        {
            // sId
            string sId = lblID.Text;
            
            // folder
            string folder = "MyPDF";

            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (cmbPlayers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player");
                return;
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getSelectedPlayerRanking();

            // Check errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("Selected Player's Current Ranking").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);

            document.Add(header);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // check if  playerID = sId
                if (row["playerID"].ToString() == sId)
                {
                    // Create a new Paragraph obj
                    Paragraph p = new Paragraph("Ranking: " + (i+1));
                    Paragraph p2 = new Paragraph("Totalscore: " + row["totalscore"]);
                    Paragraph p3 = new Paragraph("playerID: " + row["playerID"]);

                    // add to document
                    document.Add(p);
                    document.Add(p2);
                    document.Add(p3);

                    // Break loop
                    break;
                }
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void btnSelectedPlayerRankingOnTL_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // sId
            string sId = lblID.Text;

            // startDate & endDate
            string startDate = dtPickerPlayerRankTLStart.Value.ToString("yyyy-MM-dd 00:00:00");
            string endDate = dtPickerPlayerRankTLEnd.Value.ToString("yyyy-MM-dd 23:59:59");

            // Check if the date is in the future
            if (dtPickerPlayerRankTLStart.Value > DateTime.Now || dtPickerPlayerRankTLEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Check if a player is selected
            if (cmbPlayers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player");
                return;
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getSelectedPlayerRankingOnTL method
            stuff.getSelectedPlayerRankingOnTL(startDate, endDate);

            // Check if there are any errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // check if playerID = sId
                if (row["playerID"].ToString() == sId)
                {
                    // Add to listBox
                    lstBox.Items.Add("Ranking: " + (i + 1));
                    lstBox.Items.Add("Totalscore: " + row["totalscore"]);
                    lstBox.Items.Add("playerID: " + row["playerID"]);
                }
            }
        }

        private void btnSelectedPlayerRankingOnTLPDF_Click(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if the date is in the future
            if (dtPickerPlayerRankTLStart.Value > DateTime.Now || dtPickerPlayerRankTLEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // sId
            string sId = lblID.Text;

            // startDate & endDate
            string startDate = dtPickerPlayerRankTLStart.Value.ToString("yyyy-MM-dd 00:00:00");
            string endDate = dtPickerPlayerRankTLEnd.Value.ToString("yyyy-MM-dd 23:59:59");

            // folder
            string folder = "MyPDF";

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getSelectedPlayerRankingOnTL(startDate, endDate);

            // Check errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // Must have write permission and checking if MyPDF exists, if not create it
            if (!Directory.Exists(@"C:\" + folder))
            {
                Directory.CreateDirectory(@"C:\" + folder);
            }

            // Create a new PdfWriter obj
            PdfWriter writer = new PdfWriter("C:\\MyPDF\\players.pdf");

            // Create a new PdfDocument obj
            PdfDocument pdf = new PdfDocument(writer);

            // Create a new Document obj
            Document document = new Document(pdf);

            // Create a new Paragraph obj
            Paragraph header = new Paragraph("Selected Player's Ranking On a Timeline").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
            Paragraph header2 = new Paragraph(startDate + " - " + endDate).SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);

            document.Add(header);
            document.Add(header2);

            // Loop player data to the document
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // check if  playerID = sId
                if (row["playerID"].ToString() == sId)
                {
                    // Create a new Paragraph obj
                    Paragraph p = new Paragraph("Ranking: " + (i + 1));
                    Paragraph p2 = new Paragraph("Totalscore: " + row["totalscore"]);
                    Paragraph p3 = new Paragraph("playerID: " + row["playerID"]);

                    // add to document
                    document.Add(p);
                    document.Add(p2);
                    document.Add(p3);

                    // Break loop
                    break;
                }
            }

            // MessageBox
            MessageBox.Show("PDF created successfully", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the document
            document.Close();

            // clear form
            clearForm();
        }

        private void dtPickerPlayerRankTLStart_ValueChanged(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if the date is in the future
            if (dtPickerPlayerRankTLStart.Value > DateTime.Now || dtPickerPlayerRankTLEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void dtPickerPlayerRankTLEnd_ValueChanged(object sender, EventArgs e)
        {
            // Create a new DataHandling object and check if there are players in database
            DataHandling stuff2 = new DataHandling();

            // Call the getPlayers method
            stuff2.getPlayers();

            // Check errors
            if (stuff2.Err != "0")
            {
                MessageBox.Show(stuff2.Err);
                return;
            }

            // If rows are 0, message
            if (stuff2.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // Check if a player is selected
            if (lblID.Text == "ID")
            {
                MessageBox.Show("Please select a player first");
                return;
            }

            // Check if the date is in the future
            if (dtPickerPlayerRankTLStart.Value > DateTime.Now || dtPickerPlayerRankTLEnd.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a date not in the future");
                return;
            }

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }
        }

        private void btnLstPlayers_Click(object sender, EventArgs e)
        {
            clearForm();

            // Check if lstBox is empty if not, empty it
            if (lstBox.Items.Count > 0)
            {
                lstBox.Items.Clear();
            }

            // Create a new DataHandling object
            DataHandling stuff = new DataHandling();

            // Call the getPlayers method
            stuff.getPlayers();

            // Check errors
            if (stuff.Err != "0")
            {
                MessageBox.Show(stuff.Err);
                return;
            }

            // If rows are 0, message
            if (stuff.Dt.Rows.Count == 0)
            {
                // message
                MessageBox.Show("No players found");

                // clearform
                clearForm();

                return;
            }

            // For loop the data into the lstBox
            for (int i = 0; i < stuff.Dt.Rows.Count; i++)
            {
                // One row
                DataRow row = stuff.Dt.Rows[i];

                // Add to listBox
                lstBox.Items.Add("playerID: " + row["playerID"] + ", " + "name: " + row["firstname"] + " " + row["lastname"] + ", " + "email: " + row["email"] + ", " + "password: " + row["pwd"]);
            }
        }
    }
}
