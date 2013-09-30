using System.Runtime.Serialization;
using AGOLRestHandler;

//Similar to DefinitionLayer, but contains more properties. 
//We cannot include more properties than the server expects or it will error. Hence 
//a near copy.
namespace FeatureServiceCreation
{
  [DataContract]
  class CreateFeatureServiceObjectParameters
  {
    [DataMember]
    public double currentVersion { get; set; }

    [DataMember]
    public string serviceDescription { get; set; }

    [DataMember]
    public bool hasVersionedData { get; set; }

    [DataMember]
    public bool supportsDisconnectedEditing { get; set; }

    [DataMember]
    public bool hasStaticData { get; set; }

    [DataMember]
    public int maxRecordCount { get; set; }

    [DataMember]
    public string supportedQueryFormats { get; set; }

    [DataMember]
    public string capabilities { get; set; }

    [DataMember]
    public string description { get; set; }

    [DataMember]
    public string copyrightText { get; set; }

    [DataMember]
    public bool allowGeometryUpdates { get; set; }

    [DataMember]
    public string units { get; set; }

    [DataMember]
    public bool syncEnabled { get; set; }

    [DataMember]
    public EditorTrackingInfo editorTrackingInfo { get; set; }

    [DataMember]
    public XssPreventionInfo xssPreventionInfo { get; set; }

    [DataMember]
    public Table[] tables { get; set; }

    [DataMember]
    public string name { get; set; }
  }
}

