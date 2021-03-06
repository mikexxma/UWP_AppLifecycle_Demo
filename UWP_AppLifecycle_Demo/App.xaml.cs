﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UWP_AppLifecycle_Demo
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
         
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            //Resuming += OnResuming;
            //EnteredBackground += OnEnterBackground;
            //LeavingBackground += OnLeaveBackgroud;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;



            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    Debug.WriteLine("Terminated 系统关闭app 后 rootframe被销毁");
                }

                if (e.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
                {
                    Debug.WriteLine("ClosedByUser 用户关闭app 后 rootframe被销毁");
                }

                if (e.PreviousExecutionState == ApplicationExecutionState.NotRunning)
                {
                    //保存数据失败的时候
                    //App 第一次运行
                    Debug.WriteLine("NotRunning App 第一次跑");
                }

                if (e.PreviousExecutionState == ApplicationExecutionState.Suspended)
                {
                   //后台到前台的时候
                }
                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PreviousExecutionState == ApplicationExecutionState.Running)//app 先前的状态是运行此时 root frame没有被销毁(用户重新打开app的时候)
            {
                //后台到前台的时候
                Debug.WriteLine("app 先前的状态是运行此时 root frame没有被销毁(用户重新打开app的时候) 而且还不是从任务栏中打开, 是app 在后台用户点击app图标打开");
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {

                    if (e.PreviousExecutionState == ApplicationExecutionState.Running)
                    {
                        Debug.WriteLine("app 先前的状态是运行此时 root frame没有被销毁(用户重新打开app的时候) 但是rootframe content被销毁了 而且还不是从任务栏中打开, 是app 在后台用户点击app图标打开");
                    }

                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }

            Debug.WriteLine("Hello I am OnLaunched()");
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {

            Debug.WriteLine("Hello I am OnSuspending()");
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();

        }

        protected override void OnActivated(IActivatedEventArgs args)
        {

            Debug.WriteLine("Hello I am OnActivated() "+args.ToString());
        }


        private void OnResuming<T> (object sender, T e)
        {

            Debug.WriteLine("Hello I am OnResuming() " + e.ToString());
        }

        private void OnEnterBackground(object sender, EnteredBackgroundEventArgs e)
        {
            Debug.WriteLine("Hello I am OnEnterBackground() " + e.ToString());
        }

        private void OnLeaveBackgroud(object sender, LeavingBackgroundEventArgs e)
        {
            Debug.WriteLine("Hello I am OnLeaveBackgroud() " + e.ToString());
        }

        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs e)
        {
            Debug.WriteLine("Hello I am OnBackgroundActivated() " + e.ToString());
        }

    }
}
