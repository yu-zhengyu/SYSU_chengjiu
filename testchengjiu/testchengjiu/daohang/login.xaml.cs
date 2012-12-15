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

namespace testchengjiu.daohang
{
    public partial class login : PhoneApplicationPage
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            login_message();
        }

        public void login_message()
        {
            this.progressBar1.IsIndeterminate = true;
            this.progressBar1.Visibility = System.Windows.Visibility.Visible;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "8785169");
            parameters.Add("password", password.Text);
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
                        NavigationService.GoBack();
                    }
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/user/login", UriKind.Absolute));
        }

    }
}