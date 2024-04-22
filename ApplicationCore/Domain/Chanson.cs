using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public enum StyleMusical
    {
        Classique,
        Pop,
        Rap,
        Rock
    }
    public class Chanson
    {
        public int ChansonId{get; set;}
        [DataType(DataType.Date)]
        public DateTime DateSortie { get; set;}
        public int Duree { get; set;}
        public StyleMusical styleMusical { get; set;}

        [MinLength(3, ErrorMessage = "Minimum 3 characteres")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characteres")]
        public string Titre {  get; set;}

        [Range(0, int.MaxValue,ErrorMessage ="Haja !!")]
        public int VuesYoutube {  get; set;}
        public Artiste Artiste { get; set;}
        [ForeignKey("Artiste")]
        public int ArtisteFK { get; set;}

    }
}
