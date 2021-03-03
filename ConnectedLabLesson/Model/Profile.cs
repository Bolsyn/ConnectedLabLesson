using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConnectedLabLesson.Model
{
    public class Profile : IComparable<Profile>
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PathToImage { get; set; }

        public int CompareTo(Profile other)
        {
            return this.Login.CompareTo(other.Login);
        }
    }
}
