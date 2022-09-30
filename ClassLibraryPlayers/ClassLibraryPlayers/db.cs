using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPlayers
{
    public class db
    {
        // Connect to players.db database
        public SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=players.db; Version=3; New=False; Compress=True");
    }
}
