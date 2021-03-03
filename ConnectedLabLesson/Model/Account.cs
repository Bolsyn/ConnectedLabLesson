using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConnectedLabLesson.Model
{
    public class Account : IComparable<Account>
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public int CompareTo( Account other)
        {
            return this.Login.CompareTo(other.Login);
        }
    }
}
