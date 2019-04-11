using System.Linq;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.BusinessLogic
{
    class Deliter
    {
        TourismDB db;
        Director DirectorMain { get; set; }

        public Deliter(TourismDB db, Director directorMain)
        {
            this.db = db;
            this.DirectorMain = directorMain;
        }

        public void DeleteClient(int index)
        {
            DirectorMain.CommitEdit();
            db.Clients.Remove(db.Clients.ToList()[index]);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructClienGrid();
        }

        public void DeleteEmployee(int index)
        {
            DirectorMain.CommitEdit();
            db.Employees.Remove(db.Employees.ToList()[index]);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructEmployeeGrid();
        }

        public void DeleteHotel(int index)
        {
            DirectorMain.CommitEdit();
            db.Hotels.Remove(db.Hotels.ToList()[index]);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructHotelGrid();
        }

        public void DeleteOrder(int index)
        {
            DirectorMain.CommitEdit();
            db.Orders.Remove(db.Orders.ToList()[index]);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructOrderGrid();
        }

        public void DeleteTour_point(int index)
        {
            DirectorMain.CommitEdit();
            db.Tour_point.Remove(db.Tour_point.ToList()[index]);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructTour_PointGrid();
        }

        public void DeleteTour(int index)
        {
            DirectorMain.CommitEdit();
            db.Tours.Remove(db.Tours.ToList()[index]);
            db.SaveChanges();
            DirectorMain.ClearGrid();
            DirectorMain.ConstructTourGrid();
        }
    }
}