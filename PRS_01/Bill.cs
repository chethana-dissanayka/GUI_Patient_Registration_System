using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_01
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Add_Date { get; set; }
        public string? Dis_Date { get; set; }
        public float Total { get; set; }
        public float Service_Charge { get; set; }
        public int  No_Days { get; set; }
        public float Doctor_Charge { get; set; }
       
       
    }
}
