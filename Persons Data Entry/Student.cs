using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_Data_Entry
{
    //Step 4
    public class Student:Person
    {
        public const string FIELD_SCORE = "SCORE";
        protected double score;
        public Student() { }
        public Student(string n, int a, double s) : base(n, a) { this.score = s;  }

        public override string Type
        {
            get
            {
                return "Student";
            }
        }
        public override string Information
        {
            get
            {
                return string.Format("{0}={1}; {2}={3}; {4}={5}",
                             Student.FIELD_NAME, this.name, 
                             Student.FIELD_AGE, this.age,
                             Student.FIELD_SCORE, this.score 
                             );
            }
        }
        public override List<FieldData> DataList
        {
            get
            {
                List<FieldData> result = new List<FieldData>();
                result.Add(new FieldData(Student.FIELD_NAME, this.name));
                result.Add(new FieldData(Student.FIELD_AGE, this.age));
                result.Add(new FieldData(Student.FIELD_SCORE, this.score));
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
                    if (Student.FIELD_NAME.Equals(fd.Field)) this.name = fd.Data as string;
                    if (Student.FIELD_AGE.Equals(fd.Field)) this.age = Convert.ToInt32(fd.Data);
                    if (Student.FIELD_SCORE.Equals(fd.Field)) this.score = Convert.ToDouble(fd.Data);
                }
                catch (Exception) { }
            }
        }
    }
}
