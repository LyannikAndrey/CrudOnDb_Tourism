using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.BusinessLogic
{
    class Searcher
    {
        TourismDB db;
        ComboBox TableComboBox;
        ComboBox SearchComboBox;
        TextBox findbox;
        Builder BuilderMain { get; set; }
        Director DirectorMain { get; set; }

        public Searcher(TourismDB db, DataGrid datagrid, ComboBox TableComboBox, ComboBox SearchComboBox, TextBox findbox)
        {
            this.db = db;
            this.TableComboBox = TableComboBox;
            this.SearchComboBox = SearchComboBox;
            this.findbox = findbox;
            BuilderMain = new GridBuilder(datagrid);
            DirectorMain = new Director(BuilderMain);
            DirectorMain.SetDB(db);
        }

        public void InitSearchCombobox()
        {
            string[][] comboboxitems = new string[][] {
                new string[]{ "Фамилия", "Имя", "Отчество", "Телефон", "E-mail", "Адрес" },
                new string[]{ "Фамилия", "Имя", "Отчество", "Телефон", "E-mail" },
                new string[]{ "Рейтинг", "Название", "Цена", "Тип комнаты", "Размещение", "Питание", "Адрес" },
                new string[]{ "Заказчик", "Сотрудник", "Тур", "Дата регистрации" },
                new string[]{ "Тур", "Город", "Транспорт", "Отель" },
                new string[]{ "Страна", "Дата прибытия", "Дата отправления", "Ночей в туре",  "Стоимость", "Человек", "Тип" },
            };

            if (TableComboBox.Text == "Клиент")
            {
                SearchComboBox.Items.Clear();
                for (int i = 0; i < comboboxitems[0].Count(); i++)
                    SearchComboBox.Items.Add(comboboxitems[0][i]);
            }
            if (TableComboBox.Text == "Сотрудник")
            {
                SearchComboBox.Items.Clear();
                for (int i = 0; i < comboboxitems[1].Count(); i++)
                    SearchComboBox.Items.Add(comboboxitems[1][i]);
            }
            if (TableComboBox.Text == "Отель")
            {
                SearchComboBox.Items.Clear();
                for (int i = 0; i < comboboxitems[2].Count(); i++)
                    SearchComboBox.Items.Add(comboboxitems[2][i]);
            }
            if (TableComboBox.Text == "Заказ")
            {
                SearchComboBox.Items.Clear();
                for (int i = 0; i < comboboxitems[3].Count(); i++)
                    SearchComboBox.Items.Add(comboboxitems[3][i]);
            }
            if (TableComboBox.Text == "Точка остановки")
            {
                SearchComboBox.Items.Clear();
                for (int i = 0; i < comboboxitems[4].Count(); i++)
                    SearchComboBox.Items.Add(comboboxitems[4][i]);
            }
            if (TableComboBox.Text == "Тур")
            {
                SearchComboBox.Items.Clear();
                for (int i = 0; i < comboboxitems[5].Count(); i++)
                    SearchComboBox.Items.Add(comboboxitems[5][i]);
            }
        }

        public void Search()
        {
            if (TableComboBox.Text == "Клиент")
            {
                SearchClient();
            }
            if (TableComboBox.Text == "Сотрудник")
            {
                SearchEmployee();
            }
            if (TableComboBox.Text == "Отель")
            {
                SearchHotel();
            }
            if (TableComboBox.Text == "Заказ")
            {
                SearchOrder();
            }
            if (TableComboBox.Text == "Точка остановки")
            {
                SearchTour_point();
            }
            if (TableComboBox.Text == "Тур")
            {
                SearchTour();
            }
        }

        
        private void SearchClient()
        {
            List<Clients> searchlist = db.Clients.ToList();
            List<Clients> resultlist = new List<Clients>();
            if (findbox.Text == "" || SearchComboBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }
            for (int i = 0; i < searchlist.Count; i++)
            {
                if (SearchComboBox.Text == "Фамилия")
                {
                    if (searchlist[i].Surname.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Имя")
                {
                    if (searchlist[i].Name.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Отчество")
                {
                    if (searchlist[i].Patronymic.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Телефон")
                {
                    if (searchlist[i].Phone.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "E-mail")
                {
                    if (searchlist[i].Email.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Адрес")
                {
                    if (searchlist[i].Address.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
            }
            if (resultlist.Count == 0)
            {
                MessageBox.Show("Нет данных, которые соответствуют этим критериям!");
                return;
            }
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructClientGrid(resultlist);
        }

        private void SearchEmployee()
        {
            List<Employees> searchlist = db.Employees.ToList();
            List<Employees> resultlist = new List<Employees>();
            if (findbox.Text == "" || SearchComboBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }
            for (int i = 0; i < searchlist.Count; i++)
            {
                if (SearchComboBox.Text == "Фамилия")
                {
                    if (searchlist[i].Surname.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Имя")
                {
                    if (searchlist[i].Name.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Отчество")
                {
                    if (searchlist[i].Patronymic.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Телефон")
                {
                    if (searchlist[i].Phone.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "E-mail")
                {
                    if (searchlist[i].Email.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
            }
            if (resultlist.Count == 0)
            {
                MessageBox.Show("Нет данных, которые соответствуют этим критериям!");
                return;
            }
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructEmployeeGrid(resultlist);
        }

        private void SearchHotel()
        {
            List<Hotels> searchlist = db.Hotels.ToList();
            List<Hotels> resultlist = new List<Hotels>();
            if (findbox.Text == "" || SearchComboBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }
            for (int i = 0; i < searchlist.Count; i++)
            {
                if (SearchComboBox.Text == "Рейтинг")
                {
                    if (searchlist[i].Rating == int.Parse(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Цена")
                {
                    if (searchlist[i].HotelCost == int.Parse(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Название")
                {
                    if (searchlist[i].Name.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Тип комнаты")
                {
                    if (searchlist[i].TypeOfRoom.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Размещение")
                {
                    if (searchlist[i].Accommodation.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Питание")
                {
                    if (searchlist[i].Food.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Адрес")
                {
                    if (searchlist[i].Address.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
            }
            if (resultlist.Count == 0)
            {
                MessageBox.Show("Нет данных, которые соответствуют этим критериям!");
                return;
            }
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructHotelGrid(resultlist);
        }

        private void SearchOrder()
        {
            List<Orders> searchlist = db.Orders.ToList();
            List<Orders> resultlist = new List<Orders>();
            if (findbox.Text == "" || SearchComboBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }
            for (int i = 0; i < searchlist.Count; i++)
            {
                if (SearchComboBox.Text == "Заказчик")
                {
                    if (searchlist[i].Clients.ToString().Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Сотрудник")
                {
                    if (searchlist[i].Employees.ToString().Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Тур")
                {
                    if (searchlist[i].Tours.Country.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Дата регистрации")
                {
                    if (searchlist[i].DateOfRegistration.ToString().Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
            }
            if (resultlist.Count == 0)
            {
                MessageBox.Show("Нет данных, которые соответствуют этим критериям!");
                return;
            }
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructOrderGrid(resultlist);
        }

        private void SearchTour_point()
        {
            List<Tour_point> searchlist = db.Tour_point.ToList();
            List<Tour_point> resultlist = new List<Tour_point>();
            if (findbox.Text == "" || SearchComboBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }
            for (int i = 0; i < searchlist.Count; i++)
            {
                if (SearchComboBox.Text == "Тур")
                {
                    if (searchlist[i].Tours.Country.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Город")
                {
                    if (searchlist[i].City.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Транспорт")
                {
                    if (searchlist[i].Transports.Name.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Отель")
                {
                    if (searchlist[i].Hotels.Name.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
            }
            if (resultlist.Count == 0)
            {
                MessageBox.Show("Нет данных, которые соответствуют этим критериям!");
                return;
            }
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructTour_PointGrid(resultlist);
        }

        private void SearchTour()
        {
            List<Tours> searchlist = db.Tours.ToList();
            List<Tours> resultlist = new List<Tours>();
            if (findbox.Text == "" || SearchComboBox.Text == "")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }
            for (int i = 0; i < searchlist.Count; i++)
            {
                if (SearchComboBox.Text == "Страна")
                {
                    if (searchlist[i].Country.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Дата прибытия")
                {
                    if (searchlist[i].ArrivalDate.ToString().Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Дата отправления")
                {
                    if (searchlist[i].DepartureDate.ToString().Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Ночей в туре")
                {
                    if (searchlist[i].LengthOfStay == int.Parse(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Стоимость")
                {
                    if (searchlist[i].Tour_cost == int.Parse(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Человек")
                {
                    if (searchlist[i].NumberOfPersons == int.Parse(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
                if (SearchComboBox.Text == "Тип")
                {
                    if (searchlist[i].Type.Contains(findbox.Text))
                        resultlist.Add(searchlist[i]);
                }
            }
            if (resultlist.Count == 0)
            {
                MessageBox.Show("Нет данных, которые соответствуют этим критериям!");
                return;
            }
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            DirectorMain.ConstructTourGrid(resultlist);
        }
    }
}