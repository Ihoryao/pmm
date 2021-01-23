using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp3.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Sage> Sages { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testDB;Username=postgres;Password=2402076");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Sage-Book;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Sage>().HasData(
                new Sage[]
                {
                    new Sage
                    {
                        SageId = 1,
                        Name = "Bob",
                        Age = 18,
                        City = "Monaco",
                        Photo = "file.png"
                    },
                    new Sage
                    {
                        SageId = 2,
                        Name = "Toby",
                        Age = 19,
                        City = "Lviv",
                        Photo = "file.png"
                    },
                    new Sage
                    {
                        SageId = 3,
                        Name = "Василь",
                        Age = 25,
                        City = "Lviv",
                        Photo = "file.png"
                    },
                    new Sage
                    {
                        SageId = 4,
                        Name = "Богдан",
                        Age = 39,
                        City = "Odessa",
                        Photo = "file.png"
                    },
                    new Sage
                    {
                        SageId = 5,
                        Name = "Оля",
                        Age = 18,
                        City = "Львів",
                        Photo = "file.png"
                    },
                    new Sage
                    {
                        SageId = 6,
                        Name = "Юля",
                        Age = 22,
                        City = "Львів",
                        Photo = "file.png"
                    },
                    new Sage
                    {
                        SageId = 7,
                        Name = "Мар'яна",
                        Age = 21,
                        City = "Львів",
                        Photo = "file.png"
                    },
                    new Sage
                    {
                        SageId = 8,
                        Name = "Alex",
                        Age = 30,
                        City = "Warsaw",
                        Photo = "file.png"
                    }
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book
                    {
                        BookId = 1,
                        Name = "In Search of Lost Time",
                        Description =
                            "Swann's Way, the first part of A la recherche de temps perdu, Marcel Proust's seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work. "
                    },
                    new Book
                    {
                        BookId = 2,
                        Name = "Ulysses",
                        Description =
                            "Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. The title parallels and alludes to Odysseus (Latinised into Ulysses), the hero of Homer's Odyss..."
                    },
                    new Book
                    {
                        BookId = 3,
                        Name = "Don Quixote",
                        Description =
                            "Alonso Quixano, a retired country gentleman in his fifties, lives in an unnamed section of La Mancha with his niece and a housekeeper. He has become obsessed with books of chivalry, and believes th..."
                    },
                    new Book
                    {
                        BookId = 4,
                        Name = "The Great Gatsby",
                        Description =
                            "The novel chronicles an era that Fitzgerald himself dubbed the Jazz Age. Following the shock and chaos of World War I, American society enjoyed unprecedented levels of prosperity during the roar..."
                    },
                    new Book
                    {
                        BookId = 5,
                        Name = "One Hundred Years of Solitude",
                        Description =
                            "One of the 20th century's enduring works, One Hundred Years of Solitude is a widely beloved and acclaimed novel known throughout the world, and the ultimate achievement in a Nobel Prize–winning car..."
                    },
                    new Book
                    {
                        BookId = 6,
                        Name = "Moby Dick",
                        Description =
                            "First published in 1851, Melville's masterpiece is, in Elizabeth Hardwick's words, the greatest novel in American literature. The saga of Captain Ahab and his monomaniacal pursuit of the white wh..."
                    },
                    new Book
                    {
                        BookId = 7,
                        Name = "War and Peace",
                        Description =
                            "Epic in scale, War and Peace delineates in graphic detail events leading up to Napoleon's invasion of Russia, and the impact of the Napoleonic era on Tsarist society, as seen through the eyes of fi..."
                    },
                    new Book
                    {
                        BookId = 8,
                        Name = "Lolita",
                        Description =
                            "The book is internationally famous for its innovative style and infamous for its controversial subject: the protagonist and unreliable narrator, middle aged Humbert Humbert, becomes obsessed and se..."
                    },
                    new Book
                    {
                        BookId = 9,
                        Name = "Hamlet",
                        Description =
                            "The Tragedy of Hamlet, Prince of Denmark, or more simply Hamlet, is a tragedy by William Shakespeare, believed to have been written between 1599 and 1601. The play, set in Denmark, recounts how Pri..."
                    }
                }
            );
        }
    }
}