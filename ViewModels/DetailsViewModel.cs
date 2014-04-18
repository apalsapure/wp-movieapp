﻿using System;
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
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ActorItemViewModel> Items { get; private set; }
        public MovieItemViewModel Movie { get { return _movie; } }

        private bool _isDataLoaded = false;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
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
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public async void LoadData()
        {
            var results = await _movie.GetConnectedObjectsAsync("acted", orderBy: "__utclastupdateddate", sortOrder: Appacitive.Sdk.SortOrder.Descending);

            while (true)
            {
                results.ForEach(r => this.Items.Add(new ActorItemViewModel(r)));
                if (results.IsLastPage)
                    break;
                results = await results.NextPageAsync();
            }

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