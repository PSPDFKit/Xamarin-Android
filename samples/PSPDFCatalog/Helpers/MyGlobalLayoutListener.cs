using System;
using Android.Content;
using Android.OS;
using Android.Views;

namespace SampleTools {

	public static partial class Utils {

		// Port to C# of java source code at [1] under the Apache License, Version 2.0
		// [1]: https://github.com/consp1racy/material-navigation-drawer/blob/master/navigation-drawer/src/main/java/net/xpece/material/navigationdrawer/NavigationDrawerUtils.java
		public static void SetProperNavigationDrawerWidth (View view) => view.ViewTreeObserver.AddOnGlobalLayoutListener (new MyGlobalLayoutListener (view));
	}

	public class MyGlobalLayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener {

		View view;
		Context context;

		public MyGlobalLayoutListener (View view)
		{
			this.view = view;
			context = view.Context;
		}

		public void OnGlobalLayout ()
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean)
				view.ViewTreeObserver.RemoveOnGlobalLayoutListener (this);
			else
#pragma warning disable 0618
				view.ViewTreeObserver.RemoveGlobalOnLayoutListener (this);
#pragma warning restore 0618

			int smallestWidthPx = context.Resources.DisplayMetrics.WidthPixels
					< context.Resources.DisplayMetrics.HeightPixels
					? context.Resources.DisplayMetrics.WidthPixels
					: context.Resources.DisplayMetrics.HeightPixels;
			int drawerMargin = context.Resources.GetDimensionPixelOffset (PSPDFCatalog.Resource.Dimension.drawer_margin);

			view.LayoutParameters.Width = Math.Min (
					context.Resources.GetDimensionPixelSize (PSPDFCatalog.Resource.Dimension.drawer_max_width),
					smallestWidthPx - drawerMargin
				);
			view.RequestLayout ();
		}
	}
}
