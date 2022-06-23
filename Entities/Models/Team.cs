﻿using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
