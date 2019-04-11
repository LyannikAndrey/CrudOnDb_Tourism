using System;
using System.Diagnostics;
using System.Windows;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;

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
            f.ShowTables();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Search();
            }
            catch { MessageBox.Show("Некорректные данные для поиска"); }
        }
        
    }
}
