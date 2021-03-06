using Dapper.Contrib.Extensions;

namespace LibraryManager.Api.Models.Entities
{
    [Table("User")]
    public class User : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public string LastName { get; set; }
    }
}