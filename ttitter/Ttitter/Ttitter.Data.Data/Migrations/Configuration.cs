namespace Ttitter.Data.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Ttitter.Common;
    using Ttitter.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TtitterDbContext>
    {
        private IRandomGenerator random;
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(TtitterDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));

            this.SeedUsers(context);
            this.SeedProfiles(context);
            this.SeedMessages(context);
            this.SeedNotifications(context);
            this.SeedTteets(context);
        }

        private void SeedTteets(TtitterDbContext context)
        {
            if (context.Tteets.Any())
            {
                return;
            }

            var profiles = context.Profiles.ToList();

            for (int i = 0; i < 50; i++)
            {
                var tteet = new Tteet
                {
                    Content = this.random.RandomString(100, 500),
                    CreatedOn = DateTime.Now - new TimeSpan(this.random.RandomNumber(200, 500), 0, 0),
                    LastEditedOn = DateTime.Now - new TimeSpan(this.random.RandomNumber(1, 200), 0, 0),
                    Image = this.GetSampleImage("/Migrations/Images/tteet/" + this.random.RandomNumber(1, 5) + ".jpg"),
                    Profile = profiles[this.random.RandomNumber(0, profiles.Count() - 1)],
                    FavourizingProfiles = profiles.Where(p => p.Id % (i + 2) == 0).ToList(),
                    FbSharingProfiles = profiles.Where(p => p.Id % (i + 3) == 0).ToList(),
                    RetteetingProfiles = profiles.Where(p => p.Id % (i + 4) == 0).ToList(),
                    ReportingProfiles = profiles.Where(p => p.Id % (i + 5) == 0).ToList()

                };

                context.Tteets.Add(tteet);
                context.SaveChanges();

                if (i % 3 == 0 && context.Tteets.Count() > 2)
                {
                    tteet.RepliesTo = context.Tteets.Where(t => t.Id != tteet.Id).ToList()[this.random.RandomNumber(0, context.Tteets.Count() - 2)];
                }
            }
        }

        private void SeedNotifications(TtitterDbContext context)
        {

            if (context.Notifications.Any())
            {
                return;
            }

            for (int i = 0; i < 20; i++)
            {
                var profiles = context.Profiles.ToList();

                var notification = new Notification
                {
                    Content = this.random.RandomString(20, 500),
                    NotificationCase = (NotificationCase)Enum.Parse(typeof(NotificationCase), this.random.RandomNumber(0, 2).ToString()),
                    SentOn = DateTime.Now - new TimeSpan(this.random.RandomNumber(300, 500), 0, 0),
                    ViewedOn = DateTime.Now - new TimeSpan(this.random.RandomNumber(0, 300), 0, 0),
                    Profile = profiles[this.random.RandomNumber(0, profiles.Count() - 1)]
                };

                context.Notifications.Add(notification);
            }

            context.SaveChanges();
        }

        private void SeedMessages(TtitterDbContext context)
        {
            if (context.Messages.Any())
            {
                return;
            }

            var profiles = context.Profiles.ToList();

            for (int i = 0; i < 40; i++)
            {
                var message = new Message
                {
                    Content = this.random.RandomString(20, 250),
                    SentOn = DateTime.Now - new TimeSpan(this.random.RandomNumber(1, 500), 0, 0),
                    SenderProfile = profiles[this.random.RandomNumber(0, profiles.Count() - 1)],
                    ReceiverProfile = profiles[this.random.RandomNumber(0, profiles.Count() - 1)]
                };

                context.Messages.Add(message);
            }

            context.SaveChanges();
        }

        private void SeedUsers(TtitterDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    UserName = random.RandomString(6, 50),
                    Email = string.Format("{0}@{1}.com", random.RandomString(4, 25), random.RandomString(4, 35))
                };

                userManager.Create(user, "123456");

                user.Country = (Country)Enum.Parse(typeof(Country), random.RandomNumber(0, 4).ToString());
                user.Language = (Language)Enum.Parse(typeof(Language), random.RandomNumber(0, 4).ToString());
                user.TimeZoneId = TimeZoneInfo.Local.Id;

            }

            context.SaveChanges();
        }

        private void SeedProfiles(TtitterDbContext context)
        {
            if (context.Profiles.Any())
            {
                return;
            }

            var users = context.Users.ToList();

            for (int i = 0; i < 19; i++)
            {
                var profile = new Profile
                {
                    Country = (Country)Enum.Parse(typeof(Country), this.random.RandomNumber(0, 4).ToString()),
                    Language = (Language)Enum.Parse(typeof(Language), this.random.RandomNumber(0, 4).ToString()),
                    TimeZoneId = TimeZoneInfo.Local.Id,
                    Visibility = (VisibilityStatus)Enum.Parse(typeof(VisibilityStatus), this.random.RandomNumber(0, 2).ToString()),
                    User = users[this.random.RandomNumber(0, users.Count() - 1)],
                    Status = (ProfileStatus)Enum.Parse(typeof(ProfileStatus), this.random.RandomNumber(0, 2).ToString()),
                    Image = this.GetSampleImage("/Migrations/Images/profile/" + this.random.RandomNumber(1, 4) + ".jpg"),
                    Name = this.random.RandomString(5, 40)
                };

                context.Profiles.Add(profile);
                context.SaveChanges();

                if (i % 3 == 0)
                {
                    profile.Followed = context.Profiles.Where(p => p.Id % 5 == 0).ToList();
                }
            }

            context.SaveChanges();
        }

        private Image GetSampleImage(string pathExtension)
        {
            var directory = AssemblyHelper.GetDirectoryForAssembyl(Assembly.GetExecutingAssembly());
            var file = File.ReadAllBytes(directory + pathExtension);
            var image = new Image
            {
                Content = file,
                FileExtension = "jpg"
            };

            return image;
        }
    }
}
