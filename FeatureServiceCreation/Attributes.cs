using System.Runtime.Serialization;

namespace AGORestCallTestFS
{
  [DataContract]
  public class Attributes
  {
    [DataMember]
    public object Longitude { get; set; }

    [DataMember]
    public object Latitude { get; set; }

    [DataMember]
    public object Name { get; set; }

    [DataMember]
    public object Address { get; set; }
  }
}
