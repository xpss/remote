using System;

namespace DiplomApp.Models
{
    public class PointModel
    {
        public int PointId { get; set; }
        public UserModel User { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Xv { get; set; }
        public int Yv { get; set; }
        public int Zv { get; set; }
        public DateTime Date { get; set; }
    }
}
