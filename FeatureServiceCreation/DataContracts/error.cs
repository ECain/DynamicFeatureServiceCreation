using System.Runtime.Serialization;

namespace FeatureServiceCreation
{
  [DataContract]
  public class errors
  {
    [DataMember]
    public error error { get; set; }
  }

  [DataContract]
  public class error
  {
    [DataMember]
    public int code {get; set;}
    
    [DataMember]
    public string message {get; set;}

    [DataMember]
    public string[] details { get; set; }
  }
}
