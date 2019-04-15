using System;
using System.Diagnostics;
using System.Windows;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;
using  CrudOnDb_MVC.Windows;

namespace CrudOnDb_MVC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TourismDB db;
        Facade f;

        public MainWindow()
        {
            InitializeComponent();
            ReportButton.Visibility = Visibility.Hidden;
            db = new TourismDB();
            f = new Facade(db, dataGrid, TableComboBox, SearchComboBox, SearchTextBox);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            f.Add();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            f.Edit();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Delete();
            }
            catch (Exception) { MessageBox.Show("Выберите элемент для удаления"); }
        }

        private void ShowTableButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableComboBox.Text == "Заказ")
            {
                ReportButton.Visibility = Visibility.Visible;
            }
            else
            {
                ReportButton.Visibility = Visibility.Hidden;
            }

            f.ShowTables(false);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Search();
            }
            catch { MessageBox.Show("Некорректные данные для поиска"); }
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportOrder reportOrder = new ReportOrder(db);
            reportOrder.Show();
        }
    }
}
