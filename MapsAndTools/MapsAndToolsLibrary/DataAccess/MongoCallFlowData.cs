using MongoDB.Bson.Serialization;

namespace MapsAndToolsLibrary.DataAccess;

public class MongoCallFlowData : ICallFlowData
{
	private readonly IMongoCollection<CallFlowModel> _callFlows;
	private readonly IMemoryCache _cache;
	private const string CacheName = "CallFlowsData";

	public MongoCallFlowData(IDbConnection db, IMemoryCache cache)
	{
		_callFlows = db.CallFlowCollection;
		_cache = cache;
	}

	public async Task<List<CallFlowModel>> GetAllCallFlows()
	{
		var output = _cache.Get<List<CallFlowModel>>(CacheName);
		if (output is null)
		{
			var results = await _callFlows.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output, TimeSpan.FromDays(1));
		}

		return output;
	}

	public async Task<CallFlowModel> GetCallFlow(string id)
	{
		var results = await _callFlows.FindAsync(c => c.Id == id);
		return results.FirstOrDefault();
	}

	public async Task<List<CallFlowModel>> GetChildSteps(string id)
	{
		var results = await _callFlows.FindAsync(c => c.ChildSteps.Count > 0 && c.ChildSteps != null);
		return results.ToList();
	}

	public async Task AddChildStep(string parentId, CallFlowModel childStep)
	{
		var parentFilter = Builders<CallFlowModel>.Filter.Eq(c => c.Id, parentId);
		var update = Builders<CallFlowModel>.Update.Push(c => c.ChildSteps, childStep);

		await _callFlows.UpdateOneAsync(parentFilter, update);
	}

	public Task CreateCallFlow(CallFlowModel callFlow)
	{
		return _callFlows.InsertOneAsync(callFlow);
	}

	public Task UpdateCallFlow(CallFlowModel callFlow)
	{
		var filter = Builders<CallFlowModel>.Filter.Eq("Id", callFlow.Id);
		return _callFlows.ReplaceOneAsync(filter, callFlow, new ReplaceOptions { IsUpsert = true });
	}

	public Task DeleteCallFlow(string id)
	{
		var filter = Builders<CallFlowModel>.Filter.Eq(c => c.Id, id);
		return _callFlows.DeleteOneAsync(filter);
	}
}
