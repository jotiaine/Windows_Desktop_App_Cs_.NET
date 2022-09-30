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
    public partial class frmNewPlayer : Form
    {
        public frmNewPlayer()
        {
            InitializeComponent();
        }

        private void clearForm()
        {
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtEmail.Text = "";
            txtPwd.Text = "";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string sFirstname = txtFirstname.Text;
            string sLastname = txtLastname.Text;
            string sEmail = txtEmail.Text;
            string sPwd = txtPwd.Text;

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

            // Create a new NewPlayer object
            DataHandling nPlayer = new DataHandling();

            // Call the addPlayer method
            nPlayer.addPlayer(sLastname, sFirstname, sEmail, sPwd);

            // Check for errors
            if (nPlayer.Err != "0")
            {
                MessageBox.Show(nPlayer.Err);
                return;
            }

            // Check if player already exists in the player.db database
            if (nPlayer.Found == 1)
            {
                MessageBox.Show("The email is already in the database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clearForm();
            }
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
