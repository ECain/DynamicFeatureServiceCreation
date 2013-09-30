/*
* Author: Edan Cain, ESRI, 380 New York Street, Redlands, California, 92373, USA. Email: ecain@esri.com Tel: 1-909-793-2853
*  
* Code demonstrates how to structure REST calls for interaction with ArcGIS.com organization accounts.
* Allows the user to log into ArcGIS.com and create a feature service from within your organization. Furthermore, the application allows
* for the dynamic creation of a point feature service and the creation of dynamic table structure (attribution table) at run time. The 
* primary function of interest for this project is: AddDefinitionToFeatureService().
* 
* HttpWebResponses are dynamically binded too via the DataContract objects found within the AGOLRestHandler.dll. Where this work did not
* cover certain JSON represented objects, DataContracts have been provided within this project.
* You can find this project to build the AGOLRestHandler.dll within my GitHub repositories @ https://github.com/ECain. 
* 
* Code is not supported by ESRI inc, there are no use restrictions, you are free to distribute, modify and use this code.
* Enhancement or functional code requests should be sent to Edan Cain, ecain@esri.com. 
* 
* Code created to help support the Start-up community by the ESRI Emerging Business Team. If you are a start up company,
* please contact Myles Sutherland at msutherland@esri.com.
*/

using AGOLRestHandler;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace FeatureServiceCreation
{
  public partial class Form1 : Form
  {
    string _token;
    string _organizationID;
    FeatureServiceCreationResponse _featureServiceCreationResponse;
    string spatialRef = string.Empty;

    public Form1()
    {
      InitializeComponent();
    }

    #region Button Click Events
    private void btnAuthenticate_Click(object sender, EventArgs e)
    {
      AuthenticateUser();
    }

    private void btnIsNameAvailable_Click(object sender, EventArgs e)
    {
      GetNameAvailability();
    }

    private void btnCreateFeatureService_Click(object sender, EventArgs e)
    {
      CreateFeatureService();
    }

    private void btnAddDefinitionToLayer_Click(object sender, EventArgs e)
    {
      AddDefinitionToFeatureService();
    }

    #endregion

    #region Functions
    private void AuthenticateUser()
    {
      this.Cursor = Cursors.WaitCursor;

      Authentication authenticationDataContract = RequestAndResponseHandler.AuthorizeAgainstArcGISOnline(txtUserName.Text, txtPassword.Text, txtOrg.Text);

      if (authenticationDataContract != null)
      {
        if (authenticationDataContract.token != null)
        {
          _token = authenticationDataContract.token;
          Self response = RequestAndResponseHandler.SelfWebRequest("http://www.arcgis.com/sharing/rest/community/self", _token);
          _organizationID = response.orgId;
          groupBoxFSName.Enabled = true;
        }
      }
      this.Cursor = Cursors.Default;
    }

    private void GetNameAvailability()
    {
      this.Cursor = Cursors.WaitCursor;
      if (string.IsNullOrEmpty(txtFeatureServiceName.Text))
        return;

      if (string.IsNullOrEmpty(txtOrg.Text))
        return;

      string organizationEndpoint = txtOrg.Text;
      if (!organizationEndpoint.EndsWith("/"))
        organizationEndpoint += "/";

      organizationEndpoint += "sharing/portals/" + _organizationID;
      bool isAvailable = RequestAndResponseHandler.IsFeatureServiceNameAvailable(txtFeatureServiceName.Text, organizationEndpoint, _token);
      if (isAvailable)
      {
        btnCreateFeatureService.Enabled = true;
      }
      else
      {
        btnCreateFeatureService.Enabled = false;
        btnAddDefinitionToLayer.Enabled = false;
        rdbtnEveryone.Enabled = rdbtnGroup.Enabled = rdbtnOrg.Enabled = false;
        label12.Enabled = label16.Enabled = false;
      }
      this.Cursor = Cursors.Default;

      btnAddDefinitionToLayer.Enabled = true;
    }

    private void CreateFeatureService()
    {
      this.Cursor = Cursors.WaitCursor;
      string orgEndPoint = txtOrg.Text;
      if (!orgEndPoint.EndsWith("/"))
        orgEndPoint += "/";

      _featureServiceCreationResponse = RequestAndResponseHandler.CreateNewFeatureService(txtFeatureServiceName.Text, orgEndPoint + "sharing/content/users/" + txtUserName.Text + "/createService", _token, txtOrg.Text + "home/content.html"); //"http://ebgtest.maps.arcgis.com/home/content.html");
      if (_featureServiceCreationResponse == null)
        return;

      string data = txtOrg.Text + "sharing/content/items/" + _featureServiceCreationResponse.ItemId + "/data?f=json&token=" + _token;
      HttpWebResponse httpResponse = RequestAndResponseHandler.HttpWebGetRequest(data, "");
      //get the JSON representation from the response
      string json = RequestAndResponseHandler.DeserializeResponse(httpResponse.GetResponseStream());

      try
      {
        groupBoxAddDef.Enabled = true;
        btnAddDefinitionToLayer.Enabled = true;
        rdbtnEveryone.Enabled = rdbtnGroup.Enabled = rdbtnOrg.Enabled = true;
        label12.Enabled = label16.Enabled = true;
        btnCreateFeatureService.Enabled = false;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      this.Cursor = Cursors.Default;
    }

    private void AddDefinitionToFeatureService()
    {
      /*
       * The main demonstration code of this project.
       * Iterates through the DataGridView records, creating the fields and ensuring that the esri field types for each are correct.
       * */
      //Item item = null;
      Extent extent = null;
      Symbol symbol = null;
      Renderer renderer = null;
      DrawingInfo drawingInfo = null;
      object[] fields = null;
      Template template = null;
      EditorTrackingInfo editorTrackingInfo = null;
      AdminLayerInfoAttribute adminLayerInfo = null;
      DefinitionLayer layer = null;

      FeatureLayerAttributes featLayerAttributes = new FeatureLayerAttributes();

      this.Cursor = Cursors.WaitCursor;

      if (featLayerAttributes.extent != null)
        extent = featLayerAttributes.extent;
      else
      {
        extent = new Extent()
        {
          xmin = Convert.ToDouble(txtXMin.Text),  
          ymin = Convert.ToDouble(txtYMin.Text),
          xmax = Convert.ToDouble(txtXMax.Text),
          ymax = Convert.ToDouble(txtYMax.Text),
          spatialReference = new SpatialReference() { wkid = Convert.ToInt32(txtSpatialRef.Text) },
        };
      }

        symbol = new Symbol()
        {
          type = "esriPMS",
          url = "RedSphere.png",
          imageData = "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",
          contentType = "image/png",
          color = null,
          width = 15,
          height = 15,
          angle = 0,
          xoffset = 0,
          yoffset = 0
        };

        renderer = new Renderer()
        {
          type = "simple",
          symbol = symbol,
          label = "",
          description = ""
        };

        drawingInfo = new DrawingInfo()
        {
          renderer = renderer,
          labelingInfo = null
        };

        List<object> fieldList = new List<object>();
        for (int i = 0; i < dataGridView1.RowCount; i++)
        {
          DataGridViewCell cell = dataGridView1.Rows[i].Cells[1];
          if (cell.Value.ToString() == "Double")
          {
            FieldDouble field2 = new FieldDouble()
            {
              name = dataGridView1.Rows[i].Cells[0].Value.ToString(),
              type = "esriFieldTypeDouble",
              alias = dataGridView1.Rows[i].Cells[0].Value.ToString(),
              sqlType = "sqlTypeFloat",
              nullable = true,
              editable = true,
              domain = null,
              defaultValue = null
            };
          }
          else if (cell.Value.ToString() == "string")
          {
            FieldString field3 = new FieldString()
            {
              name = dataGridView1.Rows[i].Cells[0].Value.ToString(),
              type = "esriFieldTypeString",
              alias = dataGridView1.Rows[i].Cells[0].Value.ToString(),
              sqlType = "sqlTypeNVarchar",
              length = 256,
              nullable = true,
              editable = true,
              domain = null,
              defaultValue = null
            };
          }
        }

        //object array so that we can contain different types within.
        //Field type double for example does not contain a length parameter. Hence we need different field type 
        //representation. Unexpected properties for data types will cause a failure on the server end.

      fields = fieldList.ToArray();

      if (featLayerAttributes.templates != null)
        template = featLayerAttributes.templates[0];
      else
      {
        template = new Template()
        {
          name = "New Feature",
          description = "",
          drawingTool = "esriFeatureEditToolPoint",
          prototype = new Prototype()
          {
            attributes = new Attributes()
          }
        };
      }

      editorTrackingInfo = new EditorTrackingInfo()
      {
        enableEditorTracking = false,
        enableOwnershipAccessControl = false,
        allowOthersToUpdate = true,
        allowOthersToDelete = true
      };

      adminLayerInfo = new AdminLayerInfoAttribute()
      {
        geometryField = new GeometryField()
        {
          name = "Shape",
          srid = Convert.ToInt32(txtSpatialRef.Text)
        }
      };

      layer = new DefinitionLayer()
      {
        currentVersion = featLayerAttributes != null ? featLayerAttributes.currentVersion : 10.11,
        id = 0,
        name = featLayerAttributes != null ? featLayerAttributes.name != null ? featLayerAttributes.name : "BrewsDownload" : "BrewsDownload",
        type = featLayerAttributes != null ? featLayerAttributes.type != null ? featLayerAttributes.type : "Feature Layer" : "Feature Layer",
        displayField = featLayerAttributes != null ? featLayerAttributes.displayField != null ? featLayerAttributes.displayField : "" : "",
        description = "",
        copyrightText = featLayerAttributes != null ? featLayerAttributes.copyrightText != null ? featLayerAttributes.copyrightText : "" : "",
        defaultVisibility = featLayerAttributes != null ? featLayerAttributes.defaultVisibility != true ? featLayerAttributes.defaultVisibility : true : true,
        relationships = featLayerAttributes != null ? featLayerAttributes.relationShips != null ? featLayerAttributes.relationShips : new object[] { } : new object[] { },
        isDataVersioned = featLayerAttributes != null ? featLayerAttributes.isDataVersioned : false,
        supportsRollbackOnFailureParameter = true,
        supportsAdvancedQueries = true,
        geometryType = featLayerAttributes != null ? featLayerAttributes.geometryType != null ? featLayerAttributes.geometryType : "esriGeometryPoint" : "esriGeometryPoint",
        minScale = featLayerAttributes != null ? featLayerAttributes.minScale : 0,
        maxScale = featLayerAttributes != null ? featLayerAttributes.maxScale : 0,
        extent = extent,
        drawingInfo = drawingInfo,
        allowGeometryUpdates = featLayerAttributes != null ? featLayerAttributes.allowGeometryUpdates != true ? featLayerAttributes.allowGeometryUpdates : true : true,
        hasAttachments = featLayerAttributes != null ? featLayerAttributes.hasAttachments : false,
        htmlPopupType = featLayerAttributes != null ? featLayerAttributes.htmlPopupType != null ? featLayerAttributes.htmlPopupType : "esriServerHTMLPopupTypeNone" : "esriServerHTMLPopupTypeNone",
        hasM = featLayerAttributes != null ? featLayerAttributes.hasM : false,
        hasZ = featLayerAttributes != null ? featLayerAttributes.hasZ : false,
        objectIdField = featLayerAttributes != null ? featLayerAttributes.objectIdField != null ? featLayerAttributes.objectIdField : "FID" : "FID",
        globalIdField = featLayerAttributes != null ? featLayerAttributes.globalIdField != null ? featLayerAttributes.globalIdField : "" : "",
        typeIdField = featLayerAttributes != null ? featLayerAttributes.typeIdField != null ? featLayerAttributes.typeIdField : "" : "",
        fields = fields,
        types = featLayerAttributes != null ? featLayerAttributes.types != null ? featLayerAttributes.types : new object[0] : new object[0],
        templates = new Template[1] { template },
        supportedQueryFormats = featLayerAttributes != null ? featLayerAttributes.supportedQueryFormats != null ? featLayerAttributes.supportedQueryFormats : "JSON" : "JSON",
        hasStaticData = featLayerAttributes != null ? featLayerAttributes.hasStaticData : false,
        maxRecordCount = featLayerAttributes != null ? featLayerAttributes.maxRecordCount != 0 ? featLayerAttributes.maxRecordCount : 2000 : 2000,
        capabilities = featLayerAttributes != null ? featLayerAttributes.capabilities != null ? featLayerAttributes.capabilities : "Query,Editing,Create,Update,Delete" : "Query,Editing,Create,Update,Delete",
        editorTrackingInfo = editorTrackingInfo,
        adminLayerInfo = adminLayerInfo
      };

      DefinitionLayer[] layers = new DefinitionLayer[1] { layer };

      AddDefinition definition = new AddDefinition()
      {
        layers = layers
      };
      string serviceEndPoint = "http://services1.arcgis.com/";
      string serviceEndPoint2 = "http://services.arcgis.com/";
      bool b = RequestAndResponseHandler.AddToFeatureServiceDefinition(serviceEndPoint + _organizationID + "/arcgis/admin/services/" + _featureServiceCreationResponse.Name + ".FeatureServer/AddToDefinition", definition, _token, txtOrg.Text);

      if (!b)
        b = RequestAndResponseHandler.AddToFeatureServiceDefinition(serviceEndPoint2 + _organizationID + "/arcgis/admin/services/" + _featureServiceCreationResponse.Name + ".FeatureServer/AddToDefinition", definition, _token, txtOrg.Text);

      lblSuccess.Text = b == true ? "true" : "false";

      Update();

      this.Cursor = Cursors.Default;
    }
    #endregion
  }
}
