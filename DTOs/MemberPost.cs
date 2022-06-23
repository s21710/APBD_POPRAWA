using probne_kolokwium.Entities.Models;
using System;
using System.Collections.Generic;

namespace probne_kolokwium.DTOs
{
    public class MemberPost
    {
        public int MemberID { get; set; }

        public List<Organization> Organizations { get; set; }
    }

}
