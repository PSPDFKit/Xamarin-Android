using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using PSPDFKit;
using PSPDFKit.Configuration.Activity;

using SampleTools;
using Xamarin.Forms.Platform.Android;

// This will add your license key into AndroidManifest.xml at build time. For more info on how this Attribute works see:
// https://developer.xamarin.com/guides/android/advanced_topics/working_with_androidmanifest.xml/
[assembly: MetaData (
	name: "pspdfkit_license_key",
	Value = "LICENSE_KEY_GOES_HERE"
)]

namespace PSPDFCatalog {
	// @style/PSPDFCatalog.Theme.Light
	[Activity (Label = "PSPDFKit", MainLauncher = true, Theme = "@style/PSPDFCatalog.Theme.Light", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : AppCompatActivity {

		Toolbar toolbar;
		FixedDrawerLayout drawerLayout;
		View settingsDrawer;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			CrossCurrentActivity.Current.Init (this, savedInstanceState);
			Xamarin.Essentials.Platform.Init (this, savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			toolbar = FindViewById<Toolbar> (Resource.Id.toolbar);
			drawerLayout = FindViewById<FixedDrawerLayout> (Resource.Id.main_drawer);
			settingsDrawer = FindViewById<View> (Resource.Id.settings_drawer);

			// Setup action bar
			SetSupportActionBar (toolbar);
			var ab = SupportActionBar;

			ab.SetDisplayShowHomeEnabled (true);
			ab.SetDisplayUseLogoEnabled (true);
			ab.SetLogo (Resource.Drawable.ic_logo_padded);
			ab.Title = $"PSPDFKit v{PSPDFKitGlobal.Version}";

			// The table view is handled by Xamarin.Forms.
			// You can see available PDF samples inside MainMenuPage.xaml.cs
			// or inside the 'Catalog' folder in the solution pad.
			global::Xamarin.Forms.Forms.Init (this, savedInstanceState);
			var page = new MainMenuPage ();
			page.OptionSelected += Page_OptionSelected;
			var frag = page.CreateSupportFragment (this);

			if (SupportFragmentManager.FindFragmentById (Resource.Id.menu_list_fragment_frame_layout) == null) {
				SupportFragmentManager
					.BeginTransaction ()
					.Replace (Resource.Id.menu_list_fragment_frame_layout, frag, "main")
					.Commit ();
			}

			// Setup settings panel, also handled by Xamarin.Forms
			if (settingsDrawer != null) {
				Utils.SetProperNavigationDrawerWidth (settingsDrawer);

				var settingsPage = new SettingsPage ();
				var fragx = settingsPage.CreateSupportFragment (this);

				// Add the preferences to the drawer
				if (SupportFragmentManager.FindFragmentById (Resource.Id.settings_drawer) == null) {
					SupportFragmentManager
						.BeginTransaction ()
						.Replace (Resource.Id.settings_drawer, fragx)
						.Commit ();
				}
			}
		}

		async void Page_OptionSelected (object sender, OptionSelectedEventArgs e)
		{
			var page = sender as MainMenuPage;

			// We need storage permission, we can use Permissions Plugin to help here
			var status = await CrossPermissions.Current.CheckPermissionStatusAsync<StoragePermission> ();
			if (status != PermissionStatus.Granted) {
				if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync (Permission.Storage))
					await page.DisplayAlert ("Need Storage Permission", "Need access to store yor PDF documents", "OK");

				status = await CrossPermissions.Current.RequestPermissionAsync <StoragePermission> ();
			}

			if (status == PermissionStatus.Granted) {
				// Show example if permission is granted.
				// Create an instance of the sample class and launch it.
				var example = (ILaunchable) Activator.CreateInstance (e.SampleClass);
				example.LaunchExample (this, GetConfiguration (ApplicationContext));

			} else if (status != PermissionStatus.Unknown)
				await page.DisplayAlert ("Storage Permission Denied", "Cannot continue, try again.", "OK");
		}

		PdfActivityConfiguration.Builder GetConfiguration (Context ctx) => SettingsPage.GetConfiguration (ctx);

		public override void OnRequestPermissionsResult (int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
		{
			PermissionsImplementation.Current.OnRequestPermissionsResult (requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult (requestCode, permissions, grantResults);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.activity_settings, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Resource.Id.action_settings) {
				if (drawerLayout == null || settingsDrawer == null) return false;

				if (drawerLayout.IsDrawerOpen (settingsDrawer))
					drawerLayout.CloseDrawer (settingsDrawer);
				else
					drawerLayout.OpenDrawer (settingsDrawer);
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}

		public override void OnBackPressed ()
		{
			if (drawerLayout != null && drawerLayout.IsDrawerOpen (settingsDrawer))
				drawerLayout.CloseDrawer (settingsDrawer);
			else
				base.OnBackPressed ();
		}
	}
}

