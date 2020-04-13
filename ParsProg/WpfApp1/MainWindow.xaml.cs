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
using System.Net;
using System.IO;
using System.Threading;
using System.ComponentModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviousButton.Visibility = Visibility.Hidden;
            NextButton.Visibility = Visibility.Hidden;
            PageInfo.Visibility = Visibility.Hidden;
        }
        Threat threat = new Threat();
        public static string url = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";
        public static string save_path = "C:\\test\\";
        public static string name = "thrlist.xlsx";
        public static string nameUp = "thrlistUp.xlsx";
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileControl.Content = "Идет загрузка данных...";
            FileControl.Visibility = Visibility.Visible;
            if (File.Exists("C:\\test\\thrlist.xlsx") == false)
               {
                    try
                    {
                    Directory.CreateDirectory(save_path);
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFileAsync(new Uri(url), save_path + name);
                    }
                    FileControl.Content = "Файл загружен";
                    FileControl.Visibility = Visibility.Visible;

                    }
                    catch (Exception a)
                    {
                        MessageBox.Show($"{a.Message}");
                        FileControl.Content = "Файл не загружен";
                        FileControl.Visibility = Visibility.Visible;
                    }
               }
            try
            {
                FileControl.Content = "Идет загрузка данных...";
                threat.ExportExcel(name);
                PageInfo.Content = 1;
                Update.Visibility = Visibility.Visible;
                Load.Visibility = Visibility.Hidden;
                Gridik.Visibility = Visibility.Visible;
                Welcom.Visibility = Visibility.Hidden;
                Inform.Content = "Информация:";
                Inform.Visibility = Visibility.Visible;
                NextButton.Visibility = Visibility.Visible;
                PageInfo.Visibility = Visibility.Visible;
                Gridik.ItemsSource = threat.ThreatsEx();
                FileControl.Content = "Данные загружены";
                Gridik.Items.Refresh();
            }
            catch 
            {
                MessageBox.Show("Проверьте наличие файла thrlist.xlsx в папке C:\\test\\");
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(url), save_path + nameUp);
                }
                threat.UpdateData(nameUp);
                FileControl.Content = "Файл обновлен";
                FileControl.Visibility = Visibility.Visible;
                Gridik.Visibility = Visibility.Hidden;
                PreviousButton.Visibility = Visibility.Hidden;
                NextButton.Visibility = Visibility.Hidden;
                PageInfo.Visibility = Visibility.Hidden;
                UpdGrid.ItemsSource = threat.lnew;
                Inform.Content = "Изменения:";
                Inform.Visibility = Visibility.Visible;
                UpdGrid.Visibility = Visibility.Visible;
                OK.Visibility = Visibility.Visible;
                MessageBox.Show($"Количество изменений: {Updata.ncount}");
                File.Delete(save_path + name);
                File.Move(save_path + nameUp, save_path + name);
            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка: " + a.Message);
                FileControl.Content = "Файл не обновлен";
                FileControl.Visibility = Visibility.Visible;
            }
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            PageInfo.Content = 1;
            threat.index = 0;
            Gridik.ItemsSource = threat.ThreatsEx();
            Inform.Content = "Информация:";
            Inform.Visibility = Visibility.Visible;
            UpdGrid.Visibility = Visibility.Hidden;
            Gridik.Visibility = Visibility.Visible;
            PreviousButton.Visibility = Visibility.Hidden;
            NextButton.Visibility = Visibility.Visible;
            PageInfo.Visibility = Visibility.Visible;
            OK.Visibility = Visibility.Hidden;
            ReturntoUpd.Visibility = Visibility.Visible;
        }
        private void PreviousButton_Click_1(object sender, RoutedEventArgs e)
        {
                threat.numofPage--;
                threat.index -= 15;
                Gridik.ItemsSource = threat.ThreatsEx();
                PageInfo.Content = threat.numofPage;
                Gridik.Items.Refresh();
                NextButton.Visibility = Visibility.Visible;
                if (threat.numofPage==1) PreviousButton.Visibility = Visibility.Hidden;
        }
        private void NextButton_Click_1(object sender, RoutedEventArgs e)
        {
                threat.numofPage++;
                threat.index += 15;
                Gridik.ItemsSource = threat.ThreatsEx();
                PageInfo.Content = threat.numofPage;
                Gridik.Items.Refresh();
                PreviousButton.Visibility = Visibility.Visible;
                if (threat.over == true) NextButton.Visibility = Visibility.Hidden;
        }
        private void ReturntoUpd_Click(object sender, RoutedEventArgs e)
        {
            UpdGrid.Visibility = Visibility.Visible;
            Inform.Content = "Изменения:";
            Inform.Visibility = Visibility.Visible;
            Gridik.Visibility = Visibility.Hidden;
            PreviousButton.Visibility = Visibility.Hidden;
            NextButton.Visibility = Visibility.Hidden;
            PageInfo.Visibility = Visibility.Hidden;
            OK.Visibility = Visibility.Visible;
            ReturntoUpd.Visibility = Visibility.Hidden;
        }
    }
}
