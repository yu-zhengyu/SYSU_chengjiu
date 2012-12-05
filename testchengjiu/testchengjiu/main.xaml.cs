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
using WindowsPhonePostClient;
using Newtonsoft.Json.Linq;

namespace testchengjiu
{
    public partial class main : PhoneApplicationPage
    {
        string[] col = { "#2DFF1A00", "#2D20FF00", "#2D00ABFF", "#35FFFB00" };
     
        public main()
        {
            InitializeComponent();
            get_message();
            chengjiuhub();
            get_fuguang();
        }

        // 浮光掠影信息获取
        public void get_fuguang()
        {
            List<fuguang_data> fuguang = new List<fuguang_data>();
            for (int i = 0; i < 15; i++)
            {
                fuguang_data a = new fuguang_data { image = "http://tp4.sinaimg.cn/1849017127/50/40002000245/1", chengjiu = "小女子 达成【三饭大王】成就", name = "局长", time = "2012.11.23" };
                fuguang.Add(a);
            }
            fuguanglueying.ItemsSource = fuguang;
        }

        // 心路历程信息获取
        public void get_message()
        {
            List<user> xinlu_list = new List<user>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "8785169");
            parameters.Add("page", "1");

            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    JObject userobj = JObject.Parse(e.Result);
                    int i = 2;
                    foreach (var obj in (JArray)userobj["detail"])
                    {
                        i = (i+2) % 4;
                        user a = new user()
                        {
                            pid = obj["id"].Value<string>(),
                            content = obj["content"].Value<string>(),
                            posttime = obj["posttime"].Value<string>(),
                            source = obj["source"].Value<string>(),
                            title = obj["title"].Value<string>(),
                            color1 = col[i],
                            color2 = col[i+1]
                        };
                        xinlu_list.Add(a);
                    }

                    listBox_xinlu.ItemsSource = xinlu_list;
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/post/get", UriKind.Absolute));
        }


        // 时光脚步信息录入
        public void chengjiuhub()
        {
            List<chengjiuxitong_hubtile> title = new List<chengjiuxitong_hubtile>()
            {
                new chengjiuxitong_hubtile{ImageUri = "/testchengjiu;component/Images/food.jpg", GroupTag="TileGroup", Message="", Notification="", Title="美食"},
                new chengjiuxitong_hubtile{ImageUri = "/testchengjiu;component/Images/movie.jpg", GroupTag="TileGroup", Message="", Notification="", Title="电影"},
                new chengjiuxitong_hubtile{ImageUri = "/testchengjiu;component/Images/book.jpg", GroupTag="TileGroup", Message="", Notification="", Title="书籍"},
                new chengjiuxitong_hubtile{ImageUri = "/testchengjiu;component/Images/path.jpg", GroupTag="TileGroup", Message="", Notification="", Title="足迹"},
                new chengjiuxitong_hubtile{ImageUri = "/testchengjiu;component/Images/young.jpg", GroupTag="TileGroup", Message="", Notification="", Title="青春"}

            };
            tileList.ItemsSource = title;

        }

        // 时光脚步的hubtile点击事件
        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.chengjiu_title = (((chengjiuxitong_hubtile)(((System.Windows.Controls.Primitives.Selector)(this.tileList)).SelectedValue)).Title);
            NavigationService.Navigate(new Uri("/daohang/chengjiu_congtent.xaml", UriKind.Relative));
        }

        private void focus_appbar_Click(object sender, EventArgs e)
        {
            listBox_xinlu.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/daohang/pinglun.xaml", UriKind.Relative));
        }
    }
}