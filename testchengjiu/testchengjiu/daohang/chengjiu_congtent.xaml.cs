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
            PageTitle.Text = App.chengjiu_title;

        }

        public void get_chengjiu_list()
        {
            List<chengjiu_detail> detail = new List<chengjiu_detail>()
            {
                
                new chengjiu_detail{Image="", meassage="fasfsdfsadfaeawfawef"},
                new chengjiu_detail{Image="", meassage="fasdfasfsadfsadfsdf"},
                new chengjiu_detail{Image="", meassage="adfasdfasfdasdfasdfsadfasf"},
                new chengjiu_detail{Image="", meassage="asdfasfdasfdasdf"},
                new chengjiu_detail{Image="", meassage="asfdasdfasdfasfd"},
                new chengjiu_detail{Image="", meassage="asdfasfdasdfasdfasfasfa"}
            };

            listbox_chengjiu.ItemsSource = detail;
        }
    }
}