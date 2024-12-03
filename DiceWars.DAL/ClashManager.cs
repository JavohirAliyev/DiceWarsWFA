using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using DiceWars.DAL.Entities;


namespace DiceWars.DAL
{
    public class ClashManager : DbManager
    {
        public void Create(Clash c)
        {
            using var connection = Connection;
            try
            {
                //SQL query for creating a record on the clash table when the game is occured
                var sql = "INSERT INTO [cl_clash_16096] " +
               "([cl_player1_16096], [cl_player2_16096], [cl_date_16096], [cl_outcome_16096]) " +
               "VALUES (@Player1Id, @Player2Id, @Date, @Outcome)"; ;

                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Player1Id", c.Player1.Id);
                command.Parameters.AddWithValue("@Player2Id", c.Player2.Id);
                command.Parameters.AddWithValue("@Date", c.Date.Ticks);
                command.Parameters.AddWithValue("@Outcome", c.Outcome);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }


        public List<Clash> GetAll()
        {
            //SQL query for Selecting all the records from the clash table
            var allPlayers = new PlayerManager().GetAll().ToDictionary(t => t.Id, t => t);
            using var connection = Connection;
            var result = new List<Clash>();
            try
            {
                var sql = "SELECT cl_id_16096" +
                    ",cl_player1_16096" +
                    ",cl_player2_16096" +
                    ",cl_date_16096" +
                    ",cl_outcome_16096 " +
                    "FROM cl_clash_16096";
                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var c = new Clash
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Player1 = allPlayers[Convert.ToInt32(reader.GetValue(1))],
                        Player2 = allPlayers[Convert.ToInt32(reader.GetValue(2))],
                        Date = new DateTime(Convert.ToInt64(reader.GetValue(3))),
                        Outcome = Convert.ToInt32(reader.GetValue(4))

                    };
                    result.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            return result;
        }
    }
}
