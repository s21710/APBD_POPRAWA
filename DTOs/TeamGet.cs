using probne_kolokwium.Entities.Models;
using System;
using System.Collections.Generic;

namespace probne_kolokwium.DTOs
{
    public class TeamGet
    {
        public string TeamName { get; set; }
        public string TeamDesciption { get; set; }

        public string Organization { get; set; }

        public List<Member> Members { get; set; }
    }

    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
    }


}
