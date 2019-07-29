using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlBuilder
{
    public class SelectBuilder
    {
        #region Private fields
        private StringBuilder sqlBuilder;
        private StringBuilder sqlWhere;
        private StringBuilder sqlOrderBy;
        #endregion

        #region Properties
        public string SelectStatement
        {
            get
            {
                return this.GetSelectStatement();
            }
        }
        #endregion

        #region Constructors
        public SelectBuilder() : this(string.Empty)
        {
        }

        public SelectBuilder(string sqlStatement)
        {
            sqlBuilder = new StringBuilder(sqlStatement);
            sqlWhere = new StringBuilder();
            sqlOrderBy = new StringBuilder();
        }
        #endregion

        public void AddCondition(string condition)
        {
            if (sqlWhere.Length > 0)
            {
                sqlWhere.AppendLine();
                sqlWhere.Append("   and ");
            }

            sqlWhere.Append(condition);
        }
        
        public void AddCondition(TextBox textBox, string condition)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                this.AddCondition(condition);
            }
        }

        public void AddCondition(CheckBox checkBox, string condition)
        {
            if (checkBox.Checked)
            {
                this.AddCondition(condition);
            }
        }

        public void AddOrderBy(string orderBy)
        {
            if (sqlOrderBy.Length > 0)
            {
                sqlOrderBy.Append(", ");
            }

            sqlOrderBy.Append(orderBy);
        }

        private string GetSelectStatement()
        {
            StringBuilder selectStatement = new StringBuilder(sqlBuilder.ToString());

            if (sqlWhere.Length > 0)
            {
                selectStatement.AppendLine();
                selectStatement.Append(" where ");
                selectStatement.Append(sqlWhere.ToString());
            }

            if (sqlOrderBy.Length > 0)
            {
                selectStatement.AppendLine();
                selectStatement.Append(" order by ");
                selectStatement.Append(sqlOrderBy.ToString());
            }

            return selectStatement.ToString();
        }

        public override string ToString()
        {
            return GetSelectStatement();
        }
    }
}
