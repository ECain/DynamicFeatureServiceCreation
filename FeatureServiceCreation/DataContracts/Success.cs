using System.Runtime.Serialization;

namespace FeatureServiceCreation
{
  [DataContract]
  class AttributePushSuccess
  {
    [DataMember]
    public bool success { get; set; }
  }
}
