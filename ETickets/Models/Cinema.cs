using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Cinemas Logo")]
        public string Logo { get; set; }
        [Display(Name = "Cinemas Name")]
        public string Name { get; set; }
        [Display(Name = "Cinemas Description")]
        public string Description { get; set; }

        //relationship of one cinema belongs to multiple movies
        public System.Collections.Generic.List<Movie> Movies { get; set; }
    }
}
