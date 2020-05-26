package crc64935e8a132b24a1e5;


public class RbWebChromeClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onProgressChanged:(Landroid/webkit/WebView;I)V:GetOnProgressChanged_Landroid_webkit_WebView_IHandler\n" +
			"";
		mono.android.Runtime.register ("WebViewTestApp.RbWebChromeClient, WebViewTestApp", RbWebChromeClient.class, __md_methods);
	}


	public RbWebChromeClient ()
	{
		super ();
		if (getClass () == RbWebChromeClient.class)
			mono.android.TypeManager.Activate ("WebViewTestApp.RbWebChromeClient, WebViewTestApp", "", this, new java.lang.Object[] {  });
	}

	public RbWebChromeClient (crc64935e8a132b24a1e5.MainActivity p0)
	{
		super ();
		if (getClass () == RbWebChromeClient.class)
			mono.android.TypeManager.Activate ("WebViewTestApp.RbWebChromeClient, WebViewTestApp", "WebViewTestApp.MainActivity, WebViewTestApp", this, new java.lang.Object[] { p0 });
	}


	public void onProgressChanged (android.webkit.WebView p0, int p1)
	{
		n_onProgressChanged (p0, p1);
	}

	private native void n_onProgressChanged (android.webkit.WebView p0, int p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
