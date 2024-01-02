using MongoDB.Driver;

namespace MongoTesting
{
	public interface IDbConnection
	{
		MongoClient Client { get; }
		string? DbName { get; }
	}
}