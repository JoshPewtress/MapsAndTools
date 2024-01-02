
namespace MapsAndToolsLibrary.DataAccess;

public interface IDailyExpectationsData
{
	Task CreateExpectation(DailyExpectationModel expectation);
	Task DeleteExpectation(string id);
	Task<List<DailyExpectationModel>> GetAllExpectations();
	Task<DailyExpectationModel> GetExpectation(string id);
	Task UpdateExpectation(DailyExpectationModel expectation);
}