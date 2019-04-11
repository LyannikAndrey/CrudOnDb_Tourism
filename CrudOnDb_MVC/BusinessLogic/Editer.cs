using System.Linq;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.BusinessLogic
{
    class Editer
    {

        TourismDB db;
        Director DirectorMain { get; set; }

        public Editer(TourismDB db, Director DirectorMain)
        {
            this.db = db;
            this.DirectorMain = DirectorMain;
        }

        public void EditClient(int index, Clients client)
        {
            DirectorMain.CommitEdit();
            db.Clients.ToList()[index].Surname = client.Surname;
            db.Clients.ToList()[index].Name = client.Name;
            db.Clients.ToList()[index].Patronymic = client.Patronymic;
            db.Clients.ToList()[index].Phone = client.Phone;
            db.Clients.ToList()[index].Email = client.Email;
            db.Clients.ToList()[index].Address = client.Address;
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructClientGrid(db.Clients.ToList());
        }

        public void EditEmployee(int index, Employees employee)
        {
            DirectorMain.CommitEdit();
            db.Employees.ToList()[index].Surname = employee.Surname;
            db.Employees.ToList()[index].Name = employee.Name;
            db.Employees.ToList()[index].Patronymic = employee.Patronymic;
            db.Employees.ToList()[index].Phone = employee.Phone;
            db.Employees.ToList()[index].Email = employee.Email;
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructEmployeeGrid(db.Employees.ToList());
        }

        public void EditHotel(int index, Hotels hotel)
        {
            DirectorMain.CommitEdit();
            db.Hotels.ToList()[index].Rating = hotel.Rating;
            db.Hotels.ToList()[index].Name = hotel.Name;
            db.Hotels.ToList()[index].HotelCost = hotel.HotelCost;
            db.Hotels.ToList()[index].TypeOfRoom = hotel.TypeOfRoom;
            db.Hotels.ToList()[index].Accommodation = hotel.Accommodation;
            db.Hotels.ToList()[index].Food = hotel.Food;
            db.Hotels.ToList()[index].Address = hotel.Address;
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructHotelGrid(db.Hotels.ToList());
        }

        public void EditOrder(int index, Orders order)
        {
            DirectorMain.CommitEdit();
            db.Orders.ToList()[index].Client_ID = order.Client_ID;
            db.Orders.ToList()[index].Employee_ID = order.Employee_ID;
            db.Orders.ToList()[index].Tour_ID = order.Tour_ID;
            db.Orders.ToList()[index].DateOfRegistration = order.DateOfRegistration;
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructOrderGrid(db.Orders.ToList());
        }

        public void EditTour_Point(int index, Tour_point tourPoint)
        {
            DirectorMain.CommitEdit();
            db.Tour_point.ToList()[index].Tour_ID = tourPoint.Tour_ID;
//            db.SaveChanges();
            db.Tour_point.ToList()[index].City = tourPoint.City;
            db.Tour_point.ToList()[index].Tour_ID = tourPoint.Tour_ID;
            db.Tour_point.ToList()[index].Hotel_ID = tourPoint.Hotel_ID;
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructTour_PointGrid(db.Tour_point.ToList());
        }

        public void EditTour(int index, Tours tour)
        {
            DirectorMain.CommitEdit();
            db.Tours.ToList()[index].Country = tour.Country;
            db.Tours.ToList()[index].ArrivalDate = tour.ArrivalDate;
            db.Tours.ToList()[index].DepartureDate = tour.DepartureDate;
            db.Tours.ToList()[index].LengthOfStay = tour.LengthOfStay;
            db.Tours.ToList()[index].Tour_cost = tour.Tour_cost;
            db.Tours.ToList()[index].NumberOfPersons = tour.NumberOfPersons;
            db.Tours.ToList()[index].Type = tour.Type;
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructTourGrid(db.Tours.ToList());
        }
    }
}