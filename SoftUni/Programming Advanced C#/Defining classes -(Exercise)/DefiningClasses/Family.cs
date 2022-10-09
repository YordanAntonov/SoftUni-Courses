using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    internal class Family
    {
        public Family()
        {
            MembersList = new List<Person>();
        }
        public List<Person> MembersList { get; set; }



        public void AddMember(Person member)
        {
            MembersList.Add(member);
        }

        public Person GetOldestMember()
        {
            return MembersList.OrderByDescending(p => p.Age).FirstOrDefault();
        }

    }
}
