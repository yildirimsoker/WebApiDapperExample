using System;


namespace DapperExample.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
