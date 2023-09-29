using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirVaccum.Models
{
    public class Chart:ViewModelBase
    {
        public string _Time;
        public string Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
                OnPropertyChanged("Time");
            }
        }

        public int _J1;
        public int J1
        {
            get
            {
                return _J1;
            }
            set
            {
                _J1 = value;
                OnPropertyChanged("J1");
            }
        }

        public int _J2;
        public int J2
        {
            get
            {
                return _J2;
            }
            set
            {
                _J2 = value;
                OnPropertyChanged("J2");
            }
        }

        public int _J4;
        public int J4
        {
            get
            {
                return _J4;
            }
            set
            {
                _J4 = value;
                OnPropertyChanged("J4");
            }
        }

        public int _J6;
        public int J6
        {
            get
            {
                return _J6;
            }
            set
            {
                _J6 = value;
                OnPropertyChanged("J6");
            }
        }

        public int _SDO2;
        public int SDO2
        {
            get
            {
                return _SDO2;
            }
            set
            {
                _SDO2 = value;
                OnPropertyChanged("SDO2");
            }
        }

        public string _TRIAL692;
        public string TRIAL692
        {
            get
            {
                return _TRIAL692;
            }
            set
            {
                _TRIAL692 = value;
                OnPropertyChanged("TRIAL692");
            }
        }
        
    }
}
