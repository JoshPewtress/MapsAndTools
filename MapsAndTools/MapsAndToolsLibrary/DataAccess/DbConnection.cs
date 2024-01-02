using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Data;

namespace MapsAndToolsLibrary.DataAccess;

public class DbConnection : IDbConnection
{
	private readonly IConfiguration _config;
	private readonly IMongoDatabase _db;
	private string _connectionId = "MongoDB";
	public string DbName { get; private set; }
	public string CallFlowCollectionName { get; private set; } = "callflows";
	public string FdcCollectionName { get; private set; } = "fdcs";
	public string TemplateCollectionName { get; private set; } = "templates";
	public string KbCollectionName { get; private set; } = "kbs";
	public string DailyExpectationCollectionName { get; private set; } = "expectations";

	public MongoClient Client { get; private set; }
	public IMongoCollection<CallFlowModel> CallFlowCollection { get; private set; }
	public IMongoCollection<FdcModel> FdcCollection { get; private set; }
	public IMongoCollection<TemplateModel> TemplateCollection { get; private set; }
	public IMongoCollection<KbArticleModel> KbArticleCollection { get; private set; }
	public IMongoCollection<DailyExpectationModel> DailyExpectationCollection { get; private set; }

	public DbConnection(IConfiguration config)
	{
		_config = config;
		Client = new MongoClient(_config.GetConnectionString(_connectionId));
		DbName = _config["DatabaseName"];
		_db = Client.GetDatabase(DbName);

		CallFlowCollection = _db.GetCollection<CallFlowModel>(CallFlowCollectionName);
		FdcCollection = _db.GetCollection<FdcModel>(FdcCollectionName);
		TemplateCollection = _db.GetCollection<TemplateModel>(TemplateCollectionName);
		KbArticleCollection = _db.GetCollection<KbArticleModel>(KbCollectionName);
		DailyExpectationCollection = _db.GetCollection<DailyExpectationModel>(DailyExpectationCollectionName);
	}
}
