namespace MapsAndToolsLibrary.DataAccess;

public class MongoFdcData : IFdcData
{
	private readonly IMongoCollection<FdcModel> _fdcs;
	private readonly IMemoryCache _cache;
	private const string CacheName = "FdcsData";

	public MongoFdcData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_fdcs = db.FdcCollection;
	}

	public async Task<List<FdcModel>> GetAllFdcs()
	{
		var output = _cache.Get<List<FdcModel>>(CacheName);
		if (output is null)
		{
			var results = await _fdcs.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output, TimeSpan.FromDays(1));
		}

		return output;
	}

	public async Task<FdcModel> GetFdc(string id)
	{
		var results = await _fdcs.FindAsync(f => f.Id == id);
		return results.FirstOrDefault();
	}

	public Task CreateFdc(FdcModel fdc)
	{
		return _fdcs.InsertOneAsync(fdc);
	}

	public Task UpdateFdc(FdcModel fdc)
	{
		var filter = Builders<FdcModel>.Filter.Eq("Id", fdc.Id);
		return _fdcs.ReplaceOneAsync(filter, fdc, new ReplaceOptions { IsUpsert = true });
	}

	public Task DeleteFdc(string id)
	{
		var filter = Builders<FdcModel>.Filter.Eq("Id", id);
		return _fdcs.DeleteOneAsync(filter);
	}
}
