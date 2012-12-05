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
    public partial class denglujiemian : PhoneApplicationPage
    {

        public string info;

        public denglujiemian()
        {
            InitializeComponent();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void denglu_Click(object sender, RoutedEventArgs e)
        {
            this.progressBar1.IsIndeterminate = true;
            this.progressBar1.Visibility = System.Windows.Visibility.Visible;
            weibolongin(yonghu_textBox.Text, password_box.Password);
        }


        void weibolongin(string user, string password)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "8785169");
            parameters.Add("password", "8785169");
            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    if (e.Result == "")
                    {
                        MessageBox.Show("亲，你的网络可能有问题了。");
                        this.progressBar1.IsIndeterminate = false;
                    }
                    else
                    {
                        try {
                            JObject userobj = JObject.Parse(e.Result);
                            if (userobj["info"].ToString() == "success")
                            {
                                this.progressBar1.IsIndeterminate = false;
                                this.progressBar1.Visibility = System.Windows.Visibility.Collapsed;
                                //if (((JObject)((JObject)userobj["detail"])["detail"]).ToString() == "[]")
                                //{
                                NavigationService.Navigate(new Uri("/main.xaml", UriKind.Relative));
                                //}
                                //else
                                //{
                                //    NavigationService.Navigate(new Uri("/main.xaml", UriKind.Relative));
                                //}
                             }
                        }
                        catch 
                        {
                            MessageBox.Show("亲，你的网络可能有问题了。");

                            this.progressBar1.IsIndeterminate = false;
                            this.progressBar1.Visibility = System.Windows.Visibility.Collapsed;
                        }
                    }
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/user/login", UriKind.Absolute));
        }

    }
}