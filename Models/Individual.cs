using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moeDeloTst.Models
{
    public class Individual : BaseContragent
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string Patronymic { get; set; }
    }
}
