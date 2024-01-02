namespace MapsAndToolsLibrary.Models;

public class TemplateModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string Title { get; set; }
	public string SubjectLine { get; set; }
	public string Body { get; set; }
	public string Note { get; set; }
}
