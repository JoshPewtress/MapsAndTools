namespace MapsAndToolsLibrary.Models;

public class KbArticleModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string KbNumber { get; set; }
	public string Subject { get; set; }
	public string LineOfBusiness { get; set; }
}
