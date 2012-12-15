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

namespace testchengjiu.daohang
{
    public partial class chengjiu_congtent : PhoneApplicationPage
    {
        public chengjiu_congtent()
        {
            
            InitializeComponent();
            get_chengjiu_list();
            PageTitle.Text = App.chengjiu_title + "成就";

        }

        public void get_chengjiu_list()
        {
            List<chengjiu_detail> detail = new List<chengjiu_detail>()
            {
                
                new chengjiu_detail{Image="", meassage="折翼天使", isdone=""},
                new chengjiu_detail{Image="", meassage="这辈子值了", isdone="/testchengjiu;component/Images/isdone.png"},
                new chengjiu_detail{Image="", meassage="五道杠", isdone="/testchengjiu;component/Images/isdone.png"},
                new chengjiu_detail{Image="", meassage="doublekill", isdone=""},
                new chengjiu_detail{Image="", meassage="弹无虚发", isdone=""},
                new chengjiu_detail{Image="", meassage="丝里逃生", isdone=""},
                new chengjiu_detail{Image="", meassage="四面楚歌", isdone=""},
                new chengjiu_detail{Image="", meassage="毅丝不挂", isdone=""}
            };

            listbox_chengjiu.ItemsSource = detail;
        }


        private void chengjiu_SP_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.chengjiu_list = ((chengjiu_detail)(((System.Windows.Controls.Primitives.Selector)(this.listbox_chengjiu)).SelectedItem)).meassage;
            NavigationService.Navigate(new Uri("/daohang/chengjiu_info.xaml", UriKind.Relative));
        }
    }
}