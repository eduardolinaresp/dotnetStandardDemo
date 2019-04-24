using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCampusApp.Dto
{
    public class DataTablesInfo
    {

        public string draw { get; set; }
        public string recordsTotal { get; set; }
        public string recordsFiltered { get; set; }
        public List<user> data { get; set; }

        public object[] queries{ get; set; }

        public object[] input { get; set; }
    }

    
}
