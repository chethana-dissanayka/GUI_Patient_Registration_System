using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_01
{
    public class Patient
    {

        [Key]
        public int Patient_Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? DOB { get; set; }
        public string? Doctor { get; set; }
        public string? Age { get; set; }
        public string? Address { get; set; }
        public string? NIC_Number { get; set; }
        public string Gender { get; set; }
    }
  }
