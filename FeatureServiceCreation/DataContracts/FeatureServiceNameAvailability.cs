using System.Runtime.Serialization;

namespace FeatureServiceCreation
{
  [DataContract]
  class FeatureServiceNameAvailability
  {
    [DataMember]
    public bool available { get; set; }
  }
}
