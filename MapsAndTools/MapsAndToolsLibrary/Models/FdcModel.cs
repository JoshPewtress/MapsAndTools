namespace MapsAndToolsLibrary.Models;

public class FdcModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string FdcName { get; set; }
	public string FdcId { get; set; }
	public string FdcPhoneNumber { get; set; }
	public List<string> EscalationPhoneNumbers { get; set; }
}
