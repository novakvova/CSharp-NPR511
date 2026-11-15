using System.IO;
using System.Windows;

namespace WpfAppImageView
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

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            string dirPath = txtPath.Text;
            if(Directory.Exists(dirPath) ==false)
            {
                MessageBox.Show("Папку не знайдено");
                return;
            }
            MessageBox.Show("Натиснули кнопку");
        }
    }
}