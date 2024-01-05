using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace MapsAndToolsUI;

public static class RegisterServices
{
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
		builder.Services.AddMemoryCache();
		builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

		builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
			.AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

		builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("TeamMember", policy =>
			{
				policy.RequireClaim("jobTitle", "TeamMember");
			});
		});
		builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("Admin", policy =>
			{
				policy.RequireClaim("jobTitle", "Admin");
			});
		});

		builder.Services.AddSingleton<IDbConnection, DbConnection>();
		builder.Services.AddSingleton<ICallFlowData, MongoCallFlowData>();
		builder.Services.AddSingleton<IFdcData, MongoFdcData>();
		builder.Services.AddSingleton<ITemplateData, MongoTemplateData>();
		builder.Services.AddSingleton<IKbArticleData, MongoKbArticleData>();
		builder.Services.AddSingleton<IDailyExpectationsData, MongoDailyExpectationsData>();
	}
}
