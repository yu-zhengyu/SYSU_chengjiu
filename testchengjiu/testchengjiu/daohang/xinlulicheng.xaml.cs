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
using testchengjiu.data;

namespace testchengjiu.daohang
{
    public partial class chengjiuxitong : PhoneApplicationPage
    {

        public chengjiuxitong()
        {
            InitializeComponent();
            get_message();
            chengjiuhub();
        }

        public void chengjiuhub()
        {
            List<chengjiuxitong_hubtile> title = new List<chengjiuxitong_hubtile>()
            {
                new chengjiuxitong_hubtile{ImageUri = "", GroupTag="TileGroup", Message="", Notification="", Title="美食"},
                new chengjiuxitong_hubtile{ImageUri = "", GroupTag="TileGroup", Message="", Notification="", Title="电影"},
                new chengjiuxitong_hubtile{ImageUri = "", GroupTag="TileGroup", Message="", Notification="", Title="书籍"},
                new chengjiuxitong_hubtile{ImageUri = "", GroupTag="TileGroup", Message="", Notification="", Title="足迹"},
                new chengjiuxitong_hubtile{ImageUri = "", GroupTag="TileGroup", Message="", Notification="", Title="青春"}

            };
            tileList.ItemsSource = title;

        }

        public void get_message()
        {
            List<user> xinlu_list = new List<user>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "user");
            parameters.Add("source", "weibo");

            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    JArray userobj = JArray.Parse(e.Result);
                    foreach (var obj in userobj)
                    {
                        user a = new user()
                        {
                            pid = obj["pid"].Value<string>(),
                            content = obj["content"].Value<string>(),
                            posttime = obj["postTime"].Value<string>(),
                            source = obj["source"].Value<string>(),
                            reply_count = obj["reply_count"].Value<string>(),
                            title = obj["title"].Value<string>(),

                        };
                        xinlu_list.Add(a);
                    }

                    listBox_xinlu.ItemsSource = xinlu_list;
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/?a=getPost", UriKind.Absolute));
        }
    }
}