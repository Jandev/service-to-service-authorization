using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Sample.Partner.Dotnet.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{
		[HttpGet]
		public async Task<string> Get()
		{
			const string clientId = "<The Client Id of the Partner App Registration>";
			const string clientSecret = "<The Client Secret created for the Partner App Registration>";
			const string authority = "https://login.microsoftonline.com/<The tenant id where the applications are deployed to>";
			
			var scopes = new[] { "<The App ID URI of the DMM for Manufacturing solution>/.default" };

			const string dmmEndpoint = "<The endpoint of DMM for Manufacturing that needs to be invoked.>";

			var app = ConfidentialClientApplicationBuilder.Create(clientId)
				.WithClientSecret(clientSecret)
				.WithAuthority(authority)
				.Build();
			
			var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
			var accessToken = result.AccessToken;

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
			try
			{
				string json = await client.GetStringAsync(dmmEndpoint);

				return json;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}
