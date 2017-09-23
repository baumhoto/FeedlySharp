using System;

namespace Sample
{
  using FeedlySharp;

  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Access token: ");
      string token = Console.ReadLine();
      Console.Write("User ID: ");
      string userID = Console.ReadLine();
      var feedly = new FeedlyClient(CloudEnvironment.Production, clientId: null, clientSecret: null,
        redirectUri: "urn:ietf:wg:oauth:2.0:oob");
      feedly.Activate(token, userID);
      foreach(var entry in feedly.GetEntries(new string[] { "global.all" }).Result) {
        Console.WriteLine($"{entry.Title}: {entry.Summary}");
      }
      feedly.Dispose();
    }
  }
}
