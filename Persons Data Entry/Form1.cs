using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Persons_Data_Entry
{
    //Step 3 (including designing UI)
    public partial class Form1 : Form
    {
        private BindingSource perbs = new BindingSource();
        private BindingSource databs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            perbs.DataSource = typeof(Person);
            this.InitPersons();

            dgvPers.DataSource = perbs;
            dgvPers.Columns["CurrentText"].Visible = false;
            groupBox1.DataBindings.Add("Text", perbs, "CurrentText");

            databs.DataSource = perbs;
            databs.DataMember = "DataList";
            dgvData.DataSource = databs;
            dgvData.Columns["Field"].ReadOnly = true;

            btnUpdate.Click += new System.EventHandler(this.DoClickUpdate);
        }

        private void DoClickUpdate(object sender, EventArgs e)
        {
            if (perbs.Current == null) return;
            Person p = perbs.Current as Person;
            if (databs.Current == null) return;
            List<FieldData> data = databs.List  as List<FieldData>;
            p.SetData(data);
            perbs.ResetBindings(false);

        }
        private void InitPersons()
        {
            perbs.Add(new Person("Sok Dara", 28));
            perbs.Add(new Person("Leng Map", 22));

            //Inserting this lines after step 4 (creating class Student)
            perbs.Insert(1, new Student("Heng Meta", 23, 100));
            perbs.Add(new Student("Heng Kakada", 18, 60));

            //Inserting this lines after Step 5 (creting class Worker)
            perbs.Insert(2, new Worker("Um Neary", 35, 400, "ALIM.Co LTD"));
            perbs.Insert(3, new Worker("San Phanny", 27, 500, "KMS Ratical"));
           
        }
    }
}
