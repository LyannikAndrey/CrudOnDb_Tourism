using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.Windows
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        public AddEditEmployee()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditEmployee(TourismDB db, DataGrid datagrid, bool edit)
        {
            InitializeComponent();
            this.db = db;
            this.datagrid = datagrid;
            f = new Facade(db, datagrid);
            this.edit = edit;
            this.index = datagrid.SelectedIndex;
            if (edit)
                Init();
        }

        void Init()
        {
            Employees em = db.Employees.ToList()[index];
            SurnameTextBox.Text = em.Surname + "";
            NameTextBox.Text = em.Name + "";
            PatronymicTextBox.Text = em.Patronymic + "";
            PhoneTextBox.Text = em.Phone + "";
            EmailTextBox.Text = em.Email + "";
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditEmployee(index, new Employees(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text));
                }
                else
                {
                    f.add.AddEmployee(new Employees(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text));
                }
            }
            catch (Exception) { MessageBox.Show("Неплохая попытка..."); }
            this.Close();
        }
    }
}
