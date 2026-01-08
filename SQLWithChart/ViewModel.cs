using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace SQLWithChart
{

    public class ViewModel
    {
        public ViewModel()
        {
            try
            {
                SqlConnection thisConnection = new SqlConnection(ConnectionString);
                thisConnection.Open();
                string Get_Data = "SELECT * FROM ChartData";
                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = Get_Data;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                var table = ds.Tables[0];
                this.DataTable = table;
            }
            catch
            {
                MessageBox.Show("DataBase Error");
            }
        }

        public object DataTable { get; set; }

        public static string ConnectionString
        {
            get
            {
                string currentDir = System.Environment.CurrentDirectory;
                currentDir = currentDir.Substring(0, currentDir.Length - 10) + "\\LocalDataBase";
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + currentDir + @"\SeriesItemsSource.mdf;Integrated Security=True";
            }
        }
    }
}
