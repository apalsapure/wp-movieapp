//
//  DetailsViewModel.cs
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
    public class DetailsViewModel : INotifyPropertyChanged
    {
        private MovieItemViewModel _movie;
        public DetailsViewModel(MovieItemViewModel movie)
        {
            this.Items = new ObservableCollection<ActorItemViewModel>();
            this._movie = movie;
        }

        /// <summary>
        /// A collection for ActorItemViewModel objects.
        /// </summary>
        public ObservableCollection<ActorItemViewModel> Items { get; private set; }
        public MovieItemViewModel Movie { get { return _movie; } }

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
        /// Fetches and adds a all ActorItemViewModel objects into the Items collection.
        /// </summary>
        public async void LoadData()
        {
            //this will show the loader
            this.IsDataLoaded = false;

            //clear the list
            this.Items.Clear();

            //Get all objects of type actor connected to the movie object
            var results = await _movie.GetConnectedObjectsAsync("acted", 
                                                                 orderBy: "__utclastupdateddate", 
                                                                 sortOrder: Appacitive.Sdk.SortOrder.Descending);

            //Iterate over the result object till all the actors are fetched
            while (true)
            {
                //converting appacitive object to model
                results.ForEach(r => this.Items.Add(new ActorItemViewModel(r)));

                //check if its last set of record
                if (results.IsLastPage)
                    break;

                //fetch next set of record
                results = await results.NextPageAsync();
            }

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