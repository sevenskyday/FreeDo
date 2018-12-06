using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Data
{
    public class User_Relation_Role
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
