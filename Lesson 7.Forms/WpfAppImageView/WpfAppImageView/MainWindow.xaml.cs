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

        // async void лише для обробника події WPF; решта коду використовує Task
        private async void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            string dirPath = txtPath.Text;
            if (Directory.Exists(dirPath) == false)
            {
                MessageBox.Show("Папку не знайдено");
                return;
            }

            try
            {
                // Фонова робота у пулі потоків; UI-потік не блокується
                List<BitmapImage> images = await Task.Run(() => LoadImages(dirPath));

                // Після await ми знову в UI-потоці, тому Dispatcher.Invoke не потрібен
                galleryList.ItemsSource = images;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка читання папки: " + ex.Message);
            }
        }

        // Не звертається до елементів інтерфейсу, тому викликається з фонового потоку
        private static List<BitmapImage> LoadImages(string path)
        {
            //Спеціальний клас для діагностики і роботи з часом
            Stopwatch sw = Stopwatch.StartNew();

            //Отримую із папки список файлів
            string[] files = Directory.GetFiles(path);
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

            sw.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = sw.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            //MessageBox.Show("RunTime " + elapsedTime);

            return images;
        }
    }
}
