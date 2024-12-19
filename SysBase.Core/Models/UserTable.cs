using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class UserTable
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string UserId { get; set; }
        public string TableInformation { get; set; }
    }
}
