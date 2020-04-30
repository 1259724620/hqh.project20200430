using System.ComponentModel.DataAnnotations;

namespace hqh.project.Dtos
{
    public class AddEditUserDto: IntEntityDto
    {
        [Required]
        public string Account { get; set; }

        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
