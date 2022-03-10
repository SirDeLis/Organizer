using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        System.Timers.Timer aTimer = new System.Timers.Timer(1000);
        bool played = false;
        private void Write()
        {
                string path = Directory.GetCurrentDirectory() + @"\Resources";
                Directory.CreateDirectory(path);
                var Notes = File.Create(path + @"\" + this.Title + ".txt");
                Notes.Close();
                int check = 0;
                if (CheckBox.IsChecked == true)
                {
                    check = 1;
                }
                File.AppendAllText(path + @"\" + this.Title + ".txt", Note.Text + ";" + check + ";" + DateTime.Value);
        }
        public NewWindow()
        {
            InitializeComponent();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 100;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                string path = Directory.GetCurrentDirectory() + @"\Resources\" + this.Title + ".txt";
                if (File.Exists(path))
                {
                    if (CheckBox.IsChecked == true)
                    {
                        if (System.DateTime.Now >= DateTime.Value)
                        {
                            if (!played)
                            {
                                played = true;
                                this.Topmost = true;
                                this.Topmost = false;
                                SoundPlayer simpleSound = new SoundPlayer(Directory.GetCurrentDirectory() + @"\sound.wav");
                                simpleSound.Play();
                            }
                        }
                    }
                }
                else
                {
                    this.Close();
                }
                
            }));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Write();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            played = false;
            Write();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            played = false;
            Write();
        }

        private void DateTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Write();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Write();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Resources\" + this.Title + ".txt";
            File.Delete(path);
            this.Close();
        }


        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
