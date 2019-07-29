using SqlBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlBuilderTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonGetSqlStatement_Click(object sender, EventArgs e)
        {
            SelectBuilder selectBuilder = new SelectBuilder(@"select * from table");

            selectBuilder.AddCondition("column1 = :column1");

            selectBuilder.AddCondition(textBox1, "column2 = :column2");
            selectBuilder.AddCondition(textBox2, "column3 = :column3");

            selectBuilder.AddCondition(checkBox1, "column4 = :column4");
            selectBuilder.AddCondition(checkBox2, "column5 = :column5");

            selectBuilder.AddOrderBy("column1, column2");

            textBoxSqlStatement.Text = selectBuilder.SelectStatement;
        }
    }
}
