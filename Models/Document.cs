using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moeDeloTst.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int IdContragent { get; set; }
        [Display(Name = "Номер документа")]
        public string DocNumber { get; set; }
        [Display(Name = "Название документа")]
        public string DocName { get; set; }
    }
}
