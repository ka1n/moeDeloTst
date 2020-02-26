using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moeDeloTst.Models
{
    public class Organization : BaseContragent
    {
        [Display(Name = "Наимененование организации")]
        public string Name { get; set; }
        [Display(Name = "Адрес регистрации")]
        public string Address { get; set; }
    }
}
