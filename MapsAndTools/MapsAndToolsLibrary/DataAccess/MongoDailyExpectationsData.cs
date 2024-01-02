namespace MapsAndToolsLibrary.DataAccess;

public class MongoDailyExpectationsData : IDailyExpectationsData
{
	private readonly IMongoCollection<DailyExpectationModel> _expectations;
	private readonly IMemoryCache _cache;
	private const string CacheName = "ExpectationsData";

	public MongoDailyExpectationsData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_expectations = db.DailyExpectationCollection;
	}

	public async Task<List<DailyExpectationModel>> GetAllExpectations()
	{
		var output = _cache.Get<List<DailyExpectationModel>>(CacheName);
		if (output is null)
		{
			var results = await _expectations.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output);
		}

		return output;
	}

	public async Task<DailyExpectationModel> GetExpectation(string id)
	{
		var results = await _expectations.FindAsync(e => e.Id == id);
		return results.FirstOrDefault();
	}

	public Task CreateExpectation(DailyExpectationModel expectation)
	{
		return _expectations.InsertOneAsync(expectation);
	}

	public Task UpdateExpectation(DailyExpectationModel expectation)
	{
		var filter = Builders<DailyExpectationModel>.Filter.Eq("Id", expectation.Id);
		return _expectations.ReplaceOneAsync(filter, expectation, new ReplaceOptions { IsUpsert = true });
	}

	public Task DeleteExpectation(string id)
	{
		var filter = Builders<DailyExpectationModel>.Filter.Eq(e => e.Id, id);
		return _expectations.DeleteOneAsync(filter);
	}
}
