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
                
                new chengjiu_detail{Image="", meassage="三饭大王", isdone="/testchengjiu;component/Images/isdone.png"},
                new chengjiu_detail{Image="", meassage="君臣侠", isdone="/testchengjiu;component/Images/isdone.png"},
                new chengjiu_detail{Image="", meassage="咖啡厅老客户", isdone="/testchengjiu;component/Images/isdone.png"},
                new chengjiu_detail{Image="", meassage="清真大王", isdone=""},
                new chengjiu_detail{Image="", meassage="真。食堂的托", isdone=""},
                new chengjiu_detail{Image="", meassage="衣食无忧", isdone=""}
            };

            listbox_chengjiu.ItemsSource = detail;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = ((chengjiu_detail)(((System.Windows.Controls.Primitives.Selector)(this.listbox_chengjiu)).SelectedItem)).meassage;
            int i = 0;
            //string a = this.listbox_chengjiu.SelectedItem.ToString();
            //this.listbox_chengjiu.SelectedItem
            
        }

        private void chengjiu_SP_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.chengjiu_list = ((chengjiu_detail)(((System.Windows.Controls.Primitives.Selector)(this.listbox_chengjiu)).SelectedItem)).meassage;
            NavigationService.Navigate(new Uri("/daohang/chengjiu_info.xaml", UriKind.Relative));
        }
    }
}