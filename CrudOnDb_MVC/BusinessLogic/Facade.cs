using System.Linq;
using System.Windows.Controls;
using CrudOnDb_MVC.Models;
using CrudOnDb_MVC.Windows;

namespace CrudOnDb_MVC.BusinessLogic
{
    class Facade
    {
        Searcher searcher;
        TourismDB db;
        DataGrid datagrid;
        ComboBox TableComboBox;
        public Adder add;
        public Editer edd;
        public Deliter del;
        Builder BuilderMain { get; set; }
        Director DirectorMain { get; set; }

        public Facade(TourismDB db, DataGrid datagrid)
        {
            this.db = db;
            this.datagrid = datagrid;
            BuilderMain = new GridBuilder(datagrid);
            DirectorMain = new Director(BuilderMain);
            DirectorMain.SetDB(db);
            add = new Adder(db, DirectorMain);
            edd = new Editer(db, DirectorMain);
            del = new Deliter(db, DirectorMain);
        }

        public Facade(TourismDB db, DataGrid datagrid, ComboBox tablecombobox, ComboBox searchcombobox, TextBox findbox)
        {
            this.db = db;
            this.datagrid = datagrid;
            TableComboBox = tablecombobox;
            searcher = new Searcher(db, datagrid, tablecombobox, searchcombobox, findbox);
            BuilderMain = new GridBuilder(datagrid);
            DirectorMain = new Director(BuilderMain);
            DirectorMain.SetDB(db);
            add = new Adder(db, DirectorMain);
            edd = new Editer(db, DirectorMain);
            del = new Deliter(db, DirectorMain);
        }

        public Facade(TourismDB db)
        {
            this.db = db;
        }

        public void Add()
        {
            if (TableComboBox.Text == "Клиент")
            {
                AddEditClient addEditClient = new AddEditClient(db, datagrid, false);
                addEditClient.Show();
            }
            if (TableComboBox.Text == "Сотрудник")
            {
                AddEditEmployee addEditEmployee = new AddEditEmployee(db, datagrid, false);
                addEditEmployee.Show();
            }
            if (TableComboBox.Text == "Заказ")
            {
                AddEditOrder addEditOrder = new AddEditOrder(db, datagrid, false);
                addEditOrder.Show();
            }
            if (TableComboBox.Text == "Отель")
            {
                AddEditHotel addEditHotel = new AddEditHotel(db, datagrid, false);
                addEditHotel.Show();
            }
            if (TableComboBox.Text == "Точка остановки")
            {
                AddEditTour_point addEditTourPoint = new AddEditTour_point(db, datagrid, false);
                addEditTourPoint.Show();
            }
            if (TableComboBox.Text == "Тур")
            {
                AddEditTour addEditTour = new AddEditTour(db, datagrid, false);
                addEditTour.Show();
            }
        }

        public void Edit()
        {
            if (TableComboBox.Text == "Клиент")
            {
                if (datagrid.SelectedIndex >= 0 && datagrid.SelectedIndex < db.Clients.Count())
                {
                    AddEditClient addEditClient = new AddEditClient(db, datagrid, true);
                    addEditClient.Show();
                }
            }
            if (TableComboBox.Text == "Сотрудник")
            {
                if (datagrid.SelectedIndex >= 0 && datagrid.SelectedIndex < db.Employees.Count())
                {
                    AddEditEmployee addEditEmployee = new AddEditEmployee(db, datagrid, true);
                    addEditEmployee.Show();
                }
            }
            if (TableComboBox.Text == "Заказ")
            {
                if (datagrid.SelectedIndex >= 0 && datagrid.SelectedIndex < db.Orders.Count())
                {
                    AddEditOrder addEditOrder = new AddEditOrder(db, datagrid, true);
                    addEditOrder.Show();
                }
            }
            if (TableComboBox.Text == "Отель")
            {
                if (datagrid.SelectedIndex >= 0 && datagrid.SelectedIndex < db.Hotels.Count())
                {
                    AddEditHotel addEditHotel = new AddEditHotel(db, datagrid, true);
                    addEditHotel.Show();
                }
            }
            if (TableComboBox.Text == "Точка остановки")
            {
                if (datagrid.SelectedIndex >= 0 && datagrid.SelectedIndex < db.Tour_point.Count())
                {
                    AddEditTour_point addEditTourPoint = new AddEditTour_point(db, datagrid, true);
                    addEditTourPoint.Show();
                }
            }
            if (TableComboBox.Text == "Тур")
            {
                if (datagrid.SelectedIndex >= 0 && datagrid.SelectedIndex < db.Tours.Count())
                {
                    AddEditTour AddEddSym = new AddEditTour(db, datagrid, true);
                    AddEddSym.Show();
                }
            }
        }


        public void Delete()
        {
            if (TableComboBox.Text == "Клиент")
            {
                del.DeleteClient(datagrid.SelectedIndex);
            }
            if (TableComboBox.Text == "Сотрудник")
            {
                del.DeleteEmployee(datagrid.SelectedIndex);
            }
            if (TableComboBox.Text == "Отель")
            {
                del.DeleteHotel(datagrid.SelectedIndex);
            }
            if (TableComboBox.Text == "Заказ")
            {
                del.DeleteOrder(datagrid.SelectedIndex);
            }
            if (TableComboBox.Text == "Точка остановки")
            {
                del.DeleteTour_point(datagrid.SelectedIndex);
            }
            if (TableComboBox.Text == "Тур")
            {
                del.DeleteTour(datagrid.SelectedIndex);
            }
        }

        public void Search()
        {
            searcher.Search();
        }

        public void ShowTables()
        {
            if (TableComboBox.Text == "Клиент")
            {
                ClientPattern();
                searcher.InitSearchCombobox();
            }
            if (TableComboBox.Text == "Сотрудник")
            {
                EmployeePattern();
                searcher.InitSearchCombobox();
            }
            if (TableComboBox.Text == "Отель")
            {
                HotelPattern();
                searcher.InitSearchCombobox();
            }
            if (TableComboBox.Text == "Заказ")
            {
                OrderPattern();
                searcher.InitSearchCombobox();
            }
            if (TableComboBox.Text == "Точка остановки")
            {
                Tour_pointPattern();
                searcher.InitSearchCombobox();
            }
            if (TableComboBox.Text == "Тур")
            {
                TourPattern();
                searcher.InitSearchCombobox();
            }
        }
        /// <summary>
        /// Выводы таблиц
        /// </summary>
        private void ClientPattern()
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructClienGrid();
        }

        private void EmployeePattern()
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructEmployeeGrid();
        }

        private void HotelPattern()
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructHotelGrid();
        }

        private void OrderPattern()
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructOrderGrid();
        }

        private void Tour_pointPattern()
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructTour_PointGrid();
        }

        private void TourPattern()
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructTourGrid();
        }

    }
}