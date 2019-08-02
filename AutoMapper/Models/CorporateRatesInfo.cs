using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Models
{
    public class CorporateRatesInfo
    {
        [Key]
        public string Conum { get; set; }
        public string Name { get; set; }
        public string AgencyName { get; set; }
        public List<SaaCode> SaaCodes { get; set; }
    }
}
