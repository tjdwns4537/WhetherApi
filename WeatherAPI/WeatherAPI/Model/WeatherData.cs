﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPP.Classes
{
    public class Main
    {

        private double temp;
        public double Temp
        {
            get { return temp; }
            set
            {
                temp = value;
                
                OnPropertyChanged("Temp");
            }
        }

        private System.Windows.Media.Brush foregroundColor = System.Windows.Media.Brushes.Black;
        
        public System.Windows.Media.Brush ForegroundColor
        {
            get { return foregroundColor; }

            set
            {
                foregroundColor = value;
                OnPropertyChanged("ForeGroundColor");
            }
        }
        

        private int humidity;
        public int Humidity
        {
            get { return humidity; }
            set { humidity = value; OnPropertyChanged("Humidity"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
    }

    public class Wind
    {
        private double speed;
        public double Speed
        {
            get { return speed; }
            set { speed = value; OnPropertyChanged("Speed"); }
        }

        private int deg;
        public int Deg
        {
            get { return deg; }
            set { deg = value; OnPropertyChanged("Deg"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
    }


    public class WeatherData: INotifyPropertyChanged
    {
        public WeatherData()
        {
            Main = new Main() { Temp = 23, Humidity = 60 };
            Wind = new Wind() { Deg = 0, Speed = 5 };
            Name = "Jeonju";
        }
        private Main main;
        public Main Main
        {
            get { return main; }
            set { main = value; OnPropertyChanged("Main"); }
        }
        private Wind wind;
        public Wind Wind
        {
            get { return wind; }
            set { wind = value; OnPropertyChanged("Wind"); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propName));

            }
        }
    }

}
