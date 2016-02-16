using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;



namespace Structura.GuiTests.Data

    {
        using System.Dynamic;
        using System.Runtime.InteropServices;
        using System.Runtime.Remoting.Metadata.W3cXsd2001;
        using System.Security.Permissions;
        using Faker;

        public class Data
    {
            
            public class Generics
            {
                public static Random r = new Random();

                public static List<string> securityqList = new List<string>()
            {
                "In what city or town was your first job?",
                "In which city were you born?",
                "What is your father's first name?",
                "What is your mother's maiden name?",
                "What is your pet's name?",
                "What school did you attend for sixth grade?"
            };

                public static List<string> SalutationList = new List<string>()
            {
                "Mr.",
                "Ms.",
                "Mrs.",
                "Dr."
            };
            }
            public class AccountOwner
            {
                public AccountOwner()
                {
                    Salutation = Generics.SalutationList[Generics.r.Next(0, Generics.SalutationList.Count - 1)];
                    FirstName = Name.First();
                    LastName = Name.Last();
                    SSN = RandomNumber.Next(899999999).ToString();
                    DOB = Date.Birthday(18, 90);
                    Year = this.DOB.Year.ToString("yyyy");
                    Month = this.DOB.Month.ToString("MMMM");
                    Day = this.DOB.Day.ToString("dd");
                    Address1 = Address.StreetAddress();
                    PhoneNum = Phone.CellNumber();
                    City = Address.City();
                    State = Address.StateAbbreviation();
                    Zip = Address.ZipCode();
                }

                public string Zip { get; set; }

                public string State { get; set; }

                public string City { get; set; }

                public string PhoneNum { get; set; }

                public string Address1 { get; set; }

                public string Day { get; set; }

                public string Month { get; set; }

                public string Year { get; set; }

                public DateTime DOB { get; set; }

                public string SSN { get; set; }

                public string LastName { get; set; }

                public string FirstName { get; set; }

                public string Salutation { get; set; }
            }

            public class AccountInfo
            {
                public AccountInfo()
                {
                    this.username = "KyleCrabtree" + Generics.r.Next(50000);
                    this.Password = "Password1";
                    this.Email = this.username + "@testfpp.com";
                    this.Securityselection = Generics.securityqList[Generics.r.Next(0, Generics.securityqList.Count - 1)];
                    this.Securityanswer = Name.FullName();

                }
                public string username { get; set; }
                public string Password { get; private set; }
                public string Email { get; private set; }
                public string Securityselection { get; private set; }
                public string Securityanswer { get; private set; }
            }


    }

        
    }
