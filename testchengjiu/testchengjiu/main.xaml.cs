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
using System.ComponentModel;
using System.Threading;
using testchengjiu.chengjiu_table;

namespace testchengjiu
{
    public partial class main : PhoneApplicationPage
    {
        string[] col = { "#2DFF1A00", "#2D20FF00", "#2D00ABFF", "#35FFFB00" };
        string[] sour = { "/testchengjiu;component/Images/hub1.png", "/testchengjiu;component/Images/hub2.png", "/testchengjiu;component/Images/hub3.png", "/testchengjiu;component/Images/hub4.png" };
        private BackgroundWorker backroungWorker; // 后台多线程消息提示处理
        public main()
        {
            InitializeComponent();
            get_message();
            chengjiuhub();
            get_fuguang();
            StartLoadingData();
        }

        // 浮光掠影信息获取
        public void get_fuguang()
        {
            List<fuguang_data> fuguang = new List<fuguang_data>()
            {
                new fuguang_data { image = "http://tp4.sinaimg.cn/1849017127/50/40002000245/1", chengjiu = "小女子 达成【三饭大王】成就", name = "局长", time = "2012.4.23" },
                new fuguang_data { image = "/testchengjiu;component/Images/user/U1.jpg", chengjiu = "小庆_traditional 达成【五道杠】成就", name = "小庆_traditional", time = "2012.8.23" },
                new fuguang_data { image = "/testchengjiu;component/Images/user/U6.png", chengjiu = "石头不转移--Stone 达成【真●食堂的托】成就", name = "石头不转移--Stone", time = "2012.1.23" },
                new fuguang_data { image = "/testchengjiu;component/Images/user/U3.jpg", chengjiu = "M-ejam 达成【毅丝不挂】成就", name = "M-ejam", time = "2012.12.23" },
                new fuguang_data { image = "/testchengjiu;component/Images/user/U4.jpg", chengjiu = "中大软件学院张硕辰 达成【热爱祖国】成就", name = "中大软件学院张硕辰", time = "2012.11.23" }
            };
            fuguanglueying.ItemsSource = fuguang;
        }

        // 心路历程信息获取
        public void get_message()
        {
            List<user> xinlu_list = new List<user>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "8785169");
            parameters.Add("date", "2011/12/16");

            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    JObject userobj = JObject.Parse(e.Result);
                    int i = 2;
                    JObject userdata_info = (JObject)userobj["detail"];
                    JArray mess2011 = (JArray)userdata_info["1"];
                    JArray mess2012 = (JArray)userdata_info["2"];
                    int p = 0;
                    foreach (var obj in mess2011)
                    {
                        i = (i+2) % 4;
                        user a = new user()
                        {
                            pid = obj["id"].Value<string>(),
                            content = obj["content"].Value<string>(),
                            posttime = obj["posttime"].Value<string>(),
                            source = "",
                            source2 = "",
                            title = obj["title"].Value<string>(),
                            color1 = col[i],
                            color2 = col[i+1]
                        };
                        if (mess2012.Count == 0 || p > mess2012.Count - 1)
                        {
                            a.pid2 = "";
                            a.posttime2 = obj["posttime"].Value<string>();
                            a.content2 = "今天没有消息";
                        }
                        else
                        {
                            a.pid2 = mess2012[p]["id"].Value<string>();
                            a.posttime2 = mess2012[p]["posttime"].Value<string>();
                            a.content2 = mess2012[p]["content"].Value<string>();
                        }
                        p++;
                        
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
                new chengjiuxitong_hubtile{ImageUri = "/testchengjiu;component/Images/young.jpg", GroupTag="TileGroup", Message="", Notification="", Title="青春"},
                new chengjiuxitong_hubtile{ImageUri = "", GroupTag="TileGroup", Message="", Notification="", Title="我的成就"}

            };
            tileList.ItemsSource = title;

        }

        // 时光脚步的hubtile点击事件
        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.chengjiu_title = (((chengjiuxitong_hubtile)(((System.Windows.Controls.Primitives.Selector)(this.tileList)).SelectedValue)).Title);
            switch(App.chengjiu_title)
            {
                case "电影":
                    NavigationService.Navigate(new Uri("/extra_page/movie_page.xaml", UriKind.Relative));
                    break;
                case "我的成就":
                    NavigationService.Navigate(new Uri("/chengjiu_table/My_chengjiu.xaml", UriKind.Relative));
                    break;
                default: 
                    NavigationService.Navigate(new Uri("/daohang/chengjiu_congtent.xaml", UriKind.Relative));
                    break;
            }
            
        }

        private void focus_appbar_Click(object sender, EventArgs e)
        {
            listBox_xinlu.Focus();
            get_message();
            StartLoadingData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/daohang/pinglun.xaml", UriKind.Relative));
        }

        private void add_appbar_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/appbar/send.xaml", UriKind.Relative));
        }

        // 后台处理消息提示
        private void StartLoadingData()
        {
            //使用BackgroundWorker在单独的线程上执行操作
            backroungWorker = new BackgroundWorker();
            //调用 RunWorkerAsync后台操作时引发此事件，即后台要处理的事情写在这个事件里面
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            //当后台操作完成事件
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            //开始执行后台操作
            backroungWorker.RunWorkerAsync();
        }

        //后台操作完成
        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                //this.popup.IsOpen = false;//关闭popup 注意要使用Dispatcher.BeginInvoke开跟UI通讯
            }
            );
        }
        //后台操作处理
        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 程序初始化处理 这里只是模拟了一下
            Thread.Sleep(2000);
            
                this.Dispatcher.BeginInvoke(() =>
                {
                    SoundController sc = new SoundController();
                    sc.PlaySound(@"Sounds\isdone.wav"); 
                    if (App.send_mess == "我到华工了")
                        //this.popup.IsOpen = false;//关闭popup 注意要使用Dispatcher.BeginInvoke开跟UI通讯st
                        MessageBox.Show("【到达华工】成就达成");
                    else if(App.send_mess == "我丢东西了")
                         MessageBox.Show("【折翼天使】成就+1");


                });
        }
    }
}