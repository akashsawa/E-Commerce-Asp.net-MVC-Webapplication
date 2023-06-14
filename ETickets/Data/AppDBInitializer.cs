using ETickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data
{

    //for seeding your database
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<AppDBContext>();
                context.Database.EnsureCreated();

                //cinemas , actors, producers, movies, actors and movies
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>
                    {
                       new Cinema()
                       {
                           Name = "Cinema 1",
                           Logo = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8bQHXz4PCenx7idySgQSs7loyMvIk6cKIdQ&usqp=CAU",
                           Description = "Normal Cinema"

                       },
                       new Cinema()
                       {
                           Name = "Cinema 2",
                           Logo = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRM6POuMUZ2loUtt8fhIgCppoAjt1CictgeDQ&usqp=CAU",
                           Description = "Tough Cinema"
                       }
                    });
                    context.SaveChanges();
                }
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Angelina Jolie",
                            Bio = "Born in United States",
                            ProfilePictureURL = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOJABFpiSFCW7Uwl-l3dgd3Si6OzGDwr58hsMIB5SGEVGyvhaIHhVTcKucirLlY6ZiRX8&usqp=CAU"

                        },
                        new Actor()
                        {
                            FullName = "Zac Efron",
                            Bio = "Zachary David Alexander Efron is an American actor.",
                            ProfilePictureURL = @"https://m.media-amazon.com/images/M/MV5BMTUxNzY3NzYwOV5BMl5BanBnXkFtZTgwNzQ3Mzc4MTI@._V1_.jpg"

                        },
                        new Actor()
                        {
                            FullName = "Zac Efron",
                            Bio = "Zachary David Alexander Efron is an American actor.",
                            ProfilePictureURL = @"https://m.media-amazon.com/images/M/MV5BMTUxNzY3NzYwOV5BMl5BanBnXkFtZTgwNzQ3Mzc4MTI@._V1_.jpg"

                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                           FullName  = "Kevin Feige",
                            Bio = "Kevin Feige is an American film and television producer.",
                            ProfilePictureURL = @"https://lh4.googleusercontent.com/rM1AbfNrF1D7xMKgq2PQnyXMCe0Jd7zCqBqG8SBFG4LN35grwGSZBu9LhQBe3K9_Bmb6ZjOLZn3l2LaKeTI7QZA0h_gEsMw2KzNDuKzZdE8iV967T1CI4IxL-Ndc9ibJOeGfqNoZq-jW_cGisA"



                        },
                        new Producer()
                        {
                           FullName  = "Megan Ellison",
                            Bio = "Margaret Elizabeth Ellison is an American film producer, entrepreneur, and daughter of multibillionaire Larry Ellison.",
                            ProfilePictureURL = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRhFHSbVvu04HR_YG3aPdTde5PCta-LMPdWeA&usqp=CAU"



                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                           Name  = "Life of Pi",
                            Description = "Life of Pi is a Canadian philosophical novel by Yann Martel published in 2001.",
                            ImageUrl = @"https://s.hdnux.com/photos/52/43/70/11157054/6/1200x0.jpg",
                            MoviewCategory = Enums.MoviewCategory.Documentary,
                            StartDate = DateTime.Now.AddDays(-60),
                            EndDate = DateTime.Now.AddDays(5),
                            Price = 300,
                            CinemaID = 1,
                            ProducerID = 2

                        },
                        new Movie()
                        {
                           Name  = "Ghost Rider",
                            Description = "Stunt motorcyclist Johnny Blaze decides to give up his soul to become the Ghost Rider and fight against Blackheart, the son of Mephistopheles, the devil himself.",
                            ImageUrl = @"https://i.pinimg.com/originals/1f/39/f2/1f39f200a351b932175ec9ef6f684218.jpg",
                            MoviewCategory = Enums.MoviewCategory.Action,
                            StartDate = DateTime.Now.AddDays(-40),
                            EndDate = DateTime.Now.AddDays(20),
                            Price = 80,
                            CinemaID = 2,
                            ProducerID = 1

                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                           ActorID=1,
                           MovieID=2

                        },
                       new Actor_Movie()
                        {
                           ActorID=2,
                           MovieID=1

                        }
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}

