//
//  MainViewModel.cs
//  Appacitive Quickstart
//
//  Copyright 2014 Appacitive, Inc.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace MovieApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<MovieItemViewModel>();
        }

        /// <summary>
        /// A collection for MovieItemViewModel objects.
        /// </summary>
        public ObservableCollection<MovieItemViewModel> Items { get; private set; }

        private bool _isDataLoaded = false;
        /// <summary>
        /// IsDataLoaded ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public bool IsDataLoaded
        {
            get
            {
                return _isDataLoaded;
            }
            set
            {
                if (value != _isDataLoaded)
                {
                    _isDataLoaded = value;
                    NotifyPropertyChanged("IsDataLoaded");
                }
            }
        }

        /// <summary>
        /// Creates and adds a few MovieItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            //this will show the loader
            this.IsDataLoaded = false;

            //clear the list
            this.Items.Clear();

            // Sample data; replace with real data
            this.Items.Add(new MovieItemViewModel() { Id = "1", Name = "runtime one", FaceUrl = "/Assets/Sample/movie.png", });
            this.Items.Add(new MovieItemViewModel() { Id = "2", Name = "runtime two", FaceUrl = "/Assets/Sample/movie.png", });
            this.Items.Add(new MovieItemViewModel() { Id = "3", Name = "runtime three", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "4", Name = "runtime four", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "5", Name = "runtime five", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "6", Name = "runtime six", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "7", Name = "runtime seven", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "8", Name = "runtime eight", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "9", Name = "runtime nine", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "10", Name = "runtime ten", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "11", Name = "runtime eleven", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "12", Name = "runtime twelve", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "13", Name = "runtime thirteen", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "14", Name = "runtime fourteen", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "15", Name = "runtime fifteen", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new MovieItemViewModel() { Id = "16", Name = "runtime sixteen", FaceUrl = "/Assets/Sample/movie.png" });

            //this will hide the loader
            this.IsDataLoaded = true;
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