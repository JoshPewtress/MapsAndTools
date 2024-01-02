using MongoDB.Bson;
using MongoDB.Driver;
using MongoTesting;
using MongoTesting.Models;

var client = new MongoClient(DbConnection.Client);
var database = client.GetDatabase("bank");

var accountsCollection = 
	database.GetCollection<Account>("accounts");

var matchStage = Builders<Account>
					.Filter
					.Lte("balance", 1000);

var aggregate = accountsCollection.Aggregate()
						.Match(matchStage)
						.Group(
							a => a.AccountType,
							r => new
							{
								accountType = r.Key,
								total = r.Sum(a => 1)
							});

var results = aggregate.ToList();

foreach (var account in results)
{
	Console.WriteLine(account);
}