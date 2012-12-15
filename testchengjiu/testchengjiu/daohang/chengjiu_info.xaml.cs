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

                new chengjiu_infomation{ message="折翼天使:  我们都是折翼的天使， 只有拥抱才能一起飞翔！！～～", image = "/testchengjiu;component/Images/images.jpg", friend1="http://tp4.sinaimg.cn/1849017127/50/40002000245/1", friend2="/testchengjiu;component/Images/user/U1.jpg", friend3="/testchengjiu;component/Images/user/U5.jpg", info="丢东西达到10次以上" + App.count + " / 10"}
            };
            listbox_chengjiu.ItemsSource = info;
        }
    }
}