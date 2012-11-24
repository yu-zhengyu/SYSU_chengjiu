using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace testchengjiu.data
{
    public class chengjiuxitong_hubtile
    {
        public string Title { get; set; }
        public string Notification{ get; set; }
        public bool DisplayNotification { get { return !string.IsNullOrEmpty(this.Notification); } }
        public string Message{ get; set; }
        public string GroupTag{ get; set; }
        public string ImageUri { get; set; }
    }
}
