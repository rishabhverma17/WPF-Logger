using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using log4net;

namespace WPFapp_With_Logger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MainWindow()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            
            // First Log.
            log.Info("In MainWindow.xaml");
            // Setting Focus on textBox on startup
            FocusManager.SetFocusedElement(this, textBox);
        }
        
        /*  
         *  Options Available
         * 
         *  log.info
         *  log.error
         *  log.fatal
         *  log.debug
         */
 
        // On Clicking Hello Button
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            log.Info("Key to Hello Clicked.");
            string hello = "Hello";
            textBox.Text = hello;
            label.Content = "Click Logged in Logger.";
            await Task.Delay(2000);
            textBox.Text = string.Empty;
            label.Content = string.Empty;
        }

        // On Clicking Exit Button
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            log.Info("Button Clicked to Exit Application.");
            string exit = "Exiting App in 2 Seconds..";
            textBox.Text = exit;
            label.Content = "Click Logged to exit application in Logger.";
            await Task.Delay(2000);
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
