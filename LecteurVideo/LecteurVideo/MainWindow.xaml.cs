using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LecteurVideo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Posting test;
        TextBlock T;
        string cheminVideo;
        public MainWindow()
        {
            InitializeComponent();
            button1.IsEnabled = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog boite = new Microsoft.Win32.OpenFileDialog();
            boite.Filter = "Fichiers Vidéo (*.avi;*.mpg;*.mpeg; *.mkv)|*.avi;*.mpg;*.mpeg; *.mkv";
            boite.Multiselect = false;
            boite.FilterIndex = 1;
            boite.ShowDialog();

            if (boite.Filter != string.Empty)
            {
                mediaElement.Source = new Uri(boite.FileName);
                T = textBlock;
                test = new Posting(T,cheminVideo);
            }
        }

        private void Chemin_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog boite = new Microsoft.Win32.OpenFileDialog();
            boite.Filter = "Fichiers Texte (*.srt;)|*.srt";
            boite.Multiselect = false;
            boite.FilterIndex = 1;
            boite.ShowDialog();
            if (boite.Filter != string.Empty)
            {
                cheminVideo = boite.FileName;
                button1.IsEnabled = true;
            }
        }
    }
}
