// TODO: Reset list when navigating back to the main page. Currently can't reenter any memes.
// TODO: In Page2.cs, add ability to tap 'Enter' and have the next textBox be selected, or have the keyboard drop down.
// TODO: We should allow wrapping in the textBoxes

// TODO: When selecting a textBox, highlight entire input for easy deletion.

// For testing/debugging purposes, use the following instead of Zune
// C:\Program Files (x86)\Microsoft SDKs\Windows Phone\v7.1\Tools\WPConnect\x64

using System;
using System.IO;
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
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


namespace MemeGenerator
{
    public partial class Page2 : PhoneApplicationPage
    {
        public string memeSelected;
        Image memeImage;
        TextBox textBox1;
        TextBox textBox2;
        TextBlock textBlock1 = new TextBlock();
        TextBlock textBlock2 = new TextBlock(); 

        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string memeSelected = String.Empty;

            NavigationContext.QueryString.TryGetValue("msg", out memeSelected);

            chooseMemePicture(memeSelected);
        }

        public void chooseMemePicture(string memeSelected)
        {
            memeImage = new Image();
            switch (memeSelected)
            {
                case "0":
                    memeImage.Source = new BitmapImage(new Uri("Images/sap400x400.jpg", UriKind.Relative));
                    break;
                case "1":
                    memeImage.Source = new BitmapImage(new Uri("Images/fry400x400.jpg", UriKind.Relative));
                    break;
                default:
                    break;
            }
            memeImage.HorizontalAlignment = HorizontalAlignment.Center;
            memeImage.VerticalAlignment = VerticalAlignment.Top;
            Screenshot.Children.Add(memeImage);

            showTextBoxes();
        }

        public void showTextBoxes()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();

            textBox1.Text = "Line 1";
            textBox2.Text = "Line 2";
            //textBox1.Height = 78;
            //textBox2.Height = 78;
            textBox1.VerticalAlignment = VerticalAlignment.Top;
            textBox2.VerticalAlignment = VerticalAlignment.Bottom;
            textBox1.HorizontalAlignment = HorizontalAlignment.Center;
            textBox2.HorizontalAlignment = HorizontalAlignment.Center;
            textBox1.TextAlignment = TextAlignment.Center;
            textBox2.TextAlignment = TextAlignment.Center;
            textBox1.FontSize = 40;
            textBox2.FontSize = 40;
            textBox1.FontFamily = new FontFamily("Arial");
            textBox2.FontFamily = new FontFamily("Arial");
            textBox1.FontWeight = FontWeights.ExtraBold;
            textBox2.FontWeight = FontWeights.ExtraBold;

            Screenshot.Children.Add(textBox1);
            Screenshot.Children.Add(textBox2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Screenshot.Children.Remove(textBlock1);
            Screenshot.Children.Remove(textBlock2);

            textBlock1.Text = textBox1.Text;
            textBlock2.Text = textBox2.Text;

            Screenshot.Children.Remove(textBox1);
            Screenshot.Children.Remove(textBox2);

            Screenshot.Children.Remove(memeImage);

            textBlock1.Margin = new Thickness(0, 0, 0, 350);
            textBlock2.Margin = new Thickness(0, 350, 0, 0);
            //textBlock1.Height = 78;
            //textBlock2.Height = 78;
            textBlock1.VerticalAlignment = VerticalAlignment.Top;
            textBlock2.VerticalAlignment = VerticalAlignment.Bottom;
            textBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock1.TextAlignment = TextAlignment.Center;
            textBlock2.TextAlignment = TextAlignment.Center;
            textBlock1.Width = Screenshot.ActualWidth;
            textBlock2.Width = Screenshot.ActualWidth;
            textBlock1.FontSize = 40;
            textBlock2.FontSize = 40;
            textBlock1.FontFamily = new FontFamily("Arial");
            textBlock2.FontFamily = new FontFamily("Arial");
            textBlock1.FontWeight = FontWeights.ExtraBold;
            textBlock2.FontWeight = FontWeights.ExtraBold;

            Screenshot.Children.Add(memeImage);
            Screenshot.Children.Add(textBlock1);
            Screenshot.Children.Add(textBlock2);

            /*****************************************************************************************************/

            WriteableBitmap wb = null;
            while ((wb = new WriteableBitmap(Screenshot, null)) == null) ;
            wb.Invalidate();

            wb.SaveToMediaLibrary("meme" + memeSelected, false);

            MessageBox.Show("Your meme is saved.");
        }
    }
}