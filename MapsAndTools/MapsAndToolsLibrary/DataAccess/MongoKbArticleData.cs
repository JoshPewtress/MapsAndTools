namespace MapsAndToolsLibrary.DataAccess;

public class MongoKbArticleData : IKbArticleData
{
	private readonly IMongoCollection<KbArticleModel> _articles;
	private readonly IMemoryCache _cache;
	private const string CacheName = "ArticlesData";

	public MongoKbArticleData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_articles = db.KbArticleCollection;
	}

	public async Task<List<KbArticleModel>> GetAllArticles()
	{
		var output = _cache.Get<List<KbArticleModel>>(CacheName);
		if (output is null)
		{
			var results = await _articles.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(CacheName, output);
		}

		return output;
	}

	public async Task<KbArticleModel> GetArticle(string id)
	{
		var results = await _articles.FindAsync(a => a.Id == id);
		return results.FirstOrDefault();
	}

	public Task CreateArticle(KbArticleModel article)
	{
		return _articles.InsertOneAsync(article);
	}

	public Task UpdateArticle(KbArticleModel article)
	{
		var filter = Builders<KbArticleModel>.Filter.Eq("Id", article.Id);
		return _articles.ReplaceOneAsync(filter, article, new ReplaceOptions { IsUpsert = true });
	}

	public Task DeleteArticle(string id)
	{
		var filter = Builders<KbArticleModel>.Filter.Eq(a => a.Id, id);
		return _articles.DeleteOneAsync(filter);
	}
}
