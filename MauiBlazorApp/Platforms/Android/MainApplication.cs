﻿using Android.App;
using Android.Runtime;

[assembly: UsesPermission(Android.Manifest.Permission.Camera)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]

namespace MauiBlazorApp
{
#if DEBUG
    [Application(AllowBackup = false, UsesCleartextTraffic = true)]
#else
    [Application]
#endif
    public class MainApplication:MauiApplication
    {
        public MainApplication(IntPtr handle,JniHandleOwnership ownership)
            : base(handle,ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
