using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_AppLifecycle_Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.VisibilityChanged += WindowVisibilityChangedEventHandler;
            Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
            Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
            //Application.Current.EnteredBackground += new EnteredBackgroundEventHandler(OnEnterBackground);
            //Application.Current.LeavingBackground += new LeavingBackgroundEventHandler(OnLeavingBackground);
        }
        void WindowVisibilityChangedEventHandler(System.Object sender, Windows.UI.Core.VisibilityChangedEventArgs e)
        {
            Debug.WriteLine("VisibilityChanged");
            //需要预加载的东西 可以写在这里面
        }

        void App_Suspending(Object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            Debug.WriteLine("App_Suspending：");
            //需要预加载的东西 可以写在这里面
        }

        private void App_Resuming(Object sender, Object e)
        {
            Debug.WriteLine("App_Resuming：");
            // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
        }

        private void OnEnterBackground(System.Object sender, EnteredBackgroundEventArgs e)
        {
            Debug.WriteLine("OnEnterBackgroud：");
            
        }
        private void OnLeavingBackground(Object sender, LeavingBackgroundEventArgs e)
        {
            Debug.WriteLine("OnLeavingBackground：");
           
        }


    }
}
