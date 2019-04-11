using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.BusinessLogic
{
    public abstract class Builder
    {
        public abstract void BuildBaseSetings();
        public abstract void BuildColumns(List<string> headers, List<string> bindings);
        public abstract void BuildConnection(IEnumerable data);
        public abstract DataGrid GetDataGrid();
        public abstract void Clear();
    }

    public class GridBuilder : Builder
    {
        private DataGrid _dataGrid;

        public GridBuilder(DataGrid dataGrid)
        {
            this._dataGrid = dataGrid;
        }

        public override void BuildBaseSetings()
        {
            _dataGrid.CanUserAddRows = false;
            _dataGrid.AutoGenerateColumns = false;
            _dataGrid.IsReadOnly = true;
        }

        public override void BuildColumns(List<string> headers, List<string> bindings)
        {
            if (headers.Count != bindings.Count)
                return;
            for (int i = 0; i < headers.Count; i++)
                _dataGrid.Columns.Add(GetColumn(headers[i], bindings[i]));
        }

        private DataGridTextColumn GetColumn(string header, string binding)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = header;
            textColumn.Binding = new Binding(binding);
            return textColumn;
        }
        public override void BuildConnection(IEnumerable data)
        {
            _dataGrid.ItemsSource = data;
        }

        public override DataGrid GetDataGrid()
        {
            return _dataGrid;
        }

        public override void Clear()
        {
            _dataGrid.ItemsSource = null;
            _dataGrid.Columns.Clear();
        }
    }

    public class Director
    {
        public Builder builder;
        TourismDB db;

        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void CommitEdit()
        {
            builder.GetDataGrid().CommitEdit();
        }

        public void ClearGrid()
        {
            builder.Clear();
        }

        public void SetDB(TourismDB db)
        {
            this.db = db;
        }

        internal void ConstructClienGrid()
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(db.Clients.ToList());
            builder.BuildColumns(new List<string>() { "Фамилия", "Имя", "Отчество", "Телефон", "E-mail", "Адрес" },
                new List<string>() { "Surname", "Name", "Patronymic", "Phone", "Email", "Address" });
        }
        public void ConstructClientGrid(IEnumerable data)
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(data);
            builder.BuildColumns(new List<string>() { "Фамилия", "Имя", "Отчество", "Телефон", "E-mail", "Адрес" },
                new List<string>() { "Surname", "Name", "Patronymic", "Phone", "Email", "Address" });
        }

        public void ConstructEmployeeGrid()
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(db.Employees.ToList());
            builder.BuildColumns(new List<string>() { "Фамилия", "Имя", "Отчество", "Телефон", "E-mail" },
                new List<string>() { "Surname", "Name", "Patronymic", "Phone", "Email" });
        }
        public void ConstructEmployeeGrid(IEnumerable data)
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(data);
            builder.BuildColumns(new List<string>() { "Фамилия", "Имя", "Отчество", "Телефон", "E-mail" },
                new List<string>() { "Surname", "Name", "Patronymic", "Phone", "Email" });
        }

        public void ConstructHotelGrid()
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(db.Hotels.ToList());
            builder.BuildColumns(new List<string>() { "Звёзды", "Название", "Цена", "Тип комнаты", "Размещение", "Питание", "Адрес" },
                new List<string>() { "Rating", "Name", "HotelCost", "TypeOfRoom", "Accommodation", "Food", "Address" });
        }
        public void ConstructHotelGrid(IEnumerable data)
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(data);
            builder.BuildColumns(new List<string>() { "Звёзды", "Название", "Цена", "Тип комнаты", "Размещение", "Питание", "Адрес" },
                new List<string>() { "Rating", "Name", "HotelCost", "TypeOfRoom", "Accommodation", "Food", "Address" });
        }

        public void ConstructOrderGrid()
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(db.Orders.ToList());
            builder.BuildColumns(new List<string>() { "Заказчик", "Сотрудник", "Тур", "Дата регистрации" },
                new List<string>() { "Clients", "Employees", "Tours.Country", "DateOfRegistration" });
        }
        public void ConstructOrderGrid(IEnumerable data)
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(data);
            builder.BuildColumns(new List<string>() { "Заказчик", "Сотрудник", "Тур", "Дата регистрации" },
                new List<string>() { "Clients", "Employees", "Tours.Country", "DateOfRegistration" });
        }

        public void ConstructTour_PointGrid()
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(db.Tour_point.ToList());
            builder.BuildColumns(new List<string>() { "Тур", "Город", "Транспорт", "Отель" },
                new List<string>() { "Tours.Country", "City", "Transports.Name", "Hotels.Name" });
        }

        public void ConstructTour_PointGrid(IEnumerable data)
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(data);
            builder.BuildColumns(new List<string>() { "Тур", "Город", "Транспорт", "Отель" },
                new List<string>() { "Tours.Country", "City", "Transports.Name", "Hotels.Name" });
        }

        public void ConstructTourGrid()
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(db.Tours.ToList());
            builder.BuildColumns(new List<string>() { "Страна", "Дата прибытия", "Дата отправления", "Ночей в туре",  "Стоимость", "Человек", "Тип" },
                new List<string>() { "Country", "ArrivalDate", "DepartureDate", "LengthOfStay", "Tour_cost", "NumberOfPersons", "Type" });
        }
        public void ConstructTourGrid(IEnumerable data)
        {
            builder.BuildBaseSetings();
            builder.BuildConnection(data);
            builder.BuildColumns(new List<string>() { "Страна", "Дата прибытия", "Дата отправления", "Ночей в туре", "Стоимость", "Человек", "Тип" },
                new List<string>() { "Country", "ArrivalDate", "DepartureDate", "LengthOfStay", "Tour_cost", "NumberOfPersons", "Type" });
        }
    }
}