
namespace MapsAndToolsLibrary.DataAccess;

public interface IKbArticleData
{
	Task CreateArticle(KbArticleModel article);
	Task DeleteArticle(string id);
	Task<List<KbArticleModel>> GetAllArticles();
	Task<KbArticleModel> GetArticle(string id);
	Task UpdateArticle(KbArticleModel article);
}