using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MemeGenerator
{
    public partial class MainPage : PhoneApplicationPage
    {
        public int memeSelection;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            memeSelection = -1;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int s = listBox1.SelectedIndex;
            NavigationService.Navigate(new Uri("/Page2.xaml?msg="+s, UriKind.Relative));
            //if (listBox1.SelectedIndex != -1) { memeSelection = listBox1.SelectedIndex; }

            /*Pass a string between activities*/
            //string HoldData = "Testing to show"; //coming from ListSelection
            //string uriLocation = "/Page2.xaml?msg=";

            //uriLocation += HoldData;
            //NavigationService.Navigate(new Uri(uriLocation, UriKind.Relative));

        }
    }
}