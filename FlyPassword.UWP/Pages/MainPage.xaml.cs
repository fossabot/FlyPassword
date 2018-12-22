﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FlyPassword.UWP.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FlyPassword.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (TmpData.PasswordKeeper != null)
            {
                System.Diagnostics.Debug.WriteLine(viewall.Parent);
            }
            else
            {
                this.Frame.Navigate(typeof(PasswordInputPage));
            }
        }
        private void NvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {

            }
            else
            {
                if (args.InvokedItemContainer == viewall)
                {
                    contentFrame.Navigate(typeof(MasterPage),TmpData.PasswordKeeper.Records);
                }
                else if (args.InvokedItemContainer == fav)
                {
                    contentFrame.Navigate(typeof(MasterPage), TmpData.PasswordKeeper.Records.Where(a=>a.Tags.Contains("_fav")).ToList());
                }
                else if (args.InvokedItemContainer == folder)
                {
                    //todo
                }
            }
        }

        private void NvSample_Loaded(object sender, RoutedEventArgs e)
        {
            ((NavigationViewItem)nvSample.SettingsItem).Content = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView().GetString("mainpage_settings");
        }
    }
}
