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
    /// Логика взаимодействия для AddEditTour.xaml
    /// </summary>
    public partial class AddEditTour : Window
    {
        public AddEditTour()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditTour(TourismDB db, DataGrid datagrid, bool edit)
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
            Tours tours = db.Tours.ToList()[index];
            CountrytextBox.Text = tours.Country + "";
            ArrDatetextBox.Text = tours.ArrivalDate.ToString(CultureInfo.CurrentCulture);
            DepDatetextBox.Text = tours.DepartureDate.ToString(CultureInfo.CurrentCulture);
            CosttextBox.Text = tours.Tour_cost.ToString();
            PeopletextBox.Text = tours.NumberOfPersons.ToString();
            TypetextBox.Text = tours.Type + "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditTour(index, new Tours(CountrytextBox.Text, DateTime.Parse(ArrDatetextBox.Text), DateTime.Parse(DepDatetextBox.Text), double.Parse(CosttextBox.Text), int.Parse(PeopletextBox.Text), TypetextBox.Text));
                }
                else
                {
                    f.add.AddTour(new Tours(CountrytextBox.Text, DateTime.Parse(ArrDatetextBox.Text), DateTime.Parse(DepDatetextBox.Text), double.Parse(CosttextBox.Text), int.Parse(PeopletextBox.Text), TypetextBox.Text));
                }
            }
            catch (Exception) { MessageBox.Show("Неплохая попытка..."); }
            this.Close();
        }
    }
}
