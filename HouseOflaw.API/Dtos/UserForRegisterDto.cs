using System;
using System.ComponentModel.DataAnnotations;

namespace HouseOflaw.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public double Code { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name_Ar { get; set; }
        [Required]
        public DateTime DateEntry { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int IsVoke { get; set; }
        [Required]
        public int Switch { get; set; }
        [Required]
        public string Response { get; set; }
        [Required]
        public double Acc_Code { get; set; }
    }
}