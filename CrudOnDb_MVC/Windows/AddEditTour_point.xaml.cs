using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditTour_point.xaml
    /// </summary>
    public partial class AddEditTour_point : Window
    {
        public AddEditTour_point()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditTour_point(TourismDB db, DataGrid datagrid, bool edit)
        {
            InitializeComponent();
            this.db = db;
            this.datagrid = datagrid;
            f = new Facade(db, datagrid);
            this.edit = edit;
            this.index = datagrid.SelectedIndex;
            CountrycomboBox.ItemsSource = db.Tours.ToList();
            HotelcomboBox.ItemsSource = db.Hotels.ToList();
            TranscomboBox.ItemsSource = db.Transports.ToList();
            if (edit)
                Init();
        }

        void Init()
        {
            Tour_point tourPoint = db.Tour_point.ToList()[index];
            CitytextBox.Text = tourPoint.City + "";
            CountrycomboBox.SelectedItem = tourPoint.Tours;
            HotelcomboBox.SelectedItem = tourPoint.Hotels;
            TranscomboBox.SelectedItem = tourPoint.Transports;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditTour_Point(index, new Tour_point(((Tours)CountrycomboBox.SelectedItem).Tour_ID, ((Hotels)HotelcomboBox.SelectedItem).Hotel_ID, ((Transports)TranscomboBox.SelectedItem).Transport_ID, CitytextBox.Text));
                }
                else
                {
                    f.add.AddTour_point(new Tour_point(((Tours)CountrycomboBox.SelectedItem).Tour_ID, ((Hotels)HotelcomboBox.SelectedItem).Hotel_ID, ((Transports)TranscomboBox.SelectedItem).Transport_ID, CitytextBox.Text));
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error!\n {ex.Message}\n {ex}"); }

            this.Close();
        }
    }
}
