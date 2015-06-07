﻿namespace eLibrary.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using eLibrary.DAL;
    using MvcMembership;
    using eLibrary.Model;
    using eLibrary.DAL;
    // using eLibrary.DAL;

    internal sealed class eLConfiguration : DbMigrationsConfiguration<eLibrary.DAL.eLContext>
    {
        public eLConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
           
        }


        protected override void Seed(eLContext context)
        {

            //if (!Roles.RoleExists("Admin"))
            //{
            //    Roles.CreateRole("Admin");
            //}

            if (!Roles.RoleExists("SuperAdmin"))
            {
                Roles.CreateRole("SuperAdmin");
            }
            if (!Roles.RoleExists("Student"))
            {
                Roles.CreateRole("Student");
            }
            if (!Roles.RoleExists("Staff"))
            {
                Roles.CreateRole("Staff");
            }

            if (!Roles.RoleExists("NonTeaching-Staff"))
            {
                Roles.CreateRole("NonTeaching-Staff");
            }

            //if (!Roles.RoleExists("Teacher"))
            //{
            //    Roles.CreateRole("Teacher");
            //}



            if (Membership.GetUser("5000001") == null)
            {
                UnitOfWork work = new UnitOfWork();
                Membership.CreateUser("5000001", "ariyoo", "kayode@yahoo.com");
                Roles.AddUserToRole("5000001", "SuperAdmin");

                LibraryUser theLabUser = new LibraryUser
                {
                    DOB = DateTime.Now,
                    FirstName = "Obi",
                    LastName = "Obi",
                    Level =  null,//createUserViewModel.Level,
                    UserName = "5000001",// createUserViewModel.Username,
                    LevelType = null, //createUserViewModel.LevelType,
                    LevelTaught =null, //createUserViewModel.LevelTaught,
                    LevelTaughtType =null,// createUserViewModel.LevelTaughtType,
                    TelePhoneNumber = null,// createUserViewModel.Telephone,
                    ClassTeacher = null,// createUserViewModel.ClassTeacher,
                    UserType =  "SuperAdmin",// createUserViewModel.UserType,

                };
                work.LibraryUserRepository.Insert(theLabUser);
                work.Save();

               // LibraryUser theUser = work.LibraryUserRepository.Get().Last();
               // Int32 theUserName = 2000000 + theUser.LibraryUserID + 1;
            }

            //    LibraryUser theLabUser = new LibraryUser
            //    {
            //        DOB = DateTime.Now,
            //        FirstName = "kayode",
            //        LastName = "kayode",
            //        Level = "",
            //        UserName = "kayode",
            //        LevelType = "",
            //        LevelTaught = "",
            //        LevelTaughtType = "",
            //        TelePhoneNumber = "08166196673",
            //        ClassTeacher = "",
            //        UserType = "NonTeaching-Staff",
            //        EnrollmentDate = DateTime.Now

            //    };

            //    work.LibraryUserRepository.Insert(theLabUser);
            //    work.Save();
            //    if (work.LevelRepository.Get().ToList().Count == 0)
            //    {
            //        Level theLEvel = new Level();
            //        theLEvel.Name = "JSS1";
            //        work.LevelRepository.Insert(theLEvel);

            //        Level theLEvelJSS2 = new Level();
            //        theLEvelJSS2.Name = "JSS2";
            //        work.LevelRepository.Insert(theLEvelJSS2);

            //        Level theLEvelJSS3 = new Level();
            //        theLEvelJSS3.Name = "JSS3";
            //        work.LevelRepository.Insert(theLEvelJSS3);

            //        Level theLEvelSS1 = new Level();
            //        theLEvelSS1.Name = "SS1";
            //        work.LevelRepository.Insert(theLEvelSS1);

            //        Level theLEvelSS2 = new Level();
            //        theLEvelSS2.Name = "SS2";
            //        work.LevelRepository.Insert(theLEvelSS2);

            //        Level theLEvelSS3 = new Level();
            //        theLEvelSS3.Name = "SS3";
            //        work.LevelRepository.Insert(theLEvelSS3);
            //        work.Save();

            //    }

            //    if (work.MyRoleRepository.Get().ToList().Count == 0)
            //    {
            //        MyRole theRole1 = new MyRole();
            //        theRole1.RoleName = "Student";
            //        theRole1.Upload = "";
            //        theRole1.Exam = "List-Create-";
            //        theRole1.Book = "";
            //        theRole1.BorrowedItem = "Details-";
            //        theRole1.Shelf = "Details-";
            //        theRole1.Course = "";
            //        work.MyRoleRepository.Insert(theRole1);



            //        MyRole theRole2 = new MyRole();
            //        theRole2.RoleName = "SuperAdmin";
            //        theRole2.Upload = "";
            //        theRole2.Exam = "";
            //        theRole2.Book = "";
            //        theRole2.BorrowedItem = "";
            //        theRole2.Shelf = "";
            //        theRole2.Course = "";
            //        work.MyRoleRepository.Insert(theRole2);


            //        MyRole theRole3 = new MyRole();
            //        theRole3.RoleName = "Admin";
            //        theRole3.Upload = "List-Create-Edit-";
            //        theRole3.Exam = "";
            //        theRole3.Book = "";
            //        theRole3.BorrowedItem = "List-Create-Edit-Delete-";
            //        theRole3.Shelf = "List-";
            //        theRole3.Course = "List-";
            //        work.MyRoleRepository.Insert(theRole3);


            //        MyRole theRole4 = new MyRole();
            //        theRole4.RoleName = "Teacher";
            //        theRole4.Upload = "List-Create-Edit-Delete-Details-";
            //        theRole4.Exam = "List-Create-Edit-Delete-Details-";
            //        theRole4.Book = "List-Details-";
            //        theRole4.BorrowedItem = "";
            //        theRole4.Shelf = "";
            //        theRole4.Course = "List-Create-Edit-Delete-Details-";
            //        work.MyRoleRepository.Insert(theRole4);
            //        work.Save();

            //  }

        }




        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
        //    if (!Roles.RoleExists("Admin"))
        //    {
        //        Roles.CreateRole("Admin");
        //    }

        //    if (!Roles.RoleExists("User"))
        //    {
        //        Roles.CreateRole("User");
        //    }




        //    if (Membership.GetUser("kazeemkz") == null)
        //    {
        //        Membership.CreateUser("kazeemkz", "oyeyemi", "kazeemkz@yahoo.com");
        //        Roles.AddUserToRole("kazeemkz", "Admin");
        //    }
        //    context.Cards.AddOrUpdate(d => d.CardNumber, new Card() { CardNumber = "12345678909" },
        //    new Card { CardNumber = "8901234456" },
        //    new Card { CardNumber = "8901234456" },
        //    new Card { CardNumber = "8901234426" },
        //    new Card { CardNumber = "8901234656" });

        //    context.Subscriptions.AddOrUpdate(d => d.StartDate, new Subscription { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), SubNature = SubscriptionStatus.Active, UserName = "wasiu", LoadCard = "1234568900" });
        //    context.JHUsers.AddOrUpdate(d => d.UserName, new JHUser() { Email = "wasiuabioye@gmail.com", UserName = "wasiu", AreaOfInterest = "Computer Programming", EnableAlert = false, MobileNumber = "08008320847" });
        //    Membership.CreateUser("wasiu", "wasiuabioye", "wasiu@yahoo.com");
        //    Roles.AddUserToRole("wasiu", "User");
    }
}

