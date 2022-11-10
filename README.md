# How to bind the SQL Database to WPF Chart (SfChart)?

This example demonstrates how to establish the SQL connection and bind the retrieving data from database in a step by step process.

**Step 1:** Retrieve the data table from the SQL DataSet using the connection string.

```
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
```

**Step 2:** In the main page, initialize the SfChart control and bind the retrieved data.
```
<Grid>
        <Grid.DataContext>
            <local:ViewModel></local:ViewModel>
        </Grid.DataContext>
        
        <chart:SfChart Margin="10">
            
            <chart:SfChart.PrimaryAxis>
                <chart:NumericalAxis RangePadding="Additional"/>
            </chart:SfChart.PrimaryAxis>

            <chart:SfChart.SecondaryAxis>
                <chart:NumericalAxis RangePadding="Additional"/>
            </chart:SfChart.SecondaryAxis>

            <chart:ScatterSeries ItemsSource="{Binding DataTable}"
                                 XBindingPath="xVal" 
                                 YBindingPath="yVal"/>
        </chart:SfChart>
        
</Grid>
```

## Output:

![SQL DataBinding to WPF SfChart](https://user-images.githubusercontent.com/53489303/200743338-52fee1f9-d723-46b2-87ae-81da3b6e2067.png)

KB article - [How to bind the SQL Database to WPF Charts?](https://www.syncfusion.com/kb/11595/how-to-bind-the-sql-database-to-wpf-charts)
