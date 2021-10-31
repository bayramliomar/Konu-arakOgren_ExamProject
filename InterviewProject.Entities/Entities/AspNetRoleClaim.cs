﻿using System;
using System.Collections.Generic;

#nullable disable

namespace InterviewProject.Entities.Entities
{
    public partial class AspNetRoleClaim
    {
        public long Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual AspNetRole Role { get; set; }
    }
}
