using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Android.Net.Http;
using Android.Content;

namespace WebViewTestApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        WebView web_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);
            web_view = FindViewById<WebView>(Resource.Id.webView);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            web_view.Settings.AllowFileAccessFromFileURLs = true;
            web_view.Settings.AllowUniversalAccessFromFileURLs = true;
            web_view.Settings.DatabaseEnabled = true;
            web_view.Settings.DomStorageEnabled = true;
            web_view.Settings.AllowFileAccess = true;
            web_view.SetWebViewClient(new TestWebViewClient());
            web_view.SetWebChromeClient(new RbWebChromeClient(this));
            //--- PDF testing
            web_view.SetDownloadListener(new RbDownloadListener(this));
            web_view.LoadUrl("https://www.rambase.net/Default.aspx?mobileapp=true#/mobileapp");
        }

     

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class TestWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            //view.LoadUrl(url);
            return false;
        }

        // For API level 24 and later
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            //view.LoadUrl(request.Url.ToString());
            return false;
        }

        public override void OnReceivedSslError(WebView view, SslErrorHandler handler, SslError error)
        {
            handler.Proceed(); // Ignore SSL certificate errors
        }

        public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
        {

            base.OnReceivedError(view, request, error);
        }
    }

    class RbWebChromeClient : WebChromeClient
    {
        MainActivity mainActivity;
        public RbWebChromeClient(MainActivity activity)
        {
            this.mainActivity = activity;
        }
        public override void OnProgressChanged(WebView view, int newProgress)
        {
            base.OnProgressChanged(view, newProgress);
        }
    }

     class RbDownloadListener : Java.Lang.Object, IDownloadListener
    {
        Context cont;
        public RbDownloadListener(Context context)
        {
            cont = context;
        }

        public void OnDownloadStart(string url, string userAgent, string contentDisposition, string mimetype, long contentLength)
        {
               DownloadManager.Request request = new DownloadManager.Request(
                   Android.Net.Uri.Parse(url));
            request.SetMimeType(mimetype);
            String cookies = CookieManager.Instance.GetCookie(url);
            request.AddRequestHeader("cookie", cookies);
            request.AddRequestHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddRequestHeader("Content-type", "application/x-www-form-urlencoded");

            request.AllowScanningByMediaScanner();
            request.SetAllowedOverRoaming(false);
            request.SetNotificationVisibility(DownloadVisibility.VisibleNotifyCompleted);
            request.SetDestinationInExternalPublicDir(Android.OS.Environment.DirectoryDownloads, URLUtil.GuessFileName(url, contentDisposition, mimetype));
            var manager = (DownloadManager)cont.GetSystemService(Android.Content.Context.DownloadService);
            manager.Enqueue(request);

        }




    }
}

