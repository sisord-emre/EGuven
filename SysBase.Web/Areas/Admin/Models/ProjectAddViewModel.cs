﻿using SysBase.Core.Models;

namespace SysBase.Web.Areas.Admin.Models
{
    internal class ProjectAddViewModel
    {
        public MenuPermission MenuPermission { get; set; }
        public Project Project { get; set; }
        public List<Company> Companys { get; set; }
    }
}