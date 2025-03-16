using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag {Text = "web programlama", Url ="web-programlama" , Color = TagColors.danger},
                        new Tag {Text = "backend", Url ="backend", Color = TagColors.info},
                        new Tag {Text = "frontend", Url ="frontend", Color = TagColors.primary},
                        new Tag {Text = "fullstack", Url ="fullstack", Color = TagColors.secondary},
                        new Tag {Text = "php", Url ="php", Color = TagColors.succes}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName = "SavaşBalta" , Name ="Savaş Balta", Email = "savasbalta@gmail.com", Password="123456", İmage = "1.jpg"},
                        new User {UserName = "UmutUysal" , Name ="Umut Uysal", Email = "umutuysal@gmail.com", Password="123456", İmage = "2.jpg"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            Title = "Asp.net core",
                            Content = "Asp.net core dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "aspnet-core",
                            İsActive = true,
                            İmage= "1.jpg",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1,
                            Comments = new List<Comment> {
                                new Comment {Text ="çok iyi bir kurs" , UserId = 1 , PublishedOn = DateTime.Now.AddDays(-20)},
                                new Comment {Text ="kurs çok faydalı tavsiye ederim." , UserId = 2 , PublishedOn = DateTime.Now.AddDays(-10)}
                            }
                        },
                        new Post {
                            Title = "Php",
                            Content = "Php dersleri",
                            Description = "Php dersleri",
                            Url = "php",
                            İsActive = true,
                            İmage= "2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1
                        },
                        new Post {
                            Title = "Django",
                            Content = "Django dersleri",
                            Description = "Django dersleri",
                            Url = "django",
                            İsActive = true,
                            İmage= "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "React",
                            Content = "React dersleri",
                            Description = "React dersleri",
                            Url = "react",
                            İsActive = true,
                            İmage= "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "Angular",
                            Content = "Angular dersleri",
                            Description = "Angular dersler",
                            Url = "angular",
                            İsActive = true,
                            İmage= "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "Web Tasarım",
                            Content = "Web Tasarım dersleri",
                            Description = "Web Tasarım dersleri",
                            Url = "web-tasarım",
                            İsActive = true,
                            İmage= "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(1).ToList(),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}