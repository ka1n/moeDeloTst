﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moeDeloTst.Models
{
    public class Individual : BaseContragent
    {
        [Display(Name = "Фамилия")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
    }
}
