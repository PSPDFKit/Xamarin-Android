
using System;
using System.Collections.Generic;

using Android.App;
using Android.Runtime;
using Android.Views;
using PSPDFKit.Annotations;
using PSPDFKit.Annotations.Configuration;
using PSPDFKit.Document;
using PSPDFKit.UI;
using PSPDFKit.UI.SpecialMode.Controller;

namespace PSPDFCatalog {
    [Activity (Label = "Annotation Configuration", WindowSoftInputMode = SoftInput.AdjustNothing)]
    public class AnnotationConfigurationExampleActivity : PdfActivity {

        // TODO: THIS SAMPLE ONLY WORKS IF minSdkVersion IS SET TO "24"
        // IS THIS IS SET TO A LOWER VERSION THIS SAMPLE WILL CRASH WITH
        // "no static method found"

        public override void OnDocumentLoaded (IPdfDocument document)
        {
            base.OnDocumentLoaded (document);

            var fragment = PdfFragment;
            if (fragment != null) {
                ConfigureFreeTextDefaults (fragment);
                ConfigureInkDefaults (fragment);
                ConfigureHighlightDefaults (fragment);
            }
        }

        /**
         * Shows how to set annotation configuration for free-text annotations
         * and control which properties are going to be displayed in annotation inspector.
         */
        private void ConfigureFreeTextDefaults (PdfFragment fragment)
        {
            // Notes:
            // Unfortunatelly due to C# vs Java differences we need to heavily
            // relly on JavaCast<T> to cast back and fort on the needed configuration
            // type IFreeTextAnnotationConfigurationBuilder and at the end to call
            // Build we need to cast it to IAnnotationConfigurationBuilder

            // Annotation configuration can be configured through PdfFragment for each annotation type.
            fragment.AnnotationConfiguration.Put (AnnotationType.Freetext,
                IFreeTextAnnotationConfiguration.Builder (this)
                // Configure which color is used when creating free-text annotations.
                .SetDefaultColor (Android.Graphics.Color.Rgb (0, 0, 0)).JavaCast<IFreeTextAnnotationConfigurationBuilder> ()
                // Configure which colors are going to be available in the color picker.
                .SetAvailableColors (new List<Java.Lang.Integer> {
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (255, 255, 255),
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (224, 224, 224),
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (158, 158, 158),
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (66, 66, 66),
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (0, 0, 0),
                }).JavaCast<IFreeTextAnnotationConfigurationBuilder> ()
                // Configure default text size (in pt).
                .SetDefaultTextSize (24).JavaCast<IFreeTextAnnotationConfigurationBuilder> ()
                // Only the color property will be editable in the annotation inspector.
                .SetSupportedProperties (Java.Util.EnumSet.Of (AnnotationProperty.Color)).JavaCast<IFreeTextAnnotationConfigurationBuilder>()
                // Disable annotation preview for free-text annotation.
                .SetPreviewEnabled (false)
                .JavaCast<IAnnotationConfigurationBuilder> ()
                .Build()
            );
        }

        /**
         * Shows how to force annotation defaults.
         */
        private void ConfigureInkDefaults (PdfFragment fragment)
        {
            // Notes:
            // Unfortunatelly due to C# vs Java differences we need to heavily
            // relly on JavaCast<T> to cast back and fort on the needed configuration
            // type IInkAnnotationConfigurationBuilder and at the end to call
            // Build we need to cast it to IAnnotationConfigurationBuilder

            // Annotation configuration can be configured through PdfFragment for each annotation type.
            fragment.AnnotationConfiguration.Put (AnnotationTool.Ink,
                IInkAnnotationConfiguration.Builder (this)

                // Configure which color is used when creating ink annotations.
                .SetDefaultColor (Android.Graphics.Color.Rgb (252, 237, 140)).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // Configure which colors are going to be available in the color picker.
                .SetAvailableColors (new List<Java.Lang.Integer> {
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (244, 67, 54), // RED
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (139, 195, 74), // LIGHT GREEN
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (33, 150, 243), // BLUE
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (252, 237, 140), // YELLOW
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (233, 30, 99) // PINK
                }).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // Configure thickness picker range and default thickness.
                .SetDefaultThickness (5).JavaCast<IInkAnnotationConfigurationBuilder> ()
                .SetMinThickness (1).JavaCast<IInkAnnotationConfigurationBuilder> ()
                .SetMaxThickness (20).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // When true attributes like default color are always used as default when creating annotations.
                // When false last edited value is used, value from configuration is used only when creating annotation for the first time.
                .SetForceDefaults (true).JavaCast<IInkAnnotationConfigurationBuilder> ()
                .SetPreviewEnabled (false).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // Build the configuration.
                .JavaCast<IAnnotationConfigurationBuilder> ()
                .Build ()
            );

            // Annotation configuration can be configured through PdfFragment for each annotation type.
            fragment.AnnotationConfiguration.Put (AnnotationTool.Ink,
                AnnotationToolVariant.FromPreset (AnnotationToolVariant.Preset.Highlighter),
                IInkAnnotationConfiguration.Builder (this)

                // Configure which color is used when creating ink annotations.
                .SetDefaultColor (Android.Graphics.Color.Rgb (252, 237, 140)).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // Configure which colors are going to be available in the color picker.
                .SetAvailableColors (new List<Java.Lang.Integer> {
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (244, 67, 54), // RED
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (139, 195, 74), // LIGHT GREEN
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (33, 150, 243), // BLUE
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (252, 237, 140), // YELLOW
                    (Java.Lang.Integer) (int) Android.Graphics.Color.Rgb (233, 30, 99) // PINK
                }).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // Configure thickness picker range and default thickness.
                .SetDefaultThickness (5).JavaCast<IInkAnnotationConfigurationBuilder> ()
                .SetMinThickness (1).JavaCast<IInkAnnotationConfigurationBuilder> ()
                .SetMaxThickness (20).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // When true attributes like default color are always used as default when creating annotations.
                // When false last edited value is used, value from configuration is used only when creating annotation for the first time.
                .SetForceDefaults (true).JavaCast<IInkAnnotationConfigurationBuilder> ()
                .SetPreviewEnabled (false).JavaCast<IInkAnnotationConfigurationBuilder> ()

                // Build the configuration.
                .JavaCast<IAnnotationConfigurationBuilder> ()
                .Build ()
            );
        }

        /**
         * Shows how to disable annotation inspector for highlight annotation.
         */
        private void ConfigureHighlightDefaults (PdfFragment fragment)
        {
            // Notes:
            // Unfortunatelly due to C# vs Java differences we need to heavily
            // relly on JavaCast<T> to cast back and fort on the needed configuration
            // type IMarkupAnnotationConfigurationBuilder and at the end to call
            // Build we need to cast it to IAnnotationConfigurationBuilder

            fragment.AnnotationConfiguration.Put (AnnotationType.Highlight,
                IMarkupAnnotationConfiguration.Builder (this, AnnotationType.Highlight)
                // Makes yellow default highlight color.
                .SetDefaultColor (Android.Graphics.Color.Rgb (252, 237, 140)).JavaCast<IMarkupAnnotationConfigurationBuilder> ()
                // Return no supported properties. This disables annotation inspector.
                .SetSupportedProperties (Java.Util.EnumSet.NoneOf (Java.Lang.Class.FromType (typeof (AnnotationProperty))))
                .JavaCast<IAnnotationConfigurationBuilder> ()
                .Build()
            );
        }
    }
}
