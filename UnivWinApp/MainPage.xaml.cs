using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Runtime.Serialization.Json;
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
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace UnivWinApp {
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
            setUpData();         
        }

        private async void setUpData() {
            List<RootObject> myData = await TraktTV.DownloadData2();
            for (int i = 0; i < 10; ++i) {
                Image im = new Image();
                im.Name = "img" + i;
                im.Source = new BitmapImage(new Uri(myData[i].images.poster.thumb, UriKind.Absolute));
                im.SetValue(Grid.RowProperty, i);
                im.SetValue(Grid.ColumnProperty, 0);
                im.HorizontalAlignment = HorizontalAlignment.Center;
                im.VerticalAlignment = VerticalAlignment.Center;
                im.Width = 300;
                im.Height = 441;
                im.Margin = new Thickness(20, 20, 20, 20);

                TextBlock tb = new TextBlock();
                tb.Name = "lbl" + i;
                tb.Text = myData[i].title;
                tb.SetValue(Grid.RowProperty, i);
                tb.SetValue(Grid.ColumnProperty, 1);
                tb.HorizontalAlignment = HorizontalAlignment.Left;
                tb.VerticalAlignment = VerticalAlignment.Top;
                tb.FontSize = 60;

                TextBlock tbDesc = new TextBlock();
                tbDesc.Name = "lblDesc" + i;
                tbDesc.Text = myData[i].overview;
                tbDesc.SetValue(Grid.RowProperty, i);
                tbDesc.SetValue(Grid.ColumnProperty, 1);
                tbDesc.HorizontalAlignment = HorizontalAlignment.Left;
                tbDesc.VerticalAlignment = VerticalAlignment.Center;
                tbDesc.TextWrapping = TextWrapping.Wrap;
                tbDesc.FontSize = 25;

                grid.Children.Add(im);
                grid.Children.Add(tb);
                grid.Children.Add(tbDesc);
            }
        }
    }
}
