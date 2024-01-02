
namespace MapsAndToolsLibrary.DataAccess;

public interface ITemplateData
{
	Task CreateTemplate(TemplateModel template);
	Task DeleteTemplate(string id);
	Task<List<TemplateModel>> GetAllTemplates();
	Task<TemplateModel> GetTemplate(string id);
	Task UpdateTemplate(TemplateModel template);
}