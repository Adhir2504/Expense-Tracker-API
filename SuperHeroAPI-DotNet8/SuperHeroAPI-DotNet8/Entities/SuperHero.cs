//Also known as models
//It represents a table in your database
//Entity Framework uses it to automatically create and manage database tables
//When you use EF Core, you work with C# objects instead of SQL directly.
//EF will translate these objects into database tables and manage data for you.


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroAPI_DotNet8.Entities
{
    public class SuperHero
    {
        [Key]//tells EF that Id is the Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// Sql server will automatically increment the ID
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
