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
using System.Windows.Resources;
using System.IO;
using System.Collections.Generic;



// 读取文件的参考
namespace testchengjiu.data
{
    public class DataGetter
    {
        public class DataGetters
        {
            public DataGetters()
            {
                StreamResourceInfo sri = Application.GetResourceStream(new Uri("Content/ContentList.txt", UriKind.Relative));
                StreamReader sr = new StreamReader(sri.Stream, System.Text.Encoding.Unicode);
                string[] DiseaseList = sr.ReadToEnd().Split(',');
                sr.Close();

                for (int i = 0; i < DiseaseList.Length; i++)
                {
                    StreamResourceInfo temp_sri1 = Application.GetResourceStream(new Uri("Content/" + DiseaseList[i] + "/1.txt", UriKind.Relative));
                    StreamReader temp_sr1 = new StreamReader(temp_sri1.Stream, System.Text.Encoding.Unicode);
                    string temp_str1 = temp_sr1.ReadToEnd();
                    temp_sr1.Close();
                }
            }

        }
    }
}
