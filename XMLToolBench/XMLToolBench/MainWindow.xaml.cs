using System.Deployment.Application;
using System.Windows;
using Services.Models;
using Services.Utils;

namespace XMLToolBench
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

        private void MnuExit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MnuAbout_OnClick(object sender, RoutedEventArgs e)
        {
            string version;
            try
            {
                version = ApplicationDeployment.IsNetworkDeployed ?
                    ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() :
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            catch (InvalidDeploymentException)
            {
                version = "(not installed)";
            }
            MessageBox.Show($"Checkouts - Current Version: {version}");

        }

        private void MnuTransform_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {

            }
        }

        private void MnuLoadXML_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                string path = Helpers.InputFileDialog(string.Empty, "XML|*.xml|All Files|*.*", string.Empty);

                if (!string.IsNullOrEmpty(path))
                    vm.XMLFilePath = path;
            }
        }

        private void MnuLoadXSL_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                string path = Helpers.InputFileDialog(string.Empty, "XSL|*.xsl|XSLT|*.xslt|All Files|*.*", string.Empty);

                if (!string.IsNullOrEmpty(path))
                    vm.XSLFilePath = path;
            }
        }
    }
}
