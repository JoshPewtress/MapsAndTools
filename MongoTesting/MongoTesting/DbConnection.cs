using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MongoTesting;

public static class DbConnection
{
    public static string Client { get; set; } = "mongodb+srv://admin:aP8dBS2CuVgWiQX6@cluster0.qw0v1gu.mongodb.net/?retryWrites=true&w=majority";
}
