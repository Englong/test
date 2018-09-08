using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_Data_Entry
{
    //Step 2
    public class Person
    {
        public virtual string Type { get { return "Person"; } }
        public virtual string Information {
            get
            {
                return string.Format("{0}={1}; {2}={3}",
                             Person.FIELD_NAME, this.name, Person.FIELD_AGE, this.age );
            }
        }
        public string CurrentText
        {
            get { return string.Format("Current {0}", this.Type); }
        }
        public virtual List<FieldData> DataList
        {
            get
            {
                List<FieldData> result = new List<FieldData>();
                result.Add(new FieldData(Person.FIELD_NAME, this.name));
                result.Add(new FieldData(Person.FIELD_AGE , this.age));
                return result;
            }
        }
        public virtual void SetData(List<FieldData> datalist)
        {
            if (datalist == null) return;
            foreach (FieldData fd in datalist)
            {
                try
                {
                    if (Person.FIELD_NAME.Equals(fd.Field)) this.name = fd.Data as string;
                    if (Person.FIELD_AGE.Equals(fd.Field)) this.age = Convert.ToInt32(fd.Data);
                }
                catch (Exception) { }
            }
        }
       
        public Person() { }
        public Person(string n, int a) { this.name = n; this.age = a;  }
        public const string FIELD_NAME = "NAME";
        public const string FIELD_AGE = "AGE";
        protected string name;
        protected int age;
    }
}
