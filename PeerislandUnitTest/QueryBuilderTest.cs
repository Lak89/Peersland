using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeerislandsTest.Builder;
using PeerislandsTest.Contracts;
using PeerislandsTest.Modules;
using System.Collections.Generic;
using Xunit;

namespace PeerislandUnitTest
{
    public class QueryBuilderTest
    {
        private readonly Mock<IMessageService> _mockIMessageService;
        private readonly Mock<IQueryGenerator> _mockIQueryGenerator;

        [Fact]
        public void ShouldGenerateQuery()
        {
            var columnlist = new List<Column>()
            {
                new Column(){ FieldName="Name", FieldValue="'Lakshman'",Operator="="},
                new Column(){FieldName="Age", FieldValue="30",Operator=">"}
            };
           var queryBuilder = new QueryBuilder(_mockIMessageService.Object, _mockIQueryGenerator.Object);
           var query=   queryBuilder.Select("ID,Name,Age").FromTable("Employee").Where(columnlist).GenerateQuery();
            Assert.AreEqual("Select ID,Name,Age From Employee Where Name= 'Lakshman' AND Age> 30", query);
        }
    }
}
