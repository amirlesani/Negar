using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace negar
{
   public class  Result
    {

        public IQueryable<DaftarTable> query {get; set;}
        public int queryPageNumber { get; set; }
        public int recordCount { get; set; }


}
}
