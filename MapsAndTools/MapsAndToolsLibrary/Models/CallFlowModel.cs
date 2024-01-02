namespace MapsAndToolsLibrary.Models;

public class CallFlowModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string CallType { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public List<CallFlowModel> ChildSteps { get; set; } = new();
	public string? ParentId { get; set; } = string.Empty;
	public bool IsActive { get; set; } = false;
}
