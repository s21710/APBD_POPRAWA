using System;
using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public int OrganizationID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }

        public string MemberNickName { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
