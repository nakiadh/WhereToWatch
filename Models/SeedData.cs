using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereToWatch.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Show.Any())
                {
                    return;
                }

                List<Show> shows = new List<Show> {
                    new Show {ShowId = 1, Title = "Blazing Saddles", ReleaseDate = DateTime.Parse("1974-2-7"), Genre = "Comedy", Type = "Movie", Rating = "R"},
                    new Show {ShowId = 2, Title = "Only Murders in the Building", ReleaseDate = DateTime.Parse("2021-8-31"), Genre = "Comedy", Type = "TV Series", Rating = "TV-MA"},
                    new Show {ShowId = 3, Title = "Titanic", ReleaseDate = DateTime.Parse("1997-12-19"), Genre = "Drama", Type = "Movie", Rating = "PG-13"},
                    new Show {ShowId = 4, Title = "Ted Lasso", ReleaseDate = DateTime.Parse("2020-8-14"), Genre = "Comedy", Type = "TV Series", Rating = "TV-MA"},
                    new Show {ShowId = 5, Title = "A Hard Day's Night", ReleaseDate = DateTime.Parse("1964-7-7"), Genre = "Comedy", Type = "Movie", Rating = "G"},
                    new Show {ShowId = 6, Title = "Help!", ReleaseDate = DateTime.Parse("1965-8-25"), Genre = "Comedy", Type = "Movie", Rating = "G"},
                    new Show {ShowId = 7, Title = "Supernatural", ReleaseDate = DateTime.Parse("2005-9-13"), Genre = "Drama", Type = "TV Series", Rating = "TV-14"},
                    new Show {ShowId = 8, Title = "Doctor Who", ReleaseDate = DateTime.Parse("1963-11-23"), Genre = "Adventure", Type = "TV Series", Rating = "TV-PG"},
                    new Show {ShowId = 9, Title = "The Lord of the Rings: The Fellowship of the Ring", ReleaseDate = DateTime.Parse("2001-12-19"), Genre = "Adventure", Type = "Movie", Rating = "PG-13"},
                    new Show {ShowId = 10, Title = "The Lord of the Rings: The Two Towers", ReleaseDate = DateTime.Parse("2002-12-18"), Genre = "Adventure", Type = "Movie", Rating = "PG-13"},
                    new Show {ShowId = 11, Title = "The Lord of the Rings: The Return of the King", ReleaseDate = DateTime.Parse("2003-12-17"), Genre = "Adventure", Type = "Movie", Rating = "PG-13"},
                    new Show {ShowId = 12, Title = "The Closer", ReleaseDate = DateTime.Parse("2005-6-13"), Genre = "Drama", Type = "TV Series", Rating = "TV-14"},
                    new Show {ShowId = 13, Title = "Extras", ReleaseDate = DateTime.Parse("2005-7-21"), Genre = "Comedy", Type = "TV Series", Rating = "TV-MA"},
                    new Show {ShowId = 14, Title = "The Falcon and the Winter Soldier", ReleaseDate = DateTime.Parse("2021-3-19"), Genre = "Action", Type = "TV Series", Rating = "TV-14"},
                    new Show {ShowId = 15, Title = "Top Hat", ReleaseDate = DateTime.Parse("1935-9-6"), Genre = "Musical", Type = "Movie", Rating = "Not Rated"},
                    new Show {ShowId = 16, Title = "Parks and Recreation", ReleaseDate = DateTime.Parse("2009-4-9"), Genre = "Comedy", Type = "TV Series", Rating = "TV-14"},
                    new Show {ShowId = 17, Title = "Knives Out", ReleaseDate = DateTime.Parse("2019-11-27"), Genre = "Comedy", Type = "Movie", Rating = "PG-13"},
                    new Show {ShowId = 18, Title = "The West Wing", ReleaseDate = DateTime.Parse("1999-9-22"), Genre = "Drama", Type = "TV Series", Rating = "TV-14"},
                    new Show {ShowId = 19, Title = "Waking Ned Devine", ReleaseDate = DateTime.Parse("1999-1-8"), Genre = "Comedy", Type = "Movie", Rating = "PG"},
                    new Show {ShowId = 20, Title = "The Golden Girls", ReleaseDate = DateTime.Parse("1985-9-14"), Genre = "Comedy", Type = "TV Series", Rating = "TV-PG"},
                    new Show {ShowId = 21, Title = "The Beatles: Get Back", ReleaseDate = DateTime.Parse("2021-11-25"), Genre = "Documentary", Type = "TV Series", Rating = "TV-14"},
                    new Show {ShowId = 22, Title = "Clue", ReleaseDate = DateTime.Parse("1985-12-13"), Genre = "Comedy", Type = "Movie", Rating = "PG"},
                    new Show {ShowId = 23, Title = "Poirot", ReleaseDate = DateTime.Parse("1986-1-8"), Genre = "Mystery", Type = "TV Series", Rating = "TV-14"},
                    new Show {ShowId = 24, Title = "Psych", ReleaseDate = DateTime.Parse("2006-7-7"), Genre = "Comedy", Type = "TV Series", Rating = "TV-PG"},
                    new Show {ShowId = 25, Title = "Stargate", ReleaseDate = DateTime.Parse("1994-10-28"), Genre = "Sci-Fi", Type = "Movie", Rating = "PG-13"},
                };
                context.AddRange(shows);

                List<Service> services = new List<Service> {
                    new Service {ServiceId = 1, Name = "Netflix", WebAddress = "www.netflix.com"},
                    new Service {ServiceId = 2, Name = "Hulu", WebAddress = "www.hulu.com"},
                    new Service {ServiceId = 3, Name = "Amazon Prime", WebAddress = "www.amazon.com/Prime-Video/b?node=2676882011"},
                    new Service {ServiceId = 4, Name = "AppleTV", WebAddress = "tv.apple.com"},
                    new Service {ServiceId = 5, Name = "Disney+", WebAddress = "www.disneyplus.com"},
                    new Service {ServiceId = 6, Name = "Peacock", WebAddress = "www.peacocktv.com"},
                    new Service {ServiceId = 7, Name = "HBO Max", WebAddress = "www.hbomax.com"},
                };
                context.AddRange(services);

                List<ShowService> streaming = new List<ShowService> {
                    new ShowService {ServiceId = 1, ShowId = 3},
                    new ShowService {ServiceId = 1, ShowId = 7},
                    new ShowService {ServiceId = 1, ShowId = 25},

                    new ShowService {ServiceId = 2, ShowId = 2},
                    new ShowService {ServiceId = 2, ShowId = 20},

                    new ShowService {ServiceId = 3, ShowId = 1},
                    new ShowService {ServiceId = 3, ShowId = 3},
                    new ShowService {ServiceId = 3, ShowId = 6},
                    new ShowService {ServiceId = 3, ShowId = 7},
                    new ShowService {ServiceId = 3, ShowId = 8},
                    new ShowService {ServiceId = 3, ShowId = 9},
                    new ShowService {ServiceId = 3, ShowId = 10},
                    new ShowService {ServiceId = 3, ShowId = 11},
                    new ShowService {ServiceId = 3, ShowId = 12},
                    new ShowService {ServiceId = 3, ShowId = 13},
                    new ShowService {ServiceId = 3, ShowId = 15},
                    new ShowService {ServiceId = 3, ShowId = 16},
                    new ShowService {ServiceId = 3, ShowId = 17},
                    new ShowService {ServiceId = 3, ShowId = 18},
                    new ShowService {ServiceId = 3, ShowId = 19},
                    new ShowService {ServiceId = 3, ShowId = 20},
                    new ShowService {ServiceId = 3, ShowId = 22},
                    new ShowService {ServiceId = 3, ShowId = 23},
                    new ShowService {ServiceId = 3, ShowId = 24},
                    new ShowService {ServiceId = 3, ShowId = 25},

                    new ShowService {ServiceId = 4, ShowId = 1},
                    new ShowService {ServiceId = 4, ShowId = 3},
                    new ShowService {ServiceId = 4, ShowId = 4},
                    new ShowService {ServiceId = 4, ShowId = 5},
                    new ShowService {ServiceId = 4, ShowId = 7},
                    new ShowService {ServiceId = 4, ShowId = 8},
                    new ShowService {ServiceId = 4, ShowId = 9},
                    new ShowService {ServiceId = 4, ShowId = 10},
                    new ShowService {ServiceId = 4, ShowId = 11},
                    new ShowService {ServiceId = 4, ShowId = 12},
                    new ShowService {ServiceId = 4, ShowId = 15},
                    new ShowService {ServiceId = 4, ShowId = 16},
                    new ShowService {ServiceId = 4, ShowId = 17},
                    new ShowService {ServiceId = 4, ShowId = 18},
                    new ShowService {ServiceId = 4, ShowId = 20},
                    new ShowService {ServiceId = 4, ShowId = 22},
                    new ShowService {ServiceId = 4, ShowId = 23},
                    new ShowService {ServiceId = 4, ShowId = 24},

                    new ShowService {ServiceId = 5, ShowId = 14},
                    new ShowService {ServiceId = 5, ShowId = 21},

                    new ShowService {ServiceId = 6, ShowId = 16},
                    new ShowService {ServiceId = 6, ShowId = 24},

                    new ShowService {ServiceId = 7, ShowId = 1},
                    new ShowService {ServiceId = 7, ShowId = 5},
                    new ShowService {ServiceId = 7, ShowId = 9},
                    new ShowService {ServiceId = 7, ShowId = 10},
                    new ShowService {ServiceId = 7, ShowId = 11},
                    new ShowService {ServiceId = 7, ShowId = 12},
                    new ShowService {ServiceId = 7, ShowId = 18},
                };
                context.AddRange(streaming);

                context.SaveChanges();
            }
        }
    }
}
