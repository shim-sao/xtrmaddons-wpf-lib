using Microsoft.Win32;
using System.Drawing.Imaging;

namespace XtrmAddons.Net.Picture
{
    /// <summary>
    /// Class XtrmAddons Net Picture File Dialog Box.
    /// </summary>
    public class PictureFileDialogBox
    {
        /// <summary>
        /// Method to open a file dialog box to pick files.
        /// </summary>
        /// <param name="multiselect">Is multiselection enabled ?</param>
        /// <param name="title">The title of the dialog box to display.</param>
        /// <returns>The dialog box if result is true otherwise null.</returns>
        public static OpenFileDialog Show(bool multiselect = false, string title = "Application Picture Image Browser")
        {
            // Create file dialog box 
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = ""
            };

            // Get image codec encoders.
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            // Create a filters list of file extension from codecs encoders.
            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            // Configure the dialog box properties before displays.
            dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");
            dlg.DefaultExt = ".JPG"; // Default file extension 
            dlg.FilterIndex = 2; // Default file extension [JPG doesn't work]
            dlg.Multiselect = multiselect;
            dlg.Title = title;

            // Show open file dialog box 
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                return dlg;
            }

            return null;
        }
    }
}