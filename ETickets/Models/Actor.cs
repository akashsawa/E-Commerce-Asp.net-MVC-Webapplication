using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage ="Profile Picture is requried !...")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required !...")]
        [StringLength(50,MinimumLength = 3, ErrorMessage ="Full Name should be between 3 - 50 characters long !...")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is requried !...")]
        public string Bio { get; set; }

        //relationship
        //this is for one actor_movie only have one actor and movie , or vice versa like one movie and have multiple actors_movie and one actor can have multiple actor_movie
        
        public System.Collections.Generic.List<Actor_Movie> Actor_Movies { get; set; }
    }
}
