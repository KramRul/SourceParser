using SourceParser.Pages;
using SourceParser.ViewModel;
using System;
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

namespace SourceParser
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new ApplicationViewModel();
            myFrame.Navigate(typeof(Pages.Home));
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected)
            {
                myFrame.Navigate(typeof(Pages.Home));
            }
            else if (addDocument.IsSelected)
            {
                myFrame.Navigate(typeof(Pages.NewDocument));
            }
            else if (addLink.IsSelected)
            {
                myFrame.Navigate(typeof(Pages.NewLink));
            }
            else if (addNote.IsSelected)
            {
                myFrame.Navigate(typeof(Pages.NewNote));
            }
            else if (settings.IsSelected)
            {
                myFrame.Navigate(typeof(Pages.SettingsPage));
            }
            else if (addStyle.IsSelected)
            {
                myFrame.Navigate(typeof(Pages.NewStyle));
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            SplitViewAcc.IsPaneOpen = !SplitViewAcc.IsPaneOpen;
        }
    }
}
