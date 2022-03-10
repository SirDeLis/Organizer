using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Диплом1
{
    /// <summary>
    /// Логика взаимодействия для Classical.xaml
    /// </summary>
    public partial class Classical : Window
    {
        bool Loading = true;
        public Classical()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Loading)
            {
                string path = Directory.GetCurrentDirectory() + @"\Resources";
                Directory.CreateDirectory(path);
                var Notes = File.Create(path + @"\Weekly.txt");
                path += @"\Weekly.txt";
                Notes.Close();
                foreach (TextBox textBox in Weeks.Children)
                {
                    File.AppendAllText(path, textBox.Text + ";");
                }
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Resources\Weekly.txt";
            string TextOf = File.ReadAllText(path);
            string[] SepText = TextOf.Split(';');
            int i = 0;
            foreach (TextBox textBox in Weeks.Children)
            {
                textBox.Text = SepText[i];
                i++;
            }
            Loading = true;
        }
    }
}
