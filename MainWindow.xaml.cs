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

namespace practice_2_entities
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BookSystemEntities chitateli = new BookSystemEntities();
        public MainWindow()
        {
            InitializeComponent();
            dg_BD_readers.ItemsSource = chitateli.Readers.ToList();    
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page1();
            dg_BD_readers.Visibility = Visibility.Hidden;
            readertxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
            next_page.Visibility = Visibility.Hidden;

        }

        private void DeleteReaders_Click(object sender, RoutedEventArgs e)
        { 
            if (dg_BD_readers.SelectedItem != null)
            {
                chitateli.Readers.Remove(dg_BD_readers.SelectedItem as Readers);
                chitateli.SaveChanges();
                dg_BD_readers.ItemsSource = chitateli.Readers.ToList();
            }
        }

        private void UpdateReaders_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_readers.SelectedItem != null)
            {
                var selected = dg_BD_readers.SelectedItem as Readers;
                selected.ReaderSurname = pole1.Text;
                selected.ReaderName = pole2.Text;
                selected.ReaderMiddleName = pole3.Text;
                selected.DateOfBirth = Convert.ToDateTime(pole4.Text);
                selected.Email = pole5.Text;
                chitateli.SaveChanges();
                dg_BD_readers.ItemsSource = chitateli.Readers.ToList();
            }
        }

        private void AddReaders_Click(object sender, RoutedEventArgs e)
        {
            Readers r = new Readers();
            r.ReaderSurname = pole1.Text;
            r.ReaderName = pole2.Text;
            r.ReaderMiddleName = pole3.Text;
            r.DateOfBirth = Convert.ToDateTime(pole4.Text);
            r.Email = pole5.Text;
            chitateli.Readers.Add(r);
            chitateli.SaveChanges();
            dg_BD_readers.ItemsSource = chitateli.Readers.ToList();
        }

        private void dg_BD_readers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_BD_readers.SelectedItem != null)
            {
                var selected = dg_BD_readers.SelectedItem as Readers;

                pole1.Text = selected.ReaderSurname.ToString();
                pole2.Text = selected.ReaderName.ToString();
                pole3.Text = selected.ReaderMiddleName.ToString();
                pole4.Text = selected.DateOfBirth.ToString();
                pole5.Text = selected.Email.ToString();

                chitateli.SaveChanges();
                dg_BD_readers.ItemsSource = chitateli.Readers.ToList();
            }
        }
    }
}
