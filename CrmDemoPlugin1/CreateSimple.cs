using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmDemoPlugin1
{
	class CreateSimple
	{

		public static Guid CreateEntityLateBound(IOrganizationService svc)
		{
			//Use Entity class with entity logical name
			var account = new Entity("account");

			//set attribute values
			//string primary name
			account["name"] = "Bootcamp Account";

			//telephone1
			account["telephone1"] = "330-555-1234";

			//websiteurl
			account["websiteurl"] = "www.CrmBootcamp.org";

			//Boolean (Two Option)
			account["creditonhold"] = false;

			//Datetime
			account["lastonholdtime"] = new DateTime(2021, 1, 1);

			//Double
			account["address1_latitude"] = 47.642311;
			account["address1_longitude"] = -122.136841;

			//Int
			account["numberofemployees"] = 500;

			//Money
			account["revenue"] = new Money(new decimal(5000000.00));

			//Picklist (Option Set)
			account["accountcategorycode"] = new OptionSetValue(1); //Preferred Customer

			//Create the account
			Guid accountid = svc.Create(account);
			return accountid;
		}

	}
}
