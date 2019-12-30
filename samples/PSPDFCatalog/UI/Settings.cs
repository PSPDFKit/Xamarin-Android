using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.Configuration.Page;
using PSPDFKit.Configuration.Theming;

namespace PSPDFCatalog {
	public class Settings : BaseViewModel {

		static ISettings AppSettings { get; } = CrossSettings.Current;

		static Settings settings;
		public static Settings Current {
			get => settings ?? (settings = new Settings ());
		}

		const string ScrollDirectionKey = "PageScrollDirection";
		static readonly string ScrollDirectionDefault = PageScrollDirection.Horizontal.Name ();
		public string ScrollDirection {
			get => AppSettings.GetValueOrDefault (ScrollDirectionKey, ScrollDirectionDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ScrollDirectionKey, value))
					OnPropertyChanged ();
			}
		}

		const string PageLayoutKey = "PageLayoutMode";
		static readonly string PageLayoutKeyDefault = PageLayoutMode.Auto.Name ();
		public string PageLayout {
			get => AppSettings.GetValueOrDefault (PageLayoutKey, PageLayoutKeyDefault);
			set {
				if (AppSettings.AddOrUpdateValue (PageLayoutKey, value))
					OnPropertyChanged ();
			}
		}

		const string ScrollModeKey = "ScrollMode";
		static readonly bool ScrollModeDefault = false;
		public bool ScrollMode {
			get => AppSettings.GetValueOrDefault (ScrollModeKey, ScrollModeDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ScrollModeKey, value))
					OnPropertyChanged ();
			}
		}

		const string FitModeKey = "FitMode";
		static readonly bool FitModeDefault = true;
		public bool FitMode {
			get => AppSettings.GetValueOrDefault (FitModeKey, FitModeDefault);
			set {
				if (AppSettings.AddOrUpdateValue (FitModeKey, value))
					OnPropertyChanged ();
			}
		}

		const string RestoreLastViewedPageKey = "RestoreLastViewedPage";
		static readonly bool RestoreLastViewedPageDefault = false;
		public bool RestoreLastViewedPage {
			get => AppSettings.GetValueOrDefault (RestoreLastViewedPageKey, RestoreLastViewedPageDefault);
			set {
				if (AppSettings.AddOrUpdateValue (RestoreLastViewedPageKey, value))
					OnPropertyChanged ();
			}
		}

		const string ShowPageNumberOverlayKey = "ShowPageNumberOverlay";
		static readonly bool ShowPageNumberOverlayDefault = true;
		public bool ShowPageNumberOverlay {
			get => AppSettings.GetValueOrDefault (ShowPageNumberOverlayKey, ShowPageNumberOverlayDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ShowPageNumberOverlayKey, value))
					OnPropertyChanged ();
			}
		}

		const string ShowPageLabelsKey = "ShowPageLabels";
		static readonly bool ShowPageLabelsDefault = true;
		public bool ShowPageLabels {
			get => AppSettings.GetValueOrDefault (ShowPageLabelsKey, ShowPageLabelsDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ShowPageLabelsKey, value))
					OnPropertyChanged ();
			}
		}

		const string UIViewModeKey = "UIViewMode";
		static readonly string UIViewModeDefault = UserInterfaceViewMode.UserInterfaceViewModeAutomatic.Name ();
		public string UIViewMode {
			get => AppSettings.GetValueOrDefault (UIViewModeKey, UIViewModeDefault);
			set {
				if (AppSettings.AddOrUpdateValue (UIViewModeKey, value))
					OnPropertyChanged ();
			}
		}

		const string HideUIWhenCreatingAnnotationsKey = "HideUIWhenCreatingAnnotations";
		static readonly bool HideUIWhenCreatingAnnotationsDefault = true;
		public bool HideUIWhenCreatingAnnotations {
			get => AppSettings.GetValueOrDefault (HideUIWhenCreatingAnnotationsKey, HideUIWhenCreatingAnnotationsDefault);
			set {
				if (AppSettings.AddOrUpdateValue (HideUIWhenCreatingAnnotationsKey, value))
					OnPropertyChanged ();
			}
		}

		const string ThemeModeSettingKey = "ThemeModeSetting";
		static readonly string ThemeModeSettingDefault = ThemeMode.Default.Name ();
		public string ThemeModeSetting {
			get => AppSettings.GetValueOrDefault (ThemeModeSettingKey, ThemeModeSettingDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ThemeModeSettingKey, value))
					OnPropertyChanged ();
			}
		}

		const string FirstPageAlwaysSingleKey = "FirstPageAlwaysSingle";
		static readonly bool FirstPageAlwaysSingleDefault = false;
		public bool FirstPageAlwaysSingle {
			get => AppSettings.GetValueOrDefault (FirstPageAlwaysSingleKey, FirstPageAlwaysSingleDefault);
			set {
				if (AppSettings.AddOrUpdateValue (FirstPageAlwaysSingleKey, value))
					OnPropertyChanged ();
			}
		}

		const string ShowGapBetweenPagesKey = "ShowGapBetweenPages";
		static readonly bool ShowGapBetweenPagesDefault = false;
		public bool ShowGapBetweenPages {
			get => AppSettings.GetValueOrDefault (ShowGapBetweenPagesKey, ShowGapBetweenPagesDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ShowGapBetweenPagesKey, value))
					OnPropertyChanged ();
			}
		}

		const string EnableSearchKey = "EnableSearch";
		static readonly bool EnableSearchDefault = true;
		public bool EnableSearch {
			get => AppSettings.GetValueOrDefault (EnableSearchKey, EnableSearchDefault);
			set {
				if (AppSettings.AddOrUpdateValue (EnableSearchKey, value))
					OnPropertyChanged ();
			}
		}

		const string InlineSearchKey = "InlineSearch";
		static readonly bool InlineSearchDefault = true;
		public bool InlineSearch {
			get => AppSettings.GetValueOrDefault (InlineSearchKey, InlineSearchDefault);
			set {
				if (AppSettings.AddOrUpdateValue (InlineSearchKey, value))
					OnPropertyChanged ();
			}
		}

		const string ThumbnailsBarModeKey = "ThumbnailsBarMode";
		static readonly string ThumbnailsBarModeDefault = ThumbnailBarMode.ThumbnailBarModeFloating.Name ();
		public string ThumbnailsBarMode {
			get => AppSettings.GetValueOrDefault (ThumbnailsBarModeKey, ThumbnailsBarModeDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ThumbnailsBarModeKey, value))
					OnPropertyChanged ();
			}
		}

		const string ShowThumbnailGridKey = "ShowThumbnailGrid";
		static readonly bool ShowThumbnailGridDefault = true;
		public bool ShowThumbnailGrid {
			get => AppSettings.GetValueOrDefault (ShowThumbnailGridKey, ShowThumbnailGridDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ShowThumbnailGridKey, value))
					OnPropertyChanged ();
			}
		}

		const string EnableDocumentOutlineKey = "EnableDocumentOutline";
		static readonly bool EnableDocumentOutlineDefault = true;
		public bool EnableDocumentOutline {
			get => AppSettings.GetValueOrDefault (EnableDocumentOutlineKey, EnableDocumentOutlineDefault);
			set {
				if (AppSettings.AddOrUpdateValue (EnableDocumentOutlineKey, value))
					OnPropertyChanged ();
			}
		}

		const string EnableAnnotationListKey = "EnableAnnotationList";
		static readonly bool EnableAnnotationListDefault = true;
		public bool EnableAnnotationList {
			get => AppSettings.GetValueOrDefault (EnableAnnotationListKey, EnableAnnotationListDefault);
			set {
				if (AppSettings.AddOrUpdateValue (EnableAnnotationListKey, value))
					OnPropertyChanged ();
			}
		}

		const string EnableAnnotationEditingKey = "EnableAnnotationEditing";
		static readonly bool EnableAnnotationEditingDefault = true;
		public bool EnableAnnotationEditing {
			get => AppSettings.GetValueOrDefault (EnableAnnotationEditingKey, EnableAnnotationEditingDefault);
			set {
				if (AppSettings.AddOrUpdateValue (EnableAnnotationEditingKey, value))
					OnPropertyChanged ();
			}
		}

		const string EnableFormEditingKey = "EnableFormEditing";
		static readonly bool EnableFormEditingDefault = true;
		public bool EnableFormEditing {
			get => AppSettings.GetValueOrDefault (EnableFormEditingKey, EnableFormEditingDefault);
			set {
				if (AppSettings.AddOrUpdateValue (EnableFormEditingKey, value))
					OnPropertyChanged ();
			}
		}

		const string ShowShareActionKey = "ShowShareAction";
		static readonly bool ShowShareActionDefault = true;
		public bool ShowShareAction {
			get => AppSettings.GetValueOrDefault (ShowShareActionKey, ShowShareActionDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ShowShareActionKey, value))
					OnPropertyChanged ();
			}
		}

		const string ShowPrintActionKey = "ShowPrintAction";
		static readonly bool ShowPrintActionDefault = true;
		public bool ShowPrintAction {
			get => AppSettings.GetValueOrDefault (ShowPrintActionKey, ShowPrintActionDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ShowPrintActionKey, value))
					OnPropertyChanged ();
			}
		}

		const string InvertPageColorsKey = "InvertPageColors";
		static readonly bool InvertPageColorsDefault = false;
		public bool InvertPageColors {
			get => AppSettings.GetValueOrDefault (InvertPageColorsKey, InvertPageColorsDefault);
			set {
				if (AppSettings.AddOrUpdateValue (InvertPageColorsKey, value))
					OnPropertyChanged ();
			}
		}

		const string GrayscaleKey = "Grayscale";
		static readonly bool GrayscaleDefault = false;
		public bool Grayscale {
			get => AppSettings.GetValueOrDefault (GrayscaleKey, GrayscaleDefault);
			set {
				if (AppSettings.AddOrUpdateValue (GrayscaleKey, value))
					OnPropertyChanged ();
			}
		}

		const string EnableTextSelectionKey = "EnableTextSelection";
		static readonly bool EnableTextSelectionDefault = true;
		public bool EnableTextSelection {
			get => AppSettings.GetValueOrDefault (EnableTextSelectionKey, EnableTextSelectionDefault);
			set {
				if (AppSettings.AddOrUpdateValue (EnableTextSelectionKey, value))
					OnPropertyChanged ();
			}
		}

		const string ImmersiveModeKey = "ImmersiveMode";
		static readonly bool ImmersiveModeDefault = false;
		public bool ImmersiveMode {
			get => AppSettings.GetValueOrDefault (ImmersiveModeKey, ImmersiveModeDefault);
			set {
				if (AppSettings.AddOrUpdateValue (ImmersiveModeKey, value))
					OnPropertyChanged ();
			}
		}
	}
}
