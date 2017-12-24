using System;
using System.Collections.Generic;
using System.Linq;
using AndroidHUD;
using Plugin.CurrentActivity;
using Plugin.Settings;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.Configuration.Page;
using PSPDFKit.Configuration.Theming;
using SampleTools;
using Xamarin.Forms;

namespace PSPDFCatalog {
	public class SettingsViewModel : BaseViewModel {

		public List<EnumListItem> PageScrollDirectionValues => SettingsData.PageScrollDirectionValues;
		EnumListItem selectedPageScrollDirection;
		public EnumListItem SelectedPageScrollDirection {
			get => selectedPageScrollDirection ?? (selectedPageScrollDirection = PageScrollDirectionValues.FirstOrDefault (p => p.Value == Settings.ScrollDirection));
			set {
				if (value != selectedPageScrollDirection) {
					selectedPageScrollDirection = value;
					Settings.ScrollDirection = value.Value;
					OnPropertyChanged ();
				}
			}
		}

		public List<EnumListItem> PageLayoutModeValues => SettingsData.PageLayoutModeValues;
		EnumListItem selectedPageLayoutMode;
		public EnumListItem SelectedPageLayoutMode {
			get => selectedPageLayoutMode ?? (selectedPageLayoutMode = PageLayoutModeValues.FirstOrDefault (p => p.Value == Settings.PageLayout));
			set {
				if (value != selectedPageLayoutMode) {
					selectedPageLayoutMode = value;
					Settings.PageLayout = value.Value;
					OnPropertyChanged ();
				}
			}
		}

		public List<EnumListItem> ThemeModeValues => SettingsData.ThemeModeValues;
		EnumListItem selectedThemeMode;
		public EnumListItem SelectedThemeMode {
			get => selectedThemeMode ?? (selectedThemeMode = ThemeModeValues.FirstOrDefault (p => p.Value == Settings.ThemeModeSetting));
			set {
				if (value != selectedThemeMode) {
					selectedThemeMode = value;
					Settings.ThemeModeSetting = value.Value;
					OnPropertyChanged ();
				}
			}
		}

		public List<EnumListItem> UserInterfaceViewModeValues => SettingsData.UserInterfaceViewModeValues;
		EnumListItem selectedUserInterfaceViewMode;
		public EnumListItem SelectedUserInterfaceViewMode {
			get => selectedUserInterfaceViewMode ?? (selectedUserInterfaceViewMode = UserInterfaceViewModeValues.FirstOrDefault (p => p.Value == Settings.UIViewMode));
			set {
				if (value != selectedUserInterfaceViewMode) {
					selectedUserInterfaceViewMode = value;
					Settings.UIViewMode = value.Value;
					OnPropertyChanged ();
				}
			}
		}

		public List<EnumListItem> ThumbnailBarModeValues => SettingsData.ThumbnailBarModeValues;
		EnumListItem selectedThumbnailBarMode;
		public EnumListItem SelectedThumbnailBarMode {
			get => selectedThumbnailBarMode ?? (selectedThumbnailBarMode = ThumbnailBarModeValues.FirstOrDefault (p => p.Value == Settings.ThumbnailsBarMode));
			set {
				if (value != selectedThumbnailBarMode) {
					selectedThumbnailBarMode = value;
					Settings.ThumbnailsBarMode = value.Value;
					OnPropertyChanged ();
				}
			}
		}

		Command clearCacheCommand;
		public Command ClearCacheCommand {
			get => clearCacheCommand ?? (clearCacheCommand = new Command (() => {
				var activity = CrossCurrentActivity.Current.Activity;
				PSPDFKit.PSPDFKitGlobal.ClearCaches (activity, true);
				AndHUD.Shared.ShowToast (activity, "Cache cleared.", timeout: TimeSpan.FromSeconds (1), centered: false);
			}));
		}

		Command resetSettingsCommand;
		public Command ResetSettingsCommand {
			get => resetSettingsCommand ?? (resetSettingsCommand = new Command (() => {
				CrossSettings.Current.Clear ();
				Environment.Exit (0);
			}));
		}
	}

	static class SettingsData {
		public static List<EnumListItem> PageScrollDirectionValues = PageScrollDirection.Values ().Select (arg => new EnumListItem { Value = arg.Name (), DisplayName = arg.Name ().ToTitleCase () }).ToList ();
		public static List<EnumListItem> PageLayoutModeValues = PageLayoutMode.Values ().Select (arg => new EnumListItem { Value = arg.Name (), DisplayName = arg.Name ().ToTitleCase () }).ToList ();
		public static List<EnumListItem> ThemeModeValues = ThemeMode.Values ().Select (arg => new EnumListItem { Value = arg.Name (), DisplayName = arg.Name ().ToTitleCase () }).ToList ();
		public static List<EnumListItem> UserInterfaceViewModeValues = UserInterfaceViewMode.Values ().Select (arg => new EnumListItem { Value = arg.Name (), DisplayName = arg.Name ().ToTitleCase (true, "USER_INTERFACE_VIEW_MODE_") }).ToList ();
		public static List<EnumListItem> ThumbnailBarModeValues = ThumbnailBarMode.Values ().Select (arg => new EnumListItem { Value = arg.Name (), DisplayName = arg.Name ().ToTitleCase (true, "THUMBNAIL_BAR_MODE_") }).ToList ();

	}
}
