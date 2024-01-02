namespace MapsAndToolsLibrary.Models;

public class DailyExpectationModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string Expectation { get; set; }
	public List<string> Contents { get; set; }
}
