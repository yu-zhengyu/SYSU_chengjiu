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
            weibolongin(yonghu_textBox.Text, password_box.Password);
        }


        void weibolongin(string user, string password)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "user");
            parameters.Add("password", "123456");
            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    JObject userobj = JObject.Parse(e.Result);
                    if(userobj["info"].ToString() == "登录成功")
                        NavigationService.Navigate(new Uri("/daohang/xinlulicheng.xaml", UriKind.Relative));
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/?a=login", UriKind.Absolute));
        }

    }
}