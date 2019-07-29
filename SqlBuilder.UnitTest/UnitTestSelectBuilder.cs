using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlBuilder.UnitTest
{
    [TestClass]
    public class UnitTestSelectBuilder
    {
        [TestMethod]
        public void EmptyConstructor()
        {
            SelectBuilder select = new SelectBuilder();

            Assert.AreEqual(select.SelectStatement, string.Empty);
        }

        [TestMethod]
        public void NotEmptyConstructor()
        {
            string sqlTest = "select * from table";

            SelectBuilder select = new SelectBuilder(sqlTest);

            Assert.AreEqual(select.SelectStatement, sqlTest);
        }

        [TestMethod]
        public void EmptyWhere()
        {
            string sqlTest = "select * from table";

            SelectBuilder select = new SelectBuilder(sqlTest);

            Assert.IsFalse(select.SelectStatement.Contains("where"));
        }

        [TestMethod]
        public void WhereWithOneColumn()
        {
            string sqlTest = "select * from table";

            SelectBuilder select = new SelectBuilder(sqlTest);
            select.AddCondition("column1 = :column1");

            Assert.IsTrue(select.SelectStatement.Contains("where"));
            Assert.IsTrue(select.SelectStatement.Contains("column1 = :column1"));
        }

        [TestMethod]
        public void WhereWithMoreColumns()
        {
            string sqlTest = "select * from table";

            SelectBuilder select = new SelectBuilder(sqlTest);
            select.AddCondition("column1 = :column1");
            select.AddCondition("column2 = :column2");

            Assert.IsTrue(select.SelectStatement.Contains("where"));
            Assert.IsTrue(select.SelectStatement.Contains("column1 = :column1"));
            Assert.IsTrue(select.SelectStatement.Contains("and column2 = :column2"));
        }

        [TestMethod]
        public void EmptyOrderBy()
        {
            string sqlTest = "select * from table";

            SelectBuilder select = new SelectBuilder(sqlTest);

            Assert.IsFalse(select.SelectStatement.Contains("order by"));
        }

        [TestMethod]
        public void OrderByWithOneColumn()
        {
            string sqlTest = "select * from table";

            SelectBuilder select = new SelectBuilder(sqlTest);
            select.AddOrderBy("column1");

            Assert.IsTrue(select.SelectStatement.Contains("order by"));
            Assert.IsTrue(select.SelectStatement.EndsWith("order by column1"));
        }

        [TestMethod]
        public void OrderByWithMoreColumns()
        {
            string sqlTest = "select * from table";

            SelectBuilder select = new SelectBuilder(sqlTest);
            select.AddOrderBy("column1");
            select.AddOrderBy("column2");

            Assert.IsTrue(select.SelectStatement.Contains("order by"));
            Assert.IsTrue(select.SelectStatement.EndsWith("order by column1, column2"));
        }
    }
}
