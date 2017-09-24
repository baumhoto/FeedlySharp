using System;

namespace Sample
{
  using System.IO;
  using System.Xml.Serialization;
  using FeedlySharp;

  class Program
  {
    static void Main(string[] args) {
      Config config = GetConfig();
      var feedly = new FeedlyClient(CloudEnvironment.Production, clientId: null, clientSecret: null,
        redirectUri: "urn:ietf:wg:oauth:2.0:oob");
      feedly.Activate(config.Authentication.AccessToken, config.Authentication.UserID);
      foreach(var entry in feedly.GetStreamEntries($"user/{config.Authentication.UserID}/category/global.all").Result.Items) {
        Console.WriteLine($"{entry.Title}: {entry.Summary}");
      }
      feedly.Dispose();
    }

    static Config GetConfig() {
      string homeDirectory = Environment.GetEnvironmentVariable("HOME") ?? "";
      string configPath = Path.Combine(homeDirectory, "feedly.config");
      if (File.Exists(configPath)) {
        var serializer = new XmlSerializer(typeof(Config));
        using (FileStream configStream = File.OpenRead(configPath))
          return (Config)serializer.Deserialize(configStream);
      }

      var config = new Config{ Authentication = new Authentication() };
      Console.Write("Access token: ");
      config.Authentication.AccessToken = Console.ReadLine();
      Console.Write("User ID: ");
      config.Authentication.UserID = Console.ReadLine();
      return config;
    }
  }
}
