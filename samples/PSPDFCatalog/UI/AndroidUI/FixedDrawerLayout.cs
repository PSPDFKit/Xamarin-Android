using System;
using Android.Content;
using AndroidX.DrawerLayout.Widget;
using Android.Util;

namespace PSPDFCatalog {

	// Drawer layout has a crash bug while handling multi-touch. Temporary workaround is to eat the
	// exception when that happens - it does not effect functionality.
	public class FixedDrawerLayout : DrawerLayout {

		public FixedDrawerLayout (Context context) : base (context)
		{
		}

		public FixedDrawerLayout (Context context, IAttributeSet attrs) : base (context, attrs)
		{
		}

		public FixedDrawerLayout (Context context, IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
		{
		}

		public override bool OnInterceptTouchEvent (Android.Views.MotionEvent ev)
		{
			try {
				return base.OnInterceptTouchEvent (ev);
			} catch (Exception ex) {
				Log.Error ("FixedDrawerLayout", $"Exception: {ex.Message}");
				return false;
			}
		}
	}
}
