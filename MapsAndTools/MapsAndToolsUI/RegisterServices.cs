namespace MapsAndToolsUI;

public static class RegisterServices
{
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();
		builder.Services.AddMemoryCache();

		builder.Services.AddSingleton<IDbConnection, DbConnection>();
		builder.Services.AddSingleton<ICallFlowData, MongoCallFlowData>();
		builder.Services.AddSingleton<IFdcData, MongoFdcData>();
		builder.Services.AddSingleton<ITemplateData, MongoTemplateData>();
		builder.Services.AddSingleton<IKbArticleData, MongoKbArticleData>();
		builder.Services.AddSingleton<IDailyExpectationsData, MongoDailyExpectationsData>();
	}
}
