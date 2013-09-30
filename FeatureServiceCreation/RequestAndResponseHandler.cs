using AGOLRestHandler;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace FeatureServiceCreation
{
  static class RequestAndResponseHandler
  {
    public static ServiceCatalog GetServiceCatalog(string url, string token)
    {
      string json = Request(url, token);
      //Get the object based on the described DataContract
      return GetObjectFromJSON(json, DataContractsEnum.ServiceCatalog) as ServiceCatalog;
    }

    public static UserOrganizationContent UserOrgContent(string url, string token)
    {
      string json = Request(url, token);
      //Get the object based on the described DataContract
      return GetObjectFromJSON(json, DataContractsEnum.UserOrganizationContent) as UserOrganizationContent;
    }

    private static string Request(string url, string token)
    {
      //make the request to the server
      url +="?f=pjson&token=" + token;
      //todo
      HttpWebResponse httpResponse = HttpWebGetRequest(url, "");

      //check for errors
      if (httpResponse == null)
        return null;

      //get the JSON representation from the response
      return DeserializeResponse(httpResponse.GetResponseStream());
    }

    public static Image GetThumbnail(string url)
    {
      HttpWebResponse httpResponse = HttpWebGetRequest(url, "");
      Image image = null;
      if(httpResponse != null)
        image = Image.FromStream(httpResponse.GetResponseStream());

      return image;
    }

    public static FeatureLayerAttributes GetFeatureServiceAttributes(string baseURL, string token)
    {
      //get attributes for the layer
      HttpWebResponse httpResponse = HttpWebGetRequest(baseURL + "?f=pjson&token=" + token, "");

      //get the JSON representation from the response
      string json = DeserializeResponse(httpResponse.GetResponseStream());

      //Get the object based on the described DataContract
      //TODO: can I replace FeatureLayerAttributes with DefinitionLayer instead
      return GetObjectFromJSON(json, DataContractsEnum.FeatureLayerAttributes) as FeatureLayerAttributes;
    }

    public static Self SelfWebRequest(string url, string token)
    {
      HttpWebResponse httpResponse = null;
      try
      {
        httpResponse = HttpWebGetRequest(url + "?f=pjson&token=" + token, "");
      }
      catch { return null; }

      //get the JSON representation from the response
      string json = DeserializeResponse(httpResponse.GetResponseStream());
      JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
      return javaScriptSerializer.Deserialize<Self>(json);
    }

    public static HttpWebResponse HttpWebGetRequest(string url, string referer)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      if(referer != string.Empty)
        httpWebRequest.Referer = referer;
      try
      {
        return (HttpWebResponse)httpWebRequest.GetResponse();
      }
      catch { return null; }
    }

    //private static string GetJSONResponseString(string url, string jsonTransmission)
    //{
    //  //create a request using the url that can recieve a POST
    //  HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

    //  //stipulate that this request is a POST
    //  httpWebRequest.Method = "POST";

    //  //convert the data to send into a byte array.
    //  byte[] bytesToSend = Encoding.UTF8.GetBytes(jsonTransmission);

    //  //we need to declare the content length next
    //  httpWebRequest.ContentLength = bytesToSend.Length;

    //  //set the content type property 
    //  httpWebRequest.ContentType = "application/x-www-form-urlencoded";

    //  //get the request stream
    //  Stream dataStream = httpWebRequest.GetRequestStream();

    //  //write the data to the request stream
    //  dataStream.Write(bytesToSend, 0, bytesToSend.Length);

    //  //close it as we have no further use of it.
    //  dataStream.Close();

    //  //make the request to the server
    //  HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

    //  //return the JSON representation from the response
    //  return DeserializeResponse(httpResponse.GetResponseStream());
    //}

    public static FeatureEditsResponse FeatureEditRequest(string baseURL, string jsonEdits)
    {
      ////get the JSON representation from the response
      string json = HttpWebRequestPostHelper(baseURL, jsonEdits, "");

      //Get the object based on the described DataContract
      return GetObjectFromJSON(json, DataContractsEnum.FeatureEditsResponse) as FeatureEditsResponse;
    }

    public static FeatureQueryResponse FeatureQueryRequest(string queryString)
    {
      //make the request to the server
      HttpWebResponse httpResponse = HttpWebGetRequest(queryString, "");

      //check for errors
      if (httpResponse == null)
        return null;

      //get the JSON representation from the response
      string json = DeserializeResponse(httpResponse.GetResponseStream());

      //Get the object based on the described DataContract
      return GetObjectFromJSON(json, DataContractsEnum.FeatureQueryResponse) as FeatureQueryResponse;
    }

    public static string DeserializeResponse(System.IO.Stream stream)
    {
      string JSON = string.Empty;

      using (StreamReader reader = new StreamReader(stream))
        JSON = reader.ReadToEnd();

      //can be many different errors that can be thrown, this is simply a demonstration of an invalid or missing token error in the 
      //webrequest. You will need to expand on this within your code.
      if (JSON.Contains("Token Required"))
        System.Windows.Forms.MessageBox.Show("Token Required");
      else if(JSON.Contains("error"))
      {
        errors errors = GetErrorFromJSON(JSON) as errors;
        if(errors != null)
          if(errors.error.details.Length > 0)
            System.Windows.Forms.MessageBox.Show(errors.error.details[0].ToString());
      }

      return JSON;
    }

    private static object GetErrorFromJSON(string json)
    {
      JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
      errors error = javaScriptSerializer.Deserialize<errors>(json);
      return error;
    }

    /// <summary>
    /// Helper function to deserialize the response JSON based on one of the DataContract types expected within the 
    /// original call.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="contract"></param>
    /// <returns></returns>
    private static object GetObjectFromJSON(string json, DataContractsEnum contract)
    {
      JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

      if (contract == DataContractsEnum.ServiceCatalog)
      {
        ServiceCatalog serviceCatalogDataContract = javaScriptSerializer.Deserialize<ServiceCatalog>(json);
        return serviceCatalogDataContract;
      }
      else if (contract == DataContractsEnum.FeatureLayerAttributes)
      {
        FeatureLayerAttributes featLyrAttrDataContract = javaScriptSerializer.Deserialize<FeatureLayerAttributes>(json);
        return featLyrAttrDataContract;
      }
      else if (contract == DataContractsEnum.FeatureEditsResponse)
      {
        FeatureEditsResponse addFeatDataContract = javaScriptSerializer.Deserialize<FeatureEditsResponse>(json);
        return addFeatDataContract;
      }
      else if (contract == DataContractsEnum.FeatureServiceNameAvailability)
      {
        FeatureServiceNameAvailability isAvailable = javaScriptSerializer.Deserialize<FeatureServiceNameAvailability>(json);
        return isAvailable;
      }
      else if (contract == DataContractsEnum.UserOrganizationContent)
      {
        UserOrganizationContent userContent = javaScriptSerializer.Deserialize<UserOrganizationContent>(json);
        return userContent;
      }
      else if (contract == DataContractsEnum.FeatureQueryResponse)
      {
        FeatureQueryResponse featureQueryDataContract = javaScriptSerializer.Deserialize<FeatureQueryResponse>(json);
        return featureQueryDataContract;
      }
      else
        return null;
    }

    public static string HttpWebRequestPostHelper(string url, string transmissionContent, string referer)
      {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //stipulate that this request is a POST
        httpWebRequest.Method = "POST";
        httpWebRequest.Referer = referer; 

        //convert the data to send into a byte array.
        byte[] bytesToSend = Encoding.UTF8.GetBytes(transmissionContent);

        //we need to declare the content length next
        httpWebRequest.ContentLength = bytesToSend.Length;

        //set the content type property 
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";

        //get the request stream
        Stream dataStream = httpWebRequest.GetRequestStream();

        //write the data to the request stream
        dataStream.Write(bytesToSend, 0, bytesToSend.Length);

        //close it as we have no further use of it.
        dataStream.Close();

        //make the request to the server
        HttpWebResponse httpResponse = null;
        try
        {
          httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        }
        catch { return null; }

        //return the JSON representation from the response
        return DeserializeResponse(httpResponse.GetResponseStream());
      }

    public static Authentication AuthorizeAgainstArcGISOnline(string username, string password, string referer)
    {
      //Help: www.arcgis.com/apidocs/rest/generatetoken.html

      string url = "https://www.arcgis.com/sharing/generatetoken?f=json";
      string jsonTransmission = "username=" + username + "&password=" + password + "&expiration=120&referer=" + referer + "&f=pjson";
      //create a request using the url that can recieve a POST
      string JSON = string.Empty;
      try
      {
        JSON = HttpWebRequestPostHelper(url, jsonTransmission, referer);
      }
      catch { return null; }

      JavaScriptSerializer jScriptSerializer = new JavaScriptSerializer();
      Authentication authenticationDataContract = jScriptSerializer.Deserialize<Authentication>(JSON) as Authentication;

      return authenticationDataContract;
    }

    public static object GetDataContractInfo(string url, DataContractsEnum dataContractType)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = "GET";

      HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
      string JSON = string.Empty;

      using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
        JSON = reader.ReadToEnd();

      System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

      if (dataContractType == DataContractsEnum.FeatureServiceInfo)
      {
        return javaScriptSerializer.Deserialize<FeatureServiceInfo>(JSON);
      }
      else if (dataContractType == DataContractsEnum.Administration)
      {
        return javaScriptSerializer.Deserialize<Administration>(JSON) as Administration;
      }
      else
      {
        throw new NotImplementedException();
      }
    }

    public static bool IsFeatureServiceNameAvailable(string featureServiceName, string serviceURL, string token)
    {
      if (!serviceURL.EndsWith("/"))
        serviceURL += "/";

      string url = serviceURL + "isServiceNameAvailable?name=" + featureServiceName + "&type=Feature_Service&f=json&token=" + token;
      HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      
      HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
      
      //get the JSON representation from the response
      string json = DeserializeResponse(response.GetResponseStream());
      FeatureServiceNameAvailability availability = GetObjectFromJSON(json, DataContractsEnum.FeatureServiceNameAvailability) as FeatureServiceNameAvailability;
      return availability.available;
    }

    //Typically this call would continue on from the isDesiredFeaturServiceNameAvailable, passing back an object containing a boolean
    //indicating success, string message to indicate a reason for failure, or if completed successful
    public static FeatureServiceCreationResponse CreateNewFeatureService(string featureServiceName, string serviceURL, string token, string referer)
    {
      if (!serviceURL.EndsWith("/"))
        serviceURL += "?f=json&token=" + token;//

      //request string
      CreateFeatureServiceObjectParameters createFeatServObjParams = new CreateFeatureServiceObjectParameters();
      createFeatServObjParams.currentVersion = 10.11;
      createFeatServObjParams.serviceDescription = "";
      createFeatServObjParams.hasVersionedData = false;
      createFeatServObjParams.supportsDisconnectedEditing = false;
      createFeatServObjParams.hasStaticData = false;
      createFeatServObjParams.maxRecordCount = 2000;
      createFeatServObjParams.supportedQueryFormats = "JSON";
      createFeatServObjParams.capabilities = "Query,Editing,Create,Update,Delete";
      createFeatServObjParams.description = "Testing";
      createFeatServObjParams.copyrightText = "";
      createFeatServObjParams.allowGeometryUpdates = true;
      createFeatServObjParams.units = "esriMeters"; //TODO: create an enum representation of values
      createFeatServObjParams.syncEnabled = false;

      createFeatServObjParams.editorTrackingInfo = new EditorTrackingInfo();
      createFeatServObjParams.editorTrackingInfo.enableEditorTracking = false;
      createFeatServObjParams.editorTrackingInfo.enableOwnershipAccessControl = false;
      createFeatServObjParams.editorTrackingInfo.allowOthersToUpdate = true;
      createFeatServObjParams.editorTrackingInfo.allowOthersToDelete = true;

      createFeatServObjParams.xssPreventionInfo = new XssPreventionInfo();
      createFeatServObjParams.xssPreventionInfo.xssPreventionEnabled = true;
      createFeatServObjParams.xssPreventionInfo.xssPreventionRule = "InputOnly"; //TODO: create an enum representation of values            
      createFeatServObjParams.xssPreventionInfo.xssInputRule = "rejectInvalid";  //TODO: create an enum representation of values            
      createFeatServObjParams.tables = new Table[] { }; //TODO: test if this can be omitted as this is simply creating an empty collection           
      createFeatServObjParams.name = featureServiceName;

      //Serialize the object to a string representation and add the other params needed to complete the call
      JavaScriptSerializer jScriptSerializer = new JavaScriptSerializer();
      string featureServiceInfoString = "createParameters=" + jScriptSerializer.Serialize(createFeatServObjParams) + "&targetType=featureService&f=pjson&token=" + token;
      Console.WriteLine(featureServiceInfoString);
      //ensure this is lower case or we will get an error back from the server
      featureServiceInfoString = featureServiceInfoString.ToLower();

      string JSON = HttpWebRequestPostHelper(serviceURL, featureServiceInfoString, referer);

      //code 498 invalid token. Write a catch here based on the code returned and if a 
      //498 re-request for a token quietly and then re-execute this function

      FeatureServiceCreationResponse featureServiceCreationResponse = jScriptSerializer.Deserialize<FeatureServiceCreationResponse>(JSON) as FeatureServiceCreationResponse;
      return featureServiceCreationResponse;
    }

    /// <summary>
    /// The resulting serialized string is case sensitive. Be wary of changes to the AddDefinition sub class names and structure.
    /// Changes can result in a failure on the server end.
    /// </summary>
    /// <param name="url">Feature service url to push definition into</param>
    /// <param name="definition">Feature service and field definitions</param>
    /// <param name="token">Authenticated user token</param>
    /// <returns>true if we are successful in pushing the attribute definition</returns>
    public static bool AddToFeatureServiceDefinition(string url, AddDefinition definition, string token, string referer)
    {
      //url = "http://services1.arcgis.com/q7zPNeKmTWeh7Aor/arcgis/admin/services/testtest345.FeatureServer/AddToDefinition" + "&f=pjson&token=" + token;
      JavaScriptSerializer jScriptSerializer = new JavaScriptSerializer();
      string addToDefinition = "addToDefinition=" + jScriptSerializer.Serialize(definition) + "&f=pjson&token=" + token;
      string JSON = HttpWebRequestPostHelper(url, addToDefinition, referer);
      AttributePushSuccess success = jScriptSerializer.Deserialize<AttributePushSuccess>(JSON) as AttributePushSuccess;

      return success.success;
    }

    public static bool ShareFeatureService(string itemID, string url, bool everyone, string groups, bool account, string token, string referer)
    {
      //HELP: http://www.arcgis.com/apidocs/rest/shareitems.html

      url += token;
      url = "http://www.arcgis.com/sharing/content/users//shareItems?f=json&token=" + token;
      string sharing = "items=" + itemID + "&groups=" + groups + "&everyone=" + everyone + "&account=" + account + "&f=json&token=" + token;
      string JSON = HttpWebRequestPostHelper(url, sharing, referer);

      return false;
    }

    public static Image DeserializeImage(string image)
    {
      if (image == null)
        throw new ArgumentException("Null Image String");

      Image im = null;
      try
      {
        byte[] array = Convert.FromBase64String(image);
        im = Image.FromStream(new MemoryStream(array));
      }
      catch { }
   
      return im;
    }
  }
}