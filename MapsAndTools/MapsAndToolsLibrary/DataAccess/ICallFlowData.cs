namespace MapsAndToolsLibrary.DataAccess;

public interface ICallFlowData
{
	Task CreateCallFlow(CallFlowModel callFlow);
	Task<List<CallFlowModel>> GetAllCallFlows();
	Task<CallFlowModel> GetCallFlow(string id);
	Task<List<CallFlowModel>> GetChildSteps(string id);
	Task AddChildStep(string parentId, CallFlowModel childStep);
	Task DeleteCallFlow(string id);
	Task UpdateCallFlow(CallFlowModel callFlow);
}