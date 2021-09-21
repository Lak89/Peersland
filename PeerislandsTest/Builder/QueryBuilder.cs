using PeerislandsTest.Contracts;
using PeerislandsTest.Extension;
using PeerislandsTest.Modules;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerislandsTest.Builder
{
    public class QueryBuilder : IQueryBuilder, ISelect, IFromTable, IWhere, IJoin, IOn
    {
        private IQueryGenerator _queryGenerator;
        private IMessageService _mesageService;

        /// <summary>
        /// its buider class injected message service to display sql Query
        /// </summary>
        /// <param name="messageService"></param>
        public QueryBuilder(IMessageService messageService, IQueryGenerator queryGenerator)
        {
            _mesageService = messageService;
            _queryGenerator = queryGenerator;
             Reset();
        }


        /// <summary>
        /// Select comma separated columns
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        public ISelect Select(string commaseparatedcolumns)
        {
            _queryGenerator.Select = $" {commaseparatedcolumns} ";
            return this;
        }

        /// <summary>
        /// Table name need to be provided for Selection
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public IFromTable FromTable(string tablename)
        {
            _queryGenerator.FromTable = $"{tablename} ";
            return this;
        }

        /// <summary>
        /// Where clause with list columns as parm from json file
        /// </summary>
        /// <param name="columnlist"></param>
        /// <returns></returns>
        public IWhere Where(List<Column> columnlist)
        {
            _queryGenerator.Where = "Where "+string.Join(" AND ",columnlist.Select(col=>$"{col.FieldName}{col.Operator} {col.FieldValue}"));
            return this;
        }

        public IWhere Where(string filter)
        {
            _queryGenerator.Where =$" Where {filter} ";
            return this;
        }
        /// <summary>
        /// Its used join two table
        /// </summary>
        /// <param name="jointype"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public IJoin Join(string jointype, string tablename)
        {
            _queryGenerator.Join = $" {jointype} {tablename} ";
            return  this;
        }

        /// <summary>
        /// its used to group by 
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        public IFromTable GroupBy(string commaseparatedcolumns)
        {
            _queryGenerator.GroupBy = $" {commaseparatedcolumns} ";
            return this;
        }

        /// <summary>
        /// its used to order by
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        public IFromTable OrderBy(string commaseparatedcolumns)
        {
            _queryGenerator.OrderBy = $" {commaseparatedcolumns} ";
            return this;
        }

        /// <summary>
        /// its having clause in Sql
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        public IFromTable Having()
        {
            _queryGenerator.Having = $" having ";
            return this;
        }


        #region Where Clause extensions
        public IWhere LessThen(string columnname, string fieldvalue)
        {
            _queryGenerator.LessThen = $" {columnname} < {fieldvalue} ";
            return this;
        }

        public IWhere GreaterThen(string columnname, string fieldvalue)
        {
            _queryGenerator.GreaterThen = $" {columnname} > {fieldvalue} ";
            return this;
        }

        public IWhere EqualsTo(string column, string fieldvalue)
        {
            _queryGenerator.NotEqualsTo = $" {column} = {fieldvalue} ";
            return this;
        }

        public IWhere NotEqualsTo(string column, string fieldvalue)
        {
            _queryGenerator.NotEqualsTo = $" {column} <> {fieldvalue} ";
            return this;
        }

        public IWhere In(string subquery)
        {
            _queryGenerator.In = $" ({subquery})";
            return this;
        }

        public IWhere Between(string column, string fieldvalue1, string fieldvalue2)
        {
            _queryGenerator.Between = $" {column} BETWEEN {fieldvalue1} AND {fieldvalue2}; ";
            return this;
        }

        public IWhere And()
        {
            _queryGenerator.And = $" AND ";
            return this;
        }

        public IWhere Or ()
        {
            _queryGenerator.Or = $" OR ";
            return this;
        }

        #endregion

        /// <summary>
        /// its used add on condition after join table
        /// </summary>
        /// <param name="firsttablecolumn"></param>
        /// <param name="secondtablecolumn"></param>
        /// <returns></returns>
        public IOn On(string firsttablecolumn, string secondtablecolumn)
        {
            _queryGenerator.On = $" {firsttablecolumn} = {secondtablecolumn} ";
            return this;
        }

        /// <summary>
        /// This method generate SQL Query
        /// </summary>
        //public void GenerateQuery()
        //{
        //    StringBuilder query = new StringBuilder();
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.Select))
        //        query.Append($" Select {_queryGenerator.Select}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.FromTable))
        //        query.Append($" From {_queryGenerator.FromTable}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.Where))
        //        query.Append($" Where {_queryGenerator.Where}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.GroupBy))
        //        query.Append($" group by {_queryGenerator.GroupBy}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.OrderBy))
        //        query.Append($" order by {_queryGenerator.OrderBy}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.Having))
        //        query.Append($" having {_queryGenerator.Having}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.On))
        //        query.Append($" On {_queryGenerator.On}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.LessThen))
        //        query.Append($" {_queryGenerator.LessThen}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.GreaterThen))
        //        query.Append($" {_queryGenerator.GreaterThen}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.EqualsTo))
        //        query.Append($" {_queryGenerator.EqualsTo}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.NotEqualsTo))
        //        query.Append($" {_queryGenerator.NotEqualsTo}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.In))
        //        query.Append($" {_queryGenerator.In}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.Between))
        //        query.Append($" {_queryGenerator.Between}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.And))
        //        query.Append($" {_queryGenerator.And}");
        //    if (!string.IsNullOrWhiteSpace(_queryGenerator.Or))
        //        query.Append($" {_queryGenerator.Or}");
        //    _mesageService.ShowMessage(query.ToString());
        //    Reset();
        //}

        public string GenerateQuery()
        {
            var filter = $"{(!string.IsNullOrWhiteSpace(_queryGenerator.And) ? $" {_queryGenerator.And} " : " ")}" +
                         $"{(!string.IsNullOrWhiteSpace(_queryGenerator.Or) ? $" {_queryGenerator.Or} " : " ")}" +
                         $"{(!string.IsNullOrWhiteSpace(_queryGenerator.LessThen) ? $" {_queryGenerator.LessThen} " : " ")}" +
                         $"{(!string.IsNullOrWhiteSpace(_queryGenerator.GreaterThen) ? $" {_queryGenerator.GreaterThen} " : " ")}" +
                         $"{(!string.IsNullOrWhiteSpace(_queryGenerator.EqualsTo) ? $" {_queryGenerator.EqualsTo} " : " ")}" +
                         $"{(!string.IsNullOrWhiteSpace(_queryGenerator.NotEqualsTo) ? $" {_queryGenerator.NotEqualsTo} " : " ")}" +
                         $"{(!string.IsNullOrWhiteSpace(_queryGenerator.Between) ? $" {_queryGenerator.Between} " : " ")}"+
                         $"{(!string.IsNullOrWhiteSpace(_queryGenerator.In) ? $" In {_queryGenerator.In} " : " ")}";

            var query = $" Select {_queryGenerator.Select}" +
                        $" From { _queryGenerator.FromTable}" +
                        $" { _queryGenerator.Join}" +
                        $"{(!string.IsNullOrWhiteSpace(_queryGenerator.On) ? $" On {_queryGenerator.On} {filter}" : " ")}" +
                        $"{(!string.IsNullOrWhiteSpace(_queryGenerator.Where) ? $" {_queryGenerator.Where} {filter}" : " ")}" +
                        $"{(!string.IsNullOrWhiteSpace(_queryGenerator.GroupBy) ? $" group by {_queryGenerator.GroupBy}" : " ")}" +
                        $"{(!string.IsNullOrWhiteSpace(_queryGenerator.OrderBy) ? $" order by {_queryGenerator.OrderBy}" : " ")}" +
                        $"{(!string.IsNullOrWhiteSpace(_queryGenerator.Having) ? $" having {_queryGenerator.Having} {filter}" : " ")}";

            //StringBuilder query = new StringBuilder();
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.Select))
            //    query.Append($" Select {_queryGenerator.Select}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.FromTable))
            //    query.Append($" From {_queryGenerator.FromTable}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.Where))
            //    query.Append($" Where {_queryGenerator.Where}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.GroupBy))
            //    query.Append($" group by {_queryGenerator.GroupBy}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.OrderBy))
            //    query.Append($" order by {_queryGenerator.OrderBy}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.Having))
            //    query.Append($" having {_queryGenerator.Having}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.On))
            //    query.Append($" On {_queryGenerator.On}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.LessThen))
            //    query.Append($" {_queryGenerator.LessThen}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.GreaterThen))
            //    query.Append($" {_queryGenerator.GreaterThen}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.EqualsTo))
            //    query.Append($" {_queryGenerator.EqualsTo}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.NotEqualsTo))
            //    query.Append($" {_queryGenerator.NotEqualsTo}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.In))
            //    query.Append($" {_queryGenerator.In}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.Between))
            //    query.Append($" {_queryGenerator.Between}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.And))
            //    query.Append($" {_queryGenerator.And}");
            //if (!string.IsNullOrWhiteSpace(_queryGenerator.Or))
            //    query.Append($" {_queryGenerator.Or}");
          //  _mesageService.ShowMessage(query.ToString());
            Reset();
            return query.ReduceWhitespace();
        }

        public void Reset()
        {
            _queryGenerator = new QueryGenerator();
        }
    }
}
