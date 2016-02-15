using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;



namespace Structura.GuiTests.Data

    {

    public class Data
    {
        Random r = new Random();
        public string _username = "";
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Securityselection { get; private set; }
        public string Securityanswer { get; private set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public Data()
        {
            _username = "KyleCrabtree" + r.Next(50000);
            Password = "Password1";
            Email = _username + "@testfpp.com";
            List<string> securityqList = new List<string>()
            {
                "In what city or town was your first job?",
                "In which city were you born?",
                "What is your father's first name?",
                "What is your mother's maiden name?",
                "What is your pet's name?",
                "What school did you attend for sixth grade?"
            };
            Securityselection = securityqList[r.Next(0, securityqList.Count - 1)];
            Securityanswer = Faker.Name.FullName();

        }
    }
}
