using AirVaccum.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AirVaccum.ViewModels
{
    public class VMChart : ViewModelBase
    {
        static String connectionString = @"Data Source=E:\AirVaccum\AirVaccum\bin\Debug\valve-data.db;";
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds;

        private Random randomNumber;
        public int dataCount = 50000;
        private int rate = 5;
        int index = 0;
        DispatcherTimer timer;
        // public ObservableCollection<Chart> ChartData { get; set; }

        public ObservableCollection<Chart> _ChartData;
        public ObservableCollection<Chart> ChartData
        {
            get
            {
                return _ChartData;
            }
            set
            {
                _ChartData = value;
                OnPropertyChanged("ChartData");
            }
        }
        public VMChart()
        {
            randomNumber = new Random();
            ChartData = new ObservableCollection<Chart>();
            FillDG();
            timer = new DispatcherTimer();
          //  timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();
            
        }

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    FillDG();
        //}

        public void FillDG()
        {
            try
            { 
            con = new SQLiteConnection(connectionString);
            con.Open();
            cmd = new SQLiteCommand("select * from Sheet1", con);
            adapter = new SQLiteDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds, "Sheet1");

                if (ChartData == null || ChartData.Count == 0)
                   ChartData = new ObservableCollection<Chart>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
    
                    Chart ph = new Chart();
                    ph.Time = dr[0].ToString();
                    ph.J1 = Convert.ToInt32(dr[1]);
                    ph.J2 = Convert.ToInt32(dr[2]);
                    ph.J4 = Convert.ToInt32(dr[3]);
                    ph.J6 = Convert.ToInt32(dr[4]);
                    ph.SDO2 = Convert.ToInt32(dr[5]);
                    ph.TRIAL692 = dr[6].ToString();
                    ChartData.Add(ph);
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
            }

            
        }
    }
}

       
