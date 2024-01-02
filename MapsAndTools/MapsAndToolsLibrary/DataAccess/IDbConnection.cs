using MongoDB.Driver;

namespace MapsAndToolsLibrary.DataAccess;
public interface IDbConnection
{
	IMongoCollection<CallFlowModel> CallFlowCollection { get; }
	string CallFlowCollectionName { get; }
	MongoClient Client { get; }
	IMongoCollection<DailyExpectationModel> DailyExpectationCollection { get; }
	string DailyExpectationCollectionName { get; }
	string DbName { get; }
	IMongoCollection<FdcModel> FdcCollection { get; }
	string FdcCollectionName { get; }
	IMongoCollection<KbArticleModel> KbArticleCollection { get; }
	string KbCollectionName { get; }
	IMongoCollection<TemplateModel> TemplateCollection { get; }
	string TemplateCollectionName { get; }
}