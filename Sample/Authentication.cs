namespace Sample
{
  using System.Xml.Serialization;

  public class Authentication
  {
    [XmlElement]
    public string UserID { get; set; }
    [XmlElement]
    public string AccessToken { get; set; }
  }
}
