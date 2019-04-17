using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Window
    {
        public AddEditClient()
        {
            InitializeComponent();
        }
        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditClient(TourismDB db, DataGrid datagrid, bool edit)
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
            Clients cl = db.Clients.ToList()[index];
            SurnameTextBox.Text = cl.Surname + "";
            NameTextBox.Text = cl.Name + "";
            PatronymicTextBox.Text = cl.Patronymic + "";
            PhoneTextBox.Text = cl.Phone + "";
            EmailTextBox.Text = cl.Email + "";
            AddressTextBox.Text = cl.Address + "";
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditClient(index, new Clients(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, AddressTextBox.Text));
                }
                else
                {
                    f.add.AddClient(new Clients(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, AddressTextBox.Text));
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error!\n {ex.Message}"); }

            this.Close();
        }
    }
}
