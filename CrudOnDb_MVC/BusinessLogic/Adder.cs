using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.BusinessLogic
{
    class Adder
    {
        TourismDB db;
        Director DirectorMain { get; set; }

        public Adder(TourismDB db, Director directorMain)
        {
            this.db = db;
            this.DirectorMain = directorMain;
        }

        public void AddClient(Clients client)
        {
            DirectorMain.CommitEdit();
            db.Clients.Add(client);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructClienGrid();
        }

        public void AddEmployee(Employees employee)
        {
            DirectorMain.CommitEdit();
            db.Employees.Add(employee);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructEmployeeGrid();
        }

        public void AddHotel(Hotels hotel)
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            db.Hotels.Add(hotel);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructHotelGrid();
        }

        public void AddOrder(Orders order)
        {
            DirectorMain.CommitEdit();
            db.Orders.Add(order);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructOrderGrid();
        }

        public void AddTour_point(Tour_point tourPoint)
        {
            DirectorMain.CommitEdit();
            db.Tour_point.Add(tourPoint);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructTour_PointGrid();
        }

        public void AddTour(Tours tour)
        {
            DirectorMain.ClearGrid();
            DirectorMain.CommitEdit();
            db.Tours.Add(tour);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructTourGrid();
        }
    }
}