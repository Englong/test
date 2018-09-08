using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_Data_Entry
{
   //Step 1
    public  class FieldData
    {
       public string Field { get; set;  }
       public object Data { get; set;  }
       public FieldData(string f, object d)
       {
           this.Field = f;
           this.Data = d;
       }
    }
}
