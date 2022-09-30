using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClassLibraryPlayers
{
    public class DataHandling : db
    {
        // private variables
        private DataTable dt = new DataTable();
        private string err = "0";
        private int found = 0;

        // public variables
        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }

        // Getters and setters
        public string Err
        {
            get { return err; }
            set { err = value; }
        }

        public int Found
        {
            get { return found; }
            set { found = value; }
        }

        // public methods
        public void getPlayer(string sId)
        {
            try
            {
                // Convert sId to Integer
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader and SQLiteCommand object
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // Query
                sqlite_cmd.CommandText = "SELECT * FROM player WHERE playerID = " + iId;

                // Execute query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }
        
        public void getPlayers()
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT * FROM player";

                // Execute the query and assign the result to the SQLiteDataReader object
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }
        
        public void getScores(string sId)
        {
            try
            {
                // convert sId to int
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT * FROM score WHERE playerID = " + iId;

                // Execute the query and assign the result to the SQLiteDataReader object
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void getScore(string sId, string sCmb)
        {
            try
            {
                // convert sId to int
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT * FROM score WHERE playerID = '" + iId + "' AND date = '" + sCmb + "' LIMIT 1";

                // Execute the query and assign the result to the SQLiteDataReader object
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void getPlayersRanking()
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT player.playerID AS playerID, player.lastname AS lastname, player.firstname AS firstname, SUM(score.score) AS totalscore FROM player INNER JOIN score ON player.playerID = score.playerID GROUP BY player.playerID ORDER BY SUM(score.score) DESC";

                // Execute the query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void getSelectedPlayerRanking()
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT playerID, SUM(score) AS totalscore FROM score GROUP BY playerID ORDER BY SUM(score) DESC";

                // Execute the query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void getSelectedPlayerRankingOnTL(string startDate, string endDate)
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT playerID, SUM(score) AS totalscore FROM score WHERE date BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY playerID ORDER BY SUM(score) DESC";

                // Execute the query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }


        public void getPlayersRankingSpecific(string startDate, string endDate)
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT player.playerID AS playerID, player.lastname AS lastname, player.firstname AS firstname, SUM(score.score) AS totalscore, score.date AS date FROM player INNER JOIN score ON player.playerID = score.playerID WHERE score.date BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY player.playerID ORDER BY SUM(score.score) DESC";

                // Execute the query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void getPlayersHistory()
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT player.playerID AS playerID, player.lastname AS lastname, player.firstname AS firstname, score.score AS score, score.date AS date FROM player INNER JOIN score ON player.playerID = score.playerID ORDER BY lastname, firstname";

                // Execute the query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void getPlayersHistorySpecific(string sId, string sStartDate, string sEndDate)
        {
            try
            {
                // Convert sID to int
                int iId = Convert.ToInt32(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;

                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT player.playerID AS playerID, player.lastname AS lastname, player.firstname AS firstname, score.score AS score, score.date AS date FROM player INNER JOIN score ON player.playerID = score.playerID WHERE player.playerID = " + iId + " AND score.date BETWEEN '" + sStartDate + "' AND '" + sEndDate + "' ORDER BY lastname, firstname";

                // Execute the query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void getAllPlayersHistorySpecific(string sStartDate, string sEndDate)
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;

                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // set SQL query
                sqlite_cmd.CommandText = "SELECT player.playerID AS playerID, player.lastname AS lastname, player.firstname AS firstname, score.score AS score, score.date AS date FROM player INNER JOIN score ON player.playerID = score.playerID WHERE score.date BETWEEN '" + sStartDate + "' AND '" + sEndDate + "' ORDER BY lastname, firstname";

                // Execute the query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // Close the connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void updatePlayer(string sId, string sLastname, string sFirstname, string sEmail, string sPwd, string sScore, string sDate, string selectedDate)
        {
            try
            {
                // Convert sId to Integer
                int iId = Int32.Parse(sId);

                // Convert sScore to Integer
                int iScore = Int32.Parse(sScore);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // Query
                sqlite_cmd.CommandText = "UPDATE player SET lastname = '" + sLastname + "', firstname = '" + sFirstname + "', email = '" + sEmail + "', pwd = '" + sPwd + "' WHERE playerID = " + iId;

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Update score table
                sqlite_cmd.CommandText = "UPDATE score SET playerID = " + iId + ", score = " + iScore + ", date = '" + sDate + "' WHERE playerID = " + iId + " AND date = '" + selectedDate + "'";

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void updatePlayerTable(string sId, string sLastname, string sFirstname, string sEmail, string sPwd)
        {
            try
            {
                // Convert sId to Integer
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // Query
                sqlite_cmd.CommandText = "UPDATE player SET lastname = '" + sLastname + "', firstname = '" + sFirstname + "', email = '" + sEmail + "', pwd = '" + sPwd + "' WHERE playerID = " + iId;

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void checkIfEmailExistsWithAnother(string sId, string sEmail)
        {
            try
            {
                // Convert sId to Integer
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteCommand & SQLiteDataReader object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                SQLiteDataReader sqlite_datareader;

                // check if email exists
                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "SELECT email FROM player WHERE email = '" + sEmail + "' AND playerID <> " + iId;

                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Load the data into the DataTable
                Dt.Load(sqlite_datareader);

                // if a row is found
                if (Dt.Rows.Count > 0)
                { 
                    this.Found = 1; // Another player already uses the email
                }

                // Close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        } 
                   
        public void addPlayer(string sLastname, string sFirstname, string sEmail, string sPwd)
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteCommand object and SQLiteDataReader object
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // Query
                sqlite_cmd.CommandText = "SELECT * FROM player WHERE email = '" + sEmail + "'";

                // Execute query
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // Check if user exists
                if (sqlite_datareader.HasRows)
                {
                    this.Found = 1;

                    sqlite_datareader.Close();
                    sqlite_conn.Close();

                    return;
                }
                else
                {
                    // add new player into the players.db database
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = "INSERT INTO player (lastname, firstname, email, pwd) VALUES ('" + sLastname + "', '" + sFirstname + "', '" + sEmail + "', '" + sPwd + "')";

                    // Execute query
                    sqlite_cmd.ExecuteNonQuery();

                    // Close connection
                    sqlite_conn.Close();
                }

            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void addScore(string sId, string sScore, string sDate)
        {
            try
            {
                // Convert sID to integer
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create a new SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // Query
                sqlite_cmd.CommandText = "INSERT INTO score (playerID, score, date) VALUES ('" + iId + "', '" + sScore + "', '" + sDate + "')";

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Close connection
                sqlite_conn.Close();

            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void deletePlayer(string sId)
        {
            try
            {
                // Convert sId to Integer
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create SQLiteCommand object
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();

                // Delete player from player table
                sqlite_cmd.CommandText = "DELETE FROM player WHERE playerID = " + iId;

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Delete player from score table
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM score WHERE playerID = " + iId;
                sqlite_cmd.ExecuteNonQuery();

                // Close connection
                sqlite_conn.Close();

            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void deleteScore(string sId, string selectedDate)
        {
            try
            {
                // Convert sId to Integer
                int iId = Int32.Parse(sId);

                // Open connection to players.db database
                sqlite_conn.Open();

                // Create SQLiteCommand object
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();

                // Delete player from player table
                sqlite_cmd.CommandText = "DELETE FROM score WHERE playerID = " + iId + " AND date = '" + selectedDate + "'";

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

        public void initForm()
        {
            try
            {
                // Open connection to players.db database
                sqlite_conn.Open();

                // Create SQLiteCommand object
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                // Delete player table rows
                sqlite_cmd.CommandText = "DELETE FROM score";

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Delete score table rows
                sqlite_cmd = sqlite_conn.CreateCommand();

                // query
                sqlite_cmd.CommandText = "DELETE FROM player";

                // Execute query
                sqlite_cmd.ExecuteNonQuery();

                // Close connection
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.ToString();
            }
        }

    }
}
