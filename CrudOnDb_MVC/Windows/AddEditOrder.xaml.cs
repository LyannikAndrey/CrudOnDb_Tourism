using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditOrder.xaml
    /// </summary>
    public partial class AddEditOrder : Window
    {
        public AddEditOrder()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditOrder(TourismDB db, DataGrid datagrid, bool edit)
        {
            InitializeComponent();
            this.db = db;
            this.datagrid = datagrid;
            f = new Facade(db, datagrid);
            this.edit = edit;
            this.index = datagrid.SelectedIndex;
            ClientcomboBox.ItemsSource = db.Clients.ToList();
            TourcomboBox.ItemsSource = db.Tours.ToList();
            EmplcomboBox.ItemsSource = db.Employees.ToList();
            if (edit)
                Init();
        }

        void Init()
        {
            Orders t = db.Orders.ToList()[index];
            DatetextBox.Text = t.DateOfRegistration.ToString(CultureInfo.CurrentCulture);
            ClientcomboBox.SelectedItem = t.Clients;
            TourcomboBox.SelectedItem = t.Tours;
            EmplcomboBox.SelectedItem = t.Employees;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditOrder(index, new Orders(((Clients)ClientcomboBox.SelectedItem).Client_ID, ((Tours)TourcomboBox.SelectedItem).Tour_ID, DateTime.Parse(DatetextBox.Text), ((Employees)EmplcomboBox.SelectedItem).Employee_ID));
                }
                else
                {
                    f.add.AddOrder(new Orders(((Clients)ClientcomboBox.SelectedItem).Client_ID, ((Tours)TourcomboBox.SelectedItem).Tour_ID, DateTime.Parse(DatetextBox.Text), ((Employees)EmplcomboBox.SelectedItem).Employee_ID));
                }
            }
            catch (Exception) { MessageBox.Show("Неплохая попытка..."); }
            this.Close();
        }
    }
}
