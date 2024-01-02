
namespace MapsAndToolsLibrary.DataAccess;

public interface IFdcData
{
	Task CreateFdc(FdcModel fdc);
	Task DeleteFdc(string id);
	Task<List<FdcModel>> GetAllFdcs();
	Task<FdcModel> GetFdc(string id);
	Task UpdateFdc(FdcModel fdc);
}