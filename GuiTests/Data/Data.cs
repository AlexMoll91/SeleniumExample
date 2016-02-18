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

                public static List<string> RoutingNumberList = new List<string>()
                {
                    "021000021",
                    "011401533",
                    "091000019"
                };

                public static List<string> BankTypeList = new List<string>()
                {
                    "C",
                    "S"
                };

                public static List<string> CreditCardList = new List<string>()
                {
                    "4111111111111111",
                    "5555555555554444",
                    "6011111111111117"
                };
            }

            public class AccountOwner
            {
                public AccountOwner()
                {
                    Salutation = Generics.SalutationList[Generics.r.Next(0, Generics.SalutationList.Count - 1)];
                    FirstName = Name.First();
                    LastName = Name.Last();
                    SSN = RandomNumber.Next(111111111,899999999).ToString();
                    DOB = Date.Birthday(18, 90);
                    Year = this.DOB.ToString("yyyy");
                    Month = this.DOB.ToString("MMMM");
                    Day = "13";//this.DOB.ToString("d");
                    Address1 = Address.StreetAddress();
                    PhoneNum = "9045402569";
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

            public class CCInfo
            {
                public CCInfo()
                {
                    FirstName = Name.First();
                    LastName = Name.Last();
                    CCNum = Generics.CreditCardList[RandomNumber.Next(0, 2)];
                    CCCVC = "111";
                    ExpMonth = DateTime.Now.ToString("MM");
                    ExpYear = DateTime.Now.ToString("yyyy");
                    ZipCode = RandomNumber.Next(00001, 99999).ToString();
                }

                public string ZipCode { get; set; }

                public string ExpYear { get; set; }

                public string ExpMonth { get; set; }

                public string CCCVC { get; set; }

                public string CCNum { get; set; }

                public string LastName { get; set; }

                public string FirstName { get; set; }
            }
            public class ACHInfo
            {
                public ACHInfo()
                {
                    BankName = Company.Name();
                    BankRouting = Generics.RoutingNumberList[Generics.r.Next(0, 2)];
                    BankAccountNum = RandomNumber.Next(1001, 3000000000).ToString();
                    BankAccountType = Generics.BankTypeList[RandomNumber.Next(0, 1)];
                }

                public string BankAccountType { get; set; }

                public string BankAccountNum { get; set; }

                public string BankRouting { get; set; }

                public string BankName { get; set; }
            }
            public class Beneficiary
            {
                public Beneficiary()
                {
                   
                    FirstName = Name.First();
                    LastName = Name.Last();
                    SSN = RandomNumber.Next(111111111,899999999).ToString();
                    DOB = Date.Birthday(1, 12);
                    Year = DOB.ToString("yyyy");
                    Month = DOB.ToString("MMMM");
                    Day = "13";//DOB.ToString("d");
                    Address1 = Address.StreetAddress();
                    City = Address.City();
                    State = Address.StateAbbreviation();
                    Zip = Address.ZipCode();
                    AgeGrade = RandomNumber.Next(1, 1);
                }

                public int AgeGrade { get; set; }

                public string Zip { get; set; }

                public string State { get; set; }

                public string City { get; set; }


                public string Address1 { get; set; }

                public string Day { get; set; }

                public string Month { get; set; }

                public string Year { get; set; }

                public DateTime DOB { get; set; }

                public string SSN { get; set; }

                public string LastName { get; set; }

                public string FirstName { get; set; }

            }
        

        public class AccountInfo
            {
                public AccountInfo()
                {
                    this.username = Generics.r.Next(50000).ToString();
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
