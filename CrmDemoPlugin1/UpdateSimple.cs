using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmDemoPlugin1
{
	class UpdateSimple
	{
		public static void UpdateAccount(IOrganizationService svc, Guid accountGuid)
		{
			Console.WriteLine("Updating Account...");
			var retrievedAccount = new Entity("account", accountGuid);
			retrievedAccount["telephone1"] = "216-911-0987";

			svc.Update(retrievedAccount);
			Console.WriteLine($"Simple Account Update: {retrievedAccount.Id}");
		}
	}
}
