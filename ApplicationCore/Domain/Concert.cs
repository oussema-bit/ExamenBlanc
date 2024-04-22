using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Concert
    {
        public double Cachet { get; set; }
        public DateTime DateConcert { get; set; }
        public int Duree {  get; set; }

        public int ArtisteFK {  get; set; }
        public int FestivalFK {  get; set; }
    }
}
