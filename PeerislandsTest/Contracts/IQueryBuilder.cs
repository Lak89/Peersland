using PeerislandsTest.Builder;
using PeerislandsTest.Modules;
using System.Collections.Generic;

namespace PeerislandsTest.Contracts
{
    public interface IQueryBuilder
    {   
        /// <summary>
        /// Select comma separated columns
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        ISelect Select(string commaseparatedcolumns);
    }

    public interface ISelect
    {
        /// <summary>
        /// Table name need to be provided
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        IFromTable FromTable(string tablename);
    }

    public interface IFromTable
    {
        /// <summary>
        /// Where clause with list columns as parm from json file
        /// </summary>
        /// <param name="columnlist"></param>
        /// <returns></returns>
        IWhere Where(List<Column> columnlist);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IWhere Where(string filter);
        /// <summary>
        /// Its used join two table
        /// </summary>
        /// <param name="jointype"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        IJoin Join(string jointype, string tablename);

        /// <summary>
        /// its used to group by 
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        IFromTable GroupBy(string commaseparatedcolumns);

        /// <summary>
        /// its used order by
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        IFromTable OrderBy(string commaseparatedcolumns);

        /// <summary>
        /// its having clause in Sql
        /// </summary>
        /// <param name="commaseparatedcolumns"></param>
        /// <returns></returns>
        IFromTable Having();

        /// <summary>
        /// This method generate SQL Query
        /// </summary>
        string GenerateQuery();
    }

    public interface IWhere
    {
        IWhere LessThen(string columnname, string fieldvalue);
        IWhere GreaterThen(string column, string fieldvalue);
        IWhere EqualsTo(string column, string fieldvalue);
        IWhere NotEqualsTo(string column, string fieldvalue);
        IWhere In(string subquery);
        IWhere Between(string column, string fieldvalue1, string fieldvalue2);
        IWhere And();
        IWhere Or();
        string GenerateQuery();
    }

    public interface IJoin
    {   
        /// <summary>
        /// its used add on condition after join table
        /// </summary>
        /// <param name="firsttablecolumn"></param>
        /// <param name="secondtablecolumn"></param>
        /// <returns></returns>
        IOn On(string firsttablecolumn, string secondtablecolumn);
    }

    public interface IOn : IWhere
    {

    }
}
