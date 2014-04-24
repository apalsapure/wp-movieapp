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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

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
        /// Creates and adds a few ActorItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            //this will show the loader
            this.IsDataLoaded = false;

            //clear the list
            this.Items.Clear();

            // Sample data; replace with real data
            this.Items.Add(new ActorItemViewModel() { Name = "John one", FaceUrl = "/Assets/Sample/actor.png", });
            this.Items.Add(new ActorItemViewModel() { Name = "John two", FaceUrl = "/Assets/Sample/actor.png", });
            this.Items.Add(new ActorItemViewModel() { Name = "John three", FaceUrl = "/Assets/Sample/actor.png" });
            this.Items.Add(new ActorItemViewModel() { Name = "John four", FaceUrl = "/Assets/Sample/actor.png" });
            this.Items.Add(new ActorItemViewModel() { Name = "John five", FaceUrl = "/Assets/Sample/actor.png" });
            this.Items.Add(new ActorItemViewModel() { Name = "John six", FaceUrl = "/Assets/Sample/actor.png" });
            this.Items.Add(new ActorItemViewModel() { Name = "John seven", FaceUrl = "/Assets/Sample/actor.png" });
            this.Items.Add(new ActorItemViewModel() { Name = "John eight", FaceUrl = "/Assets/Sample/actor.png" });
            this.Items.Add(new ActorItemViewModel() { Name = "John nine", FaceUrl = "/Assets/Sample/movie.png" });
            this.Items.Add(new ActorItemViewModel() { Name = "John ten", FaceUrl = "/Assets/Sample/movie.png" });

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