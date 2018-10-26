using System;
using Dapper.Contrib.Extensions;

namespace LibraryManager.Models
{
    [Table("Rental")]
    public class Rental : IEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Returned { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }            
    }
}