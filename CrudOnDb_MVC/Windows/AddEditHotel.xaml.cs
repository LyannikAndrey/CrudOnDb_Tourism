using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditHotel.xaml
    /// </summary>
    public partial class AddEditHotel : Window
    {
        public AddEditHotel()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;
        DataGrid datagrid;
        bool edit;
        int index;

        public AddEditHotel(TourismDB db, DataGrid datagrid, bool edit)
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
            Hotels h = db.Hotels.ToList()[index];
            RatingtextBox.Text = h.Rating.ToString();
            NametextBox.Text = h.Name + "";
            HotelCosttextBox.Text = h.HotelCost.ToString();
            TypeRoomtextBox.Text = h.TypeOfRoom + "";
            AccomtextBox.Text = h.Accommodation + "";
            FoodtextBox.Text = h.Food + "";
            AddressetextBox.Text = h.Address + "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit)
                {
                    f.edd.EditHotel(index, new Hotels(byte.Parse(RatingtextBox.Text), NametextBox.Text, int.Parse(HotelCosttextBox.Text), TypeRoomtextBox.Text, AccomtextBox.Text, FoodtextBox.Text, AddressetextBox.Text));
                }
                else
                {
                    f.add.AddHotel(new Hotels(byte.Parse(RatingtextBox.Text), NametextBox.Text, int.Parse(HotelCosttextBox.Text), TypeRoomtextBox.Text, AccomtextBox.Text, FoodtextBox.Text, AddressetextBox.Text));
                }
            }
            catch (Exception) { MessageBox.Show("Неплохая попытка..."); }
            this.Close();
        }
    }
}
