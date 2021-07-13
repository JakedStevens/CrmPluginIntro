using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmDemoPlugin1
{
	class QueryData
	{
		private object svc;

		public void QueryTheData()
		{
			//string fetchXml = @"
			//                <fetch top='50' >
			//                  <entity name='account' >
			//                    <attribute name='name' />
			//                    <filter>
			//                      <condition 
			//                        attribute='address1_city' 
			//                        operator='eq' 
			//                        value='Redmond' />
			//                    </filter>
			//                    <order attribute='name' />
			//                  </entity>
			//                </fetch>";

			//var query = new FetchExpression(fetchXml);

			//EntityCollection results = svc.RetrieveMultiple(query);

			//results.Entities.ToList().ForEach(x =>
			//{
			//	Console.WriteLine(x.Attributes["name"]);
			//});


			//var queryExpression = new QueryExpression("account")
			//{
			//	ColumnSet = new ColumnSet("name"),
			//	Criteria = new FilterExpression(LogicalOperator.And),
			//	TopCount = 50
			//};

			//queryExpression.Criteria.AddCondition("address1_city", ConditionOperator.Equal,
			//				"Redmond");
			//queryExpression.AddOrder("name", OrderType.Ascending);
			//EntityCollection queryExpressionResults = svc.RetrieveMultiple(queryExpression);

			//Console.WriteLine("\nOutput from QueryExpression: ");
			//queryExpressionResults.Entities.ToList().ForEach(x =>
			//{
			//	Console.WriteLine(x.Attributes["name"]);
			//});

		}
	}
}
