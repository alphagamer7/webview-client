package crc64935e8a132b24a1e5;


public class RbDownloadListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.webkit.DownloadListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDownloadStart:(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;J)V:GetOnDownloadStart_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_JHandler:Android.Webkit.IDownloadListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("WebViewTestApp.RbDownloadListener, WebViewTestApp", RbDownloadListener.class, __md_methods);
	}


	public RbDownloadListener ()
	{
		super ();
		if (getClass () == RbDownloadListener.class)
			mono.android.TypeManager.Activate ("WebViewTestApp.RbDownloadListener, WebViewTestApp", "", this, new java.lang.Object[] {  });
	}

	public RbDownloadListener (android.content.Context p0)
	{
		super ();
		if (getClass () == RbDownloadListener.class)
			mono.android.TypeManager.Activate ("WebViewTestApp.RbDownloadListener, WebViewTestApp", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onDownloadStart (java.lang.String p0, java.lang.String p1, java.lang.String p2, java.lang.String p3, long p4)
	{
		n_onDownloadStart (p0, p1, p2, p3, p4);
	}

	private native void n_onDownloadStart (java.lang.String p0, java.lang.String p1, java.lang.String p2, java.lang.String p3, long p4);

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
