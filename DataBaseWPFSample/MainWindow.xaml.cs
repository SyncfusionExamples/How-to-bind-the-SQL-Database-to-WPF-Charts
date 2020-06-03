using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseWPFSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

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
