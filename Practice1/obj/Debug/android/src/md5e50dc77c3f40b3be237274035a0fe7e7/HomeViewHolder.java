package md5e50dc77c3f40b3be237274035a0fe7e7;


public class HomeViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Practice1.Adapters.HomeViewHolder, Practice1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HomeViewHolder.class, __md_methods);
	}


	public HomeViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == HomeViewHolder.class)
			mono.android.TypeManager.Activate ("Practice1.Adapters.HomeViewHolder, Practice1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
