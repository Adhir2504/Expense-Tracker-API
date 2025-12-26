/*
 * They protect sensitive data (you might not want to expose internal IDs).

   *They simplify what the client receives.

    *They make it easier to validate input separately from database logic.
*/


namespace StudentManagementAPI.DTOs
{
    public class StudentDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Course { get; set; } = string.Empty;
    }
}
