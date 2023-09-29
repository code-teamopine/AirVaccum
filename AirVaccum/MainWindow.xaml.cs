using AirVaccum.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

namespace AirVaccum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VMChart co;
        public MainWindow()
        {
            InitializeComponent();
            FillFilterData();
            co = new VMChart();
            base.DataContext = co;
            // this.DataContext = ViewModel.Instance;
        }

        public void FillFilterData()
        {

            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=E:\AirVaccum\AirVaccum\bin\Debug\valve-data.db;"))
            {
                conn.Open();

               SQLiteCommand command = new SQLiteCommand("SELECT * FROM Sheet1", conn);
                command.ExecuteNonQuery();

                SQLiteDataAdapter adap = new SQLiteDataAdapter(command);

                DataTable dt = new DataTable("Sheet1");
                adap.Fill(dt);

               conn.Close();
            }

        }

    }
}
