using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Services.Utils
{
    public class Helpers
    {
        public static string InputFileDialog(string defaultFileName, string defaultExtension, string initialDirectory)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = defaultFileName,
                Filter = defaultExtension,
                InitialDirectory = initialDirectory
            };

            bool? result = dlg.ShowDialog();

            return result == true ? dlg.FileName : "";
        }

        public static string GetOutputFileName(string inputName, string dir, string errorMsg)
        {
            string startingDirectory = dir;
            if (string.IsNullOrEmpty(startingDirectory))
                startingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string filename;
            SaveFileDialog dlg = new SaveFileDialog
            {
                FileName = inputName,
                InitialDirectory = startingDirectory,
                DefaultExt = ".xlsx",
                Filter = "Excel Workbook|*.xlsx|All Files|*.*"
            };

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                filename = dlg.FileName;
                if (File.Exists(filename))
                    File.Delete(filename);
            }
            else
            {
                MessageBox.Show(errorMsg);
                filename = "";
            }
            return filename;
        }
    }
}