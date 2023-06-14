using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets.Models
{
    public class Actor_Movie
    {
        //for many to many relationship of movie and actors, here movie id is foreign key
        public int MovieID { get; set; }

        //this is for one actor_movie only have one actor and movie , or vice versa like one movie and have multiple actors_movie and one actor can have multiple actor_movie
        //[ForeignKey("MovieID")]
        public Movie Movie  { get; set; }

        //for many to many relationship of movie and actors , here Actor id is foreign key
        public int ActorID { get; set; }

        //this is for one actor_movie only have one actor and movie , or vice versa like one movie and have multiple actors_movie and one actor can have multiple actor_movie
        //[ForeignKey("ActorID")]
        public Actor Actor { get; set; }

    }
}
