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
    public partial class chengjiu_info : PhoneApplicationPage
    {
        public chengjiu_info()
        {
            InitializeComponent();
            PageTitle.Text = App.chengjiu_list;
            getmessage();
        }

        public void getmessage()
        {
            List<chengjiu_infomation> info = new List<chengjiu_infomation>()
            {
                new chengjiu_infomation{ message="中山大学第三饭堂，汇聚了广东所有美食的精髓。", image = "/testchengjiu;component/Images/fantang.png", friend1="http://tp4.sinaimg.cn/1849017127/50/40002000245/1", friend2="http://tp4.sinaimg.cn/1849017127/50/40002000245/1", friend3="http://tp4.sinaimg.cn/1849017127/50/40002000245/1", info="在三饭用餐  10 / 50"}
            };
            listbox_chengjiu.ItemsSource = info;
        }
    }
}