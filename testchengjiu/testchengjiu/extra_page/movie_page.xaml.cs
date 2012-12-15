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
using Microsoft.Phone;
using System.Windows.Media.Imaging;

namespace testchengjiu.extra_page
{
    public partial class movie_page : PhoneApplicationPage
    {
        public movie_page()
        {
            InitializeComponent();
            outline.Text = "《第11个前锋》是日本人气动漫《名侦探柯南》第16部剧场版，以足球为主题，与日本足球J联赛进行了合作。小学馆成立90周年纪念作品。于2012年4月14日在日本公映，首周日本票房达到6亿2974万日元，打破第13部《漆黑的追踪者》的5.9亿首周票房纪录，并成为周票房冠军。日本最终票房收入32.7亿日元，位列历史第3位。此剧场版已确定引进中国大陆，上映日期待定。";
            BitmapImage f1 = new BitmapImage(new Uri("/testchengjiu;component/Images/user/U1.jpg", UriKind.Relative));
            BitmapImage f2 = new BitmapImage(new Uri("/testchengjiu;component/Images/user/U2.jpg", UriKind.Relative));
            BitmapImage f3 = new BitmapImage(new Uri("/testchengjiu;component/Images/user/U3.jpg", UriKind.Relative));
            friend1.Source = f1;
            friend2.Source = f2;
            friend3.Source = f3;
        }

        private void wanted_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)isdone.IsChecked)
            {
                isdone.IsChecked = false;
            }
        }

        private void isdone_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)wanted.IsChecked)
            {
                wanted.IsChecked = false;
            }
        }
    }
}