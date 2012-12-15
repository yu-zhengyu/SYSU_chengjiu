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
using WindowsPhonePostClient;
using Newtonsoft.Json.Linq;

namespace testchengjiu.appbar
{
    public partial class send : PhoneApplicationPage
    {
        public send()
        {
            InitializeComponent();
        }

        public void sends()
        {
            this.progressBar1.IsIndeterminate = true;
            this.progressBar1.Visibility = System.Windows.Visibility.Visible;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "8785169");
            parameters.Add("title", "来自中大成就系统");
            parameters.Add("content", textBox_send.Text);
            App.send_mess = textBox_send.Text;
            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    JObject userobj = JObject.Parse(e.Result);
                    if (userobj["info"].ToString() == "success")
                    {
                        //NavigationService.Navigate(new Uri("/mail.xaml", UriKind.Relative));
                        this.progressBar1.IsIndeterminate = false;
                        this.progressBar1.Visibility = System.Windows.Visibility.Collapsed;
                        NavigationService.Navigate(new Uri("/main.xaml", UriKind.Relative));
                        //NavigationService.GoBack();
                    }
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/post/send", UriKind.Absolute));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.count++;
            sends();
            //NavigationService.Navigate(new Uri("mail.xaml", UriKind.Relative));
        }
    }
}