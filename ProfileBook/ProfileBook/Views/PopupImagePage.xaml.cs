﻿using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProfileBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupImagePage : PopupPage
    {
        public PopupImagePage(string imgPath)
        {
            InitializeComponent();
            ImageView.Source = imgPath;
        }
    }
}