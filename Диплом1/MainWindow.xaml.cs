using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Диплом1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewWindow window = new NewWindow();
            window.Tag = "Child";
            string path = Directory.GetCurrentDirectory() + @"\Resources";
            int num = new DirectoryInfo(path).GetFiles().Length;
            num += 1;
            window.Title = "Заметка" + num;
            window.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Resources";
            int num = new DirectoryInfo(path).GetFiles().Length;
            if (num > 0)
            {
                for (int i = 1; i <= num; i++)
                {
                    if (File.Exists(path + @"\Заметка" + i + ".txt"))
                    {
                        string TextOf = File.ReadAllText(path + @"\Заметка" + i + ".txt");
                        string[] SepText = TextOf.Split(';');
                        NewWindow window = new NewWindow();
                        window.Title = "Заметка" + i;
                        window.Note.Text = SepText[0];
                        if (SepText[1] == "1")
                        {
                            window.CheckBox.IsChecked = true;
                            window.DateTime.Value = DateTime.Parse(SepText[2]);
                        }
                        window.Show();
                    }
                    
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            System.IO.DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Resources");
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Weelky_Click(object sender, RoutedEventArgs e)
        {
            Classical window = new Classical();
            window.Show();
        }
    }
}
