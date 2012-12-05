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
using WeiboSdk;
using WeiboSdk.PageViews;
using System.Diagnostics;
using WindowsPhonePostClient;
using Newtonsoft.Json.Linq;

namespace testchengjiu.daohang
{
    public partial class weiboshouquan : PhoneApplicationPage
    {

        public weiboshouquan()
        {
            // 此处使用自己 AppKey 和 AppSecret，未经
            //审核的应用只支持用申请该Appkey的帐号来获取数据
            SdkData.AppKey = "2487979428";
            SdkData.AppSecret = "e84ae1b813c56f6f8b6a9919f2257739";
            // 您app设置的重定向页,必须一致
            SdkData.RedirectUri = "http://cxds.sysu.me";
            InitializeComponent();

        }

        private void weibo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //AuthenticationView.OAuth2VerifyCompleted = (e1, e2, e3) => VerifyBack(e1, e2, e3);
            //AuthenticationView.OBrowserCancelled = new EventHandler(cancleEvent);
            weibolongin("user", "pass");
            //ClientOAuth.GetAccessToken("8785169@163.com", "zhengyu19910808", (e1, e2, e3) =>
            //{
            //    if (true == e1)
            //    {
            //        Debug.WriteLine("accessToken:" + e3.accesssToken);
            //        Debug.WriteLine("refleshToken:" + e3.refleshToken);
            //        Debug.WriteLine("expriesIn:" + e3.expriesIn);
            //        App.AccessToken = e3.accesssToken;
            //        App.RefleshToken = e3.refleshToken;
            //    }
            //    else
            //    {
            //        if (e2.errCode == SdkErrCode.NET_UNUSUAL)
            //        {
            //            Debug.WriteLine("测试");
            //        }
            //        else if (e2.errCode == SdkErrCode.SERVER_ERR)
            //            Debug.WriteLine("服务器返回错误，错误码:" + e2.specificCode);
            //    }
            //});
            //其它通知事件..
            //Deployment.Current.Dispatcher.BeginInvoke(() =>
            //{
            //    NavigationService.Navigate(new Uri("/WeiboSdk;component/PageViews/AuthenticationView.xaml", UriKind.Relative));
            //});
            
        }

        // 返回事件
        private void cancleEvent(object sender, EventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                NavigationService.GoBack();
            });
        }

        //授权事件
        private void VerifyBack(bool isSucess, SdkAuthError errCode, SdkAuth2Res response)
        {
            if (errCode.errCode == SdkErrCode.SUCCESS)
            {
                if (null != response)
                {
                    App.AccessToken = response.accesssToken;
                    App.RefleshToken = response.refleshToken;
                    //NavigationService.Navigate(new Uri("/daohang/weiboshouquan.xaml", UriKind.Relative));
                }

                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    //跳至内容分享功能
                    //新建一个 SdkSend 实例
                    SdkShare sdkSend = new SdkShare();
                    //设置OAuth2.0的access_token
                    sdkSend.AccessToken = App.AccessToken;
                    sdkSend.Completed = SendCompleted;

                    //调用Show方法展现页面的跳转
                    sdkSend.Show();
                    
                });
            }
            else if (errCode.errCode == SdkErrCode.NET_UNUSUAL)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("检查网络");
                });
            }
            else if (errCode.errCode == SdkErrCode.SERVER_ERR)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("服务器返回错误，错误代码:" + errCode.specificCode);
                });
            }
            else
                Debug.WriteLine("Other Err.");
        }

        void SendCompleted(object sender, SendCompletedEventArgs e)
        {
            if (e.IsSendSuccess)
            {
                MessageBox.Show("发送成功");
                NavigationService.Navigate(new Uri("/WeiboSdk;component/PageViews/AuthenticationView.xaml", UriKind.Relative));
            }
            else
                MessageBox.Show(e.Response, e.ErrorCode.ToString(), MessageBoxButton.OK);
        }

        private void renren_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/main.xaml", UriKind.Relative));
        }

        void weibolongin(string user, string password)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("username", "zhengyu");
            parameters.Add("type", "weibo");
            parameters.Add("token", "2.00toRIBC9G_4iC27d85d58ee03HlfL");
            PostClient proxy = new PostClient(parameters);
            proxy.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error == null)
                {
                    if (e.Result == "")
                    {
                        MessageBox.Show("亲，你的网络可能有问题了。");
                    }
                    else
                    {
                        try
                        {
                            JObject userobj = JObject.Parse(e.Result);
                            if (userobj["info"].ToString() == "success")
                            {
                             
                                //if (((JObject)((JObject)userobj["detail"])["detail"]).ToString() == "[]")
                                //{
                                NavigationService.Navigate(new Uri("/mail.xaml", UriKind.Relative));
                                //}
                                //else
                                //{
                                //    NavigationService.Navigate(new Uri("/main.xaml", UriKind.Relative));
                                //}
                            }
                        }
                        catch
                        {
                            MessageBox.Show("亲，你的网络可能有问题了。");
                        }
                    }
                }

            };
            proxy.DownloadStringAsync(new Uri("http://cxds.sysu.me/user/impower", UriKind.Absolute));
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/main.xaml", UriKind.Relative));
        }
    }
}