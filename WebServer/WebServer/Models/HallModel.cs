using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebServer.Models
{
    public class HallModel
    {
        public int HallNumber { get; set; }
        public string HallName { get; set; }
        public List<RowModel> Rows { get; set; }

        public HallModel(int hallNumber, string hallName,List<RowModel> rows) { 
        this.HallNumber = hallNumber;
            this.HallName = hallName;
            this.Rows = rows;
        }
    }
}
