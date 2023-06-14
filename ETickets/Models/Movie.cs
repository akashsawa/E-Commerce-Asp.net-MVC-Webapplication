using ETickets.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MoviewCategory MoviewCategory { get; set; }

        public string ImageUrl { get; set; }

        //this is for one actor_movie only have one actor and movie , or vice versa like one movie and have multiple actors_movie and one actor can have multiple actor_movie
        public System.Collections.Generic.List<Actor_Movie> Actor_Movies { get; set; }

        //relationship of one cinema belongs to multiple movies , or one movie belongs to only one cinmea
        [ForeignKey("CinemaID")]
        public Cinema Cinema { get; set; }

        // foreign key CinemaID
        public int CinemaID { get; set; }


        //relationship of one producer belongs to multiple movies , or one movie belongs to only one producer
        [ForeignKey("CinemaID")]
        public Producer Producer { get; set; }

        // foreign key ProducerID
        public int ProducerID { get; set; }
    }
}
