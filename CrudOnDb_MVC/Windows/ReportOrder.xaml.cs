using System.Linq;
using System.Windows;
using CrudOnDb_MVC.BusinessLogic;
using CrudOnDb_MVC.Models;

namespace CrudOnDb_MVC.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportOrder.xaml
    /// </summary>
    public partial class ReportOrder : Window
    {
        public ReportOrder()
        {
            InitializeComponent();
        }

        Facade f;
        TourismDB db;

        public ReportOrder(TourismDB db)
        {
            InitializeComponent();
            this.db = db;
            f = new Facade(db, dataGrid);
            f.ShowTables(true);
            double sum = 0;
            var tours = db.Tours.ToList();
            for (int i = 0; i < tours.Count; i++)
            {
                sum += tours[i].Tour_cost;
            }

            totalSumLabel.Content = $"Общая сумма: {sum:F}";
        }
    }
}
