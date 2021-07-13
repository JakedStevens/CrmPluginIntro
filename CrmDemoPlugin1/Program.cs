using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;

namespace CrmDemoPlugin1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Connecting...");
			string url = "https://org406e3622.crm.dynamics.com";
			string userName = "admin@CRM530419.onmicrosoft.com";
			string password = "K0m0dC2KxA";

			string conn = $@"
						Url = {url};
						AuthType = OAuth;
						UserName = {userName};
						Password = {password};
						AppId = 51f81489-12ee-4a9e-aaae-a2591f45987d;
						RedirectUri = app://58145B91-0C36-4500-8554-080854F2AC97;
						LoginPrompt = Auto;
						RequireNewInstance = True";
			using (var svc = new CrmServiceClient(conn))
			{
				WhoAmIRequest request = new WhoAmIRequest();
				WhoAmIResponse response = (WhoAmIResponse)svc.Execute(request);
				Console.WriteLine("Your UserId is {0}", response.UserId);

				// Simple
				Guid accountid = CreateSimple.CreateEntityLateBound(svc);
				Console.WriteLine($"Simple Account Create: {accountid}");
				UpdateSimple.UpdateAccount(svc, accountid);
				DeleteSimple.DeleteAccount(svc, accountid);

				// Advanced
				Console.WriteLine("Creating account through advanced process");
				Guid advancedAccId = CreateAdvanced.AdvancedCreateEntityLateBound(svc);
				Console.WriteLine($"Advanced Account Create: {advancedAccId}");
				UpdateAdvanced.UpdateAccountAndTasksLateBound(svc, advancedAccId);

				Console.WriteLine("Press any key to exit.");
				Console.ReadLine();
			}

		}
	}
}
