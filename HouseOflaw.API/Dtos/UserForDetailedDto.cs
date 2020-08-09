using System;

namespace HouseOflaw.API.Dtos
{
    public class UserForDetailedDto
    {
                 public double Code { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name_Ar { get; set; }
        public DateTime DateEntry { get; set; }
        public string Department { get; set; }
        public int IsVoke { get; set; }
        public int Switch { get; set; }
        public string Response { get; set; }
        public double Acc_Code { get; set; }
         public string PhotoUrl { get; set; }

    }
}