﻿using System.Collections.Generic;

namespace GumAdvisor.Authorization.Roles.Dto
{
    public class GetRolesInput
    {
        public List<string> Permissions { get; set; }
    }
}
