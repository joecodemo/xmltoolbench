using System.Deployment.Application;
using System.Windows;

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
    }
}
