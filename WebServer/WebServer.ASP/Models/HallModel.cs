using CinemaLibrary.Entity;

namespace WebServer.ASP.Models
{
    public class HallModel
    {
        public int HallNumber { get; set; }
        public string HallName { get; set; }
        public List<RowModel> Rows { get; set; }

        public HallModel(CinemaHall hall, Seance seance) {
            this.HallNumber = hall.HallNumber;
            this.HallName = hall.HallName;
            List<RowModel> rows = new List<RowModel>();
            foreach (var r in hall.Rows)
                rows.Add(new RowModel(r, seance));
            this.Rows = rows;

        }
        HallModel() { }
    }
}
