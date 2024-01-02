namespace MapsAndToolsLibrary.DataAccess;

public class MongoTemplateData : ITemplateData
{
	private readonly IMongoCollection<TemplateModel> _templates;
	private readonly IMemoryCache _cache;
	private const string CacheName = "TemplatesData";

	public MongoTemplateData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_templates = db.TemplateCollection;
	}

	public async Task<List<TemplateModel>> GetAllTemplates()
	{
		var output = _cache.Get<List<TemplateModel>>(CacheName);
		if (output is null)
		{
			var results = await _templates.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output, TimeSpan.FromDays(1));
		}

		return output;
	}

	public async Task<TemplateModel> GetTemplate(string id)
	{
		var results = await _templates.FindAsync(t => t.Id == id);
		return results.FirstOrDefault();
	}

	public Task CreateTemplate(TemplateModel template)
	{
		return _templates.InsertOneAsync(template);
	}

	public Task UpdateTemplate(TemplateModel template)
	{
		var filter = Builders<TemplateModel>.Filter.Eq(t => t.Id, template.Id);
		return _templates.ReplaceOneAsync(filter, template, new ReplaceOptions { IsUpsert = true });
	}

	public Task DeleteTemplate(string id)
	{
		var filter = Builders<TemplateModel>.Filter.Eq("Id", id);
		return _templates.DeleteOneAsync(filter);
	}
}
