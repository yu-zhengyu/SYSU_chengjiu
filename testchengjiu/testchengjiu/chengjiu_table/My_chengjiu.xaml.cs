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
using testchengjiu.data;
using Newtonsoft.Json.Linq;
using WindowsPhonePostClient;

namespace testchengjiu.chengjiu_table
{
    public partial class My_chengjiu : PhoneApplicationPage
    {
        List<my_chengjiu_detile> detail = new List<my_chengjiu_detile>();
        public My_chengjiu()
        {
            InitializeComponent();
            check();
            get_chengjiu_list();
        }

        public void check()
        {
            if (App.send_mess == "我去华工了")
            {
                my_chengjiu_detile a = new my_chengjiu_detile()
                {
                    outline = "到达华工"
                };
                detail.Add(a);
            }
        }

        public void get_chengjiu_list()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "8785169");

            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    JObject userobj = JObject.Parse(e.Result);

                    JArray userdata_info = (JArray)userobj["detail"];
                    my_chengjiu_detile a = new my_chengjiu_detile()
                    {
                        achiname = userdata_info[0]["achiname"].Value<string>(),
                        amount = userdata_info[0]["amount"].Value<string>(),
                        outline = "折翼天使"
                    };
                    detail.Add(a);

                    listbox_chengjiu.ItemsSource = detail;
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/user/achievement", UriKind.Absolute));
        }

        private void chengjiu_SP_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.chengjiu_list = ((my_chengjiu_detile)(((System.Windows.Controls.Primitives.Selector)(this.listbox_chengjiu)).SelectedItem)).outline;
            NavigationService.Navigate(new Uri("/daohang/chengjiu_info.xaml", UriKind.Relative));
        }
    }
}