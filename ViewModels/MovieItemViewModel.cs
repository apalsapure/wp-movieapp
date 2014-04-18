using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MovieApp
{
    public class MovieItemViewModel : Appacitive.Sdk.APObject
    {
        public MovieItemViewModel(Appacitive.Sdk.APObject existing)
            : base(existing)
        {

        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get
            {
                return this.Get<string>("name");
            }
            set
            {
                if (value != this.Name)
                {
                    this.Set<string>("name", value);
                    NotifyPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string FaceUrl
        {
            get
            {
                return this.Get<string>("posterurl");
            }
            set
            {
                if (value != this.FaceUrl)
                {
                    this.Set<string>("poasterurl", value);
                    NotifyPropertyChanged("FaceUrl");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Created
        {
            get
            {
                return this.CreatedAt.ToString("MMMM dd, yyyy");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}