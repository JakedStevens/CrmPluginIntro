using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmDemoPlugin1
{
	class UpdateAdvanced
	{
		public static Entity RetrieveAccountWithRelationships(IOrganizationService svc, Guid accountid)
		{
			var relationshipQueryCollection = new RelationshipQueryCollection();

			var relatedTasks = new QueryExpression("task");
			relatedTasks.ColumnSet = new ColumnSet("subject", "description");
			var taskRelationship = new Relationship("Account_Tasks");
			relationshipQueryCollection.Add(taskRelationship, relatedTasks);


			var relatedContacts = new QueryExpression("contact");
			relatedContacts.ColumnSet = new ColumnSet("fullname", "emailaddress1");
			var contactRelationship = new Relationship("account_primary_contact");
			relationshipQueryCollection.Add(contactRelationship, relatedContacts);

			var request = new RetrieveRequest()
			{
				ColumnSet = new ColumnSet(true),
				RelatedEntitiesQuery = relationshipQueryCollection,
				Target = new EntityReference("account", accountid)
			};

			RetrieveResponse response = (RetrieveResponse)svc.Execute(request);
			Entity retrievedAccount = response.Entity;

			return retrievedAccount;
		}

		public static void UpdateAccountAndTasksLateBound(IOrganizationService svc, Guid retrievedAccountGuid)
		{
			Console.WriteLine("Retrieving account...");
			var retrievedAccount = RetrieveAccountWithRelationships(svc, retrievedAccountGuid);

			var updatedAccount = new Entity("account");
			updatedAccount.Id = retrievedAccount.Id;

			//Define relationships
			var primaryContactRelationship = new Relationship("account_primary_contact");
			var AccountTasksRelationship = new Relationship("Account_Tasks");

			//Update the account name
			updatedAccount["name"] = "Bootcamp Updated Account Name";

			//Update the email address for the primary contact of the account
			var contact = new Entity("contact");

			contact.Id = retrievedAccount.RelatedEntities[primaryContactRelationship].Entities.FirstOrDefault().Id;
			contact["emailaddress1"] = "someone_a@example.com";

			List<Entity> primaryContacts = new List<Entity>();
			primaryContacts.Add(contact);
			updatedAccount.RelatedEntities.Add(primaryContactRelationship, new EntityCollection(primaryContacts));

			//Find related Tasks that need to be updated
			List<Entity> tasksToUpdate = retrievedAccount.RelatedEntities[AccountTasksRelationship].Entities
				.Where(t => t["subject"].ToString().Contains("Task")).ToList();

			//A list to put the updated tasks
			List<Entity> updatedTasks = new List<Entity>();

			//Fill the list of updated tasks based on the tasks that need to be updated
			tasksToUpdate.ForEach(t =>
			{
				var updatedTask = new Entity("task");
				updatedTask.Id = t.Id;
				updatedTask["subject"] = "Updated Subject";

				updatedTasks.Add(updatedTask);
			});

			//Set the updated tasks to the collection
			updatedAccount.RelatedEntities.Add(AccountTasksRelationship, new EntityCollection(updatedTasks));

			//Update the account and related contact and tasks
			svc.Update(updatedAccount);
			Console.WriteLine($"Advanced Account Update: {retrievedAccount.Id}");
		}
	}
}
