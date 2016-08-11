using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace NSOCR.Klasy
{
    internal class MySQLConector
    {
        private MySqlConnection Connect;
        private string Server;
        private string DBName;
        private string uid;
        private string password;

        public MySQLConector()
        {
            Initialize();
        }

        private void Initialize()
        {
            Server = "localhost";
            DBName = "work";
            uid = "root";
            password = "root";
            string connectioninfo;
            connectioninfo = "server=" + Server + ";user id=" + uid + "; password =" + password + " ;database=" + DBName + ";";
            Connect = new MySqlConnection(connectioninfo);
        }

        public bool OpenConnection()
        {
            try
            {
                Connect.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Nie można połączyć się z serwerem");
                        break;

                    case 1045:
                        MessageBox.Show("Zły login lub hasło");
                        break;

                    default:
                        MessageBox.Show("Nie znany bład");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                Connect.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void InsertToDB(Klasy.Informacje Info)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Connect;
                string DBName = "job";
                string BoxList = "NIPNabywcy, NIPSprzedacy, NrObcy, NrLeasingu, DataWystawienia, DataZakupu, Kwota, Waluta,Kwota2, Waluta2,KodKreskowy, DataDodania";
                cmd.CommandText = "INSERT INTO " + DBName + " (" + BoxList + ") VALUES (@NIPNaby, @NIPSprzed, @NRObcy, @NrLeasingu, @DataWystaw, @DataZakupu, @Kwota, @Waluta, @Kwota2, @Waluta2, @KodKreskowy, @DataDodania);";
                cmd.Parameters.AddWithValue("@NIPNaby", Info.NIPNabywcy);
                cmd.Parameters.AddWithValue("@NIPSprzed", Info.NIPSprzedawcy);
                cmd.Parameters.AddWithValue("@NRObcy", Info.NrObcy);
                cmd.Parameters.AddWithValue("@NrLeasingu", Info.NrLeasingu);
                cmd.Parameters.AddWithValue("@DataWystaw", Info._DataWystawienia);
                cmd.Parameters.AddWithValue("@DataZakupu", Info._DataZakupu);
                cmd.Parameters.AddWithValue("@Kwota", Info.Kwota1);
                cmd.Parameters.AddWithValue("@Waluta", Info.Waluta1);
                cmd.Parameters.AddWithValue("@Kwota2", Info.Kwota2);
                cmd.Parameters.AddWithValue("@Waluta2", Info.Waluta2);
                cmd.Parameters.AddWithValue("@KodKreskowy", Info.Barcode);
                cmd.Parameters.AddWithValue("@DataDodania", DateTime.Now);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}