using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmDemoPlugin1
{
	class CreateAdvanced
	{
		public static Guid AdvancedCreateEntityLateBound(IOrganizationService svc)
		{
			//Use Entity class with entity logical name
			var account = new Entity("account");

			//Set attribute values
			//string primary name
			account["name"] = "Bootcamp Account with Tasks";

			//Create Primary Contact
			var primaryContact = new Entity("contact");
			primaryContact["firstname"] = "John";
			primaryContact["lastname"] = "Smith";

			//Add the contact to an EntityCollection
			EntityCollection primaryContactCollection = new EntityCollection();
			primaryContactCollection.Entities.Add(primaryContact);

			//Set the value to the relationship
			account.RelatedEntities[new Relationship("account_primary_contact")] = primaryContactCollection;

			//Add related tasks to create
			var taskList = new List<Entity>()
			{
				new Entity("task") { ["subject"] = "Task 1" },
				new Entity("task") { ["subject"] = "Task 2" },
				new Entity("task") { ["subject"] = "Task 3" },
			};

			//Add the tasks to an EntityCollection
			EntityCollection tasks = new EntityCollection(taskList);

			//Set the value to the relationship
			account.RelatedEntities[new Relationship("Account_Tasks")] = tasks;

			//Create the account
			Guid accountid = svc.Create(account);
			return accountid;
		}
	}
}
