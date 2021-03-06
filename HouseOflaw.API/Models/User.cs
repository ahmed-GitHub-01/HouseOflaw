using System;
using System.Collections.Generic;

namespace HouseOflaw.API.Models
{
    public class User
    {
        public int ID { get; set; }

        public double Code { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHashed { get; set; }

        public string Name_Ar { get; set; }

        public DateTime DateEntry { get; set; }

        public string Department { get; set; }

        public int IsVoke { get; set; }

        public int Switch { get; set; }

        public string Response { get; set; }

        public double Acc_Code { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<Roule> Roules { get; set; }
    }
}
