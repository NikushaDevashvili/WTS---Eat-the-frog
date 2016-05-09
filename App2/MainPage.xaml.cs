using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public MainPage()
        {
            this.InitializeComponent();
            
        }


        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            string username = UserName.Text;
            string password = Password.Text;

            if (localSettings.Values[username] == null)
            {
                new MessageDialog("Aseti momxmarebeli ar arsebobs").ShowAsync();

            }else
            {
                string data = localSettings.Values[username].ToString();
                var dataArray = data.Split('|');
                if (dataArray[1] == password)
                {
                    Frame.Navigate(typeof(Profile), username);
                }
                else
                {
                    new MessageDialog("Paroli ar daemtxva").ShowAsync();
                }
            }

        }
    }
}
