//
//  ActorItemViewModel.cs
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
    public class ActorItemViewModel : Appacitive.Sdk.APObject
    {
        //special constructor
        public ActorItemViewModel(Appacitive.Sdk.APObject existing)
            : base(existing)
        { }

        /// <summary>
        /// Name ViewModel property; this property is used in the view to display its value using a Binding.
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
        /// FaceUrl ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string FaceUrl
        {
            get
            {
                return this.Get<string>("picurl");
            }
            set
            {
                if (value != this.FaceUrl)
                {
                    this.Set<string>("picurl", value);
                    NotifyPropertyChanged("FaceUrl");
                }
            }
        }

        /// <summary>
        /// Created ViewModel property; this property is used in the view to display its value using a Binding.
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