namespace Sample
{
  using System.Xml.Serialization;

  public class Config
  {
    [XmlElement]
    public Authentication Authentication { get; set; }
  }
}
