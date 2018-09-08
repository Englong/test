using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_Data_Entry
{
    //Step 5
    public class Worker:Person 
    {
        public const string FIELD_SALARY = "SALARY";
        public const string FIELD_FACTORY = "FACTORY";

        protected double salary;
        protected string factory;
        public Worker() { }
        public Worker(string n, int a, double s, string f) : base(n, a) { this.salary = s; this.factory = f; }
        public override string Type
        {
            get
            {
                return "Worker";
            }
        }
        public override string Information
        {
            get
            {
                return string.Format("{0}={1}; {2}={3}; {4}={5:C2}; {6}={7}",
                             Worker.FIELD_NAME, this.name,
                             Worker.FIELD_AGE, this.age,
                             Worker.FIELD_SALARY, this.salary,
                             Worker.FIELD_FACTORY, this.factory  
                             );
            }
        }
        public override List<FieldData> DataList
        {
            get
            {
                List<FieldData> result = new List<FieldData>();
                result.Add(new FieldData(Worker.FIELD_NAME, this.name));
                result.Add(new FieldData(Worker.FIELD_AGE, this.age));
                result.Add(new FieldData(Worker.FIELD_SALARY, this.salary ));
                result.Add(new FieldData(Worker.FIELD_FACTORY, this.factory));
                return result;
            }
        }
        public override void SetData(List<FieldData> datalist)
        {
            if (datalist == null) return;
            foreach (FieldData fd in datalist)
            {
                try
                {
                    if (Worker.FIELD_NAME.Equals(fd.Field)) this.name = fd.Data as string;
                    if (Worker.FIELD_AGE.Equals(fd.Field)) this.age = Convert.ToInt32(fd.Data);
                    if (Worker.FIELD_SALARY.Equals(fd.Field)) this.salary = Convert.ToDouble(fd.Data);
                    if (Worker.FIELD_FACTORY.Equals(fd.Field)) this.factory = Convert.ToString(fd.Data);
                }
                catch (Exception) { }
            }
        }
    }
}
