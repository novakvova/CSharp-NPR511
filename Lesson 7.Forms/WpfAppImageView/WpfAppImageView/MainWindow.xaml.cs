using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            //тут id поток = 2
            Thread thread = new Thread(JobReadImages);
            thread.Start(dirPath);
        }

        private void JobReadImages(object path)
        {
            //Тут буде інший ідентифікатор потоку
            //Наприклад 4
            //Спеціальний клас для діагностики і роботи з часом
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Отримую із папки список файлів
            var files = Directory.GetFiles(path as string);
            var images = new List<BitmapImage>();

            foreach (var file in files)
            {
                try
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(file);
                    bitmap.DecodePixelWidth = 300;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad; //завантажуємо у вікно
                    bitmap.EndInit();
                    bitmap.Freeze(); //робимо доступним для UI-потоку
                    images.Add(bitmap);
                }
                catch
                {
                    //MessageBox.Show("Проблема читання файлу " + file);
                }
            }
            //У наш ListBox ми передаємо дані
            //Дані мають оброблятися через ItemsPanelTemplate
            //Кожен елемент має розташовуватися у WrapPanel
            //Коли він потрапляє у WrapPanell
            //Йому надається значення 
            //<Image Source="{Binding}" Width="150" Height="150"
            //  Stretch = "UniformToFill" Margin = "5" />
            //Замість {Binding} буде підставлятися var bitmap = new BitmapImage();

            sw.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = sw.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            //MessageBox.Show("RunTime " + elapsedTime);

            Dispatcher.Invoke(() =>
            {
                galleryList.ItemsSource = images;
            });
            
        }
    }
}