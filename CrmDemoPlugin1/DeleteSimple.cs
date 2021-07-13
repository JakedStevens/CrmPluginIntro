using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmDemoPlugin1
{
	class DeleteSimple
	{
		public static void DeleteAccount(IOrganizationService svc, Guid accountGuid)
		{
			Console.WriteLine("Deleting Account...");
			svc.Delete("account", accountGuid);
			Console.WriteLine($"Simple Account Delete: {accountGuid}");
		}
	}
}
