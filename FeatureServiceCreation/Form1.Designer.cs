namespace FeatureServiceCreation
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBoxFSName = new System.Windows.Forms.GroupBox();
      this.btnCreateFeatureService = new System.Windows.Forms.Button();
      this.btnIsNameAvailable = new System.Windows.Forms.Button();
      this.label12 = new System.Windows.Forms.Label();
      this.txtFeatureServiceName = new System.Windows.Forms.TextBox();
      this.groupBoxAddDef = new System.Windows.Forms.GroupBox();
      this.txtSpatialRef = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtYMin = new System.Windows.Forms.TextBox();
      this.txtXMax = new System.Windows.Forms.TextBox();
      this.txtXMin = new System.Windows.Forms.TextBox();
      this.txtYMax = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.ColumnFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.label1 = new System.Windows.Forms.Label();
      this.btnAddDefinitionToLayer = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtOrg = new System.Windows.Forms.TextBox();
      this.label17 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.txtUserName = new System.Windows.Forms.TextBox();
      this.btnAuthenticate = new System.Windows.Forms.Button();
      this.lblSuccess = new System.Windows.Forms.Label();
      this.label32 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.rdbtnGroup = new System.Windows.Forms.RadioButton();
      this.rdbtnOrg = new System.Windows.Forms.RadioButton();
      this.rdbtnEveryone = new System.Windows.Forms.RadioButton();
      this.groupBoxFSName.SuspendLayout();
      this.groupBoxAddDef.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBoxFSName
      // 
      this.groupBoxFSName.BackColor = System.Drawing.SystemColors.Control;
      this.groupBoxFSName.Controls.Add(this.btnCreateFeatureService);
      this.groupBoxFSName.Controls.Add(this.btnIsNameAvailable);
      this.groupBoxFSName.Controls.Add(this.label12);
      this.groupBoxFSName.Controls.Add(this.txtFeatureServiceName);
      this.groupBoxFSName.Enabled = false;
      this.groupBoxFSName.Location = new System.Drawing.Point(12, 233);
      this.groupBoxFSName.Name = "groupBoxFSName";
      this.groupBoxFSName.Size = new System.Drawing.Size(776, 132);
      this.groupBoxFSName.TabIndex = 19;
      this.groupBoxFSName.TabStop = false;
      this.groupBoxFSName.Text = "Feature Service Name Check";
      // 
      // btnCreateFeatureService
      // 
      this.btnCreateFeatureService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCreateFeatureService.Enabled = false;
      this.btnCreateFeatureService.Location = new System.Drawing.Point(533, 75);
      this.btnCreateFeatureService.Name = "btnCreateFeatureService";
      this.btnCreateFeatureService.Size = new System.Drawing.Size(226, 39);
      this.btnCreateFeatureService.TabIndex = 81;
      this.btnCreateFeatureService.Text = "Create FS";
      this.btnCreateFeatureService.UseVisualStyleBackColor = true;
      this.btnCreateFeatureService.Click += new System.EventHandler(this.btnCreateFeatureService_Click);
      // 
      // btnIsNameAvailable
      // 
      this.btnIsNameAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnIsNameAvailable.Location = new System.Drawing.Point(533, 30);
      this.btnIsNameAvailable.Name = "btnIsNameAvailable";
      this.btnIsNameAvailable.Size = new System.Drawing.Size(226, 39);
      this.btnIsNameAvailable.TabIndex = 80;
      this.btnIsNameAvailable.Text = "FS Name Availability";
      this.btnIsNameAvailable.UseVisualStyleBackColor = true;
      this.btnIsNameAvailable.Click += new System.EventHandler(this.btnIsNameAvailable_Click);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Enabled = false;
      this.label12.Location = new System.Drawing.Point(8, 48);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(236, 26);
      this.label12.TabIndex = 60;
      this.label12.Text = "Feature Service Name:";
      // 
      // txtFeatureServiceName
      // 
      this.txtFeatureServiceName.Location = new System.Drawing.Point(8, 79);
      this.txtFeatureServiceName.Name = "txtFeatureServiceName";
      this.txtFeatureServiceName.Size = new System.Drawing.Size(226, 31);
      this.txtFeatureServiceName.TabIndex = 59;
      this.txtFeatureServiceName.Text = "testtest";
      // 
      // groupBoxAddDef
      // 
      this.groupBoxAddDef.Controls.Add(this.txtSpatialRef);
      this.groupBoxAddDef.Controls.Add(this.label7);
      this.groupBoxAddDef.Controls.Add(this.txtYMin);
      this.groupBoxAddDef.Controls.Add(this.txtXMax);
      this.groupBoxAddDef.Controls.Add(this.txtXMin);
      this.groupBoxAddDef.Controls.Add(this.txtYMax);
      this.groupBoxAddDef.Controls.Add(this.label6);
      this.groupBoxAddDef.Controls.Add(this.label5);
      this.groupBoxAddDef.Controls.Add(this.label4);
      this.groupBoxAddDef.Controls.Add(this.label3);
      this.groupBoxAddDef.Controls.Add(this.label2);
      this.groupBoxAddDef.Controls.Add(this.maskedTextBox1);
      this.groupBoxAddDef.Controls.Add(this.dataGridView1);
      this.groupBoxAddDef.Controls.Add(this.label1);
      this.groupBoxAddDef.Controls.Add(this.btnAddDefinitionToLayer);
      this.groupBoxAddDef.Enabled = false;
      this.groupBoxAddDef.Location = new System.Drawing.Point(12, 371);
      this.groupBoxAddDef.Name = "groupBoxAddDef";
      this.groupBoxAddDef.Size = new System.Drawing.Size(776, 617);
      this.groupBoxAddDef.TabIndex = 79;
      this.groupBoxAddDef.TabStop = false;
      this.groupBoxAddDef.Text = "Add Service Definition";
      // 
      // txtSpatialRef
      // 
      this.txtSpatialRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtSpatialRef.Location = new System.Drawing.Point(205, 503);
      this.txtSpatialRef.Name = "txtSpatialRef";
      this.txtSpatialRef.Size = new System.Drawing.Size(86, 31);
      this.txtSpatialRef.TabIndex = 109;
      this.txtSpatialRef.Text = "102100";
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(10, 506);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(191, 26);
      this.label7.TabIndex = 108;
      this.label7.Text = "Spatial Reference:";
      // 
      // txtYMin
      // 
      this.txtYMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtYMin.Location = new System.Drawing.Point(268, 444);
      this.txtYMin.Name = "txtYMin";
      this.txtYMin.Size = new System.Drawing.Size(295, 31);
      this.txtYMin.TabIndex = 107;
      this.txtYMin.Text = "1859754.5323447795";
      // 
      // txtXMax
      // 
      this.txtXMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtXMax.Location = new System.Drawing.Point(477, 407);
      this.txtXMax.Name = "txtXMax";
      this.txtXMax.Size = new System.Drawing.Size(295, 31);
      this.txtXMax.TabIndex = 106;
      this.txtXMax.Text = "-6199999.999999896";
      // 
      // txtXMin
      // 
      this.txtXMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtXMin.Location = new System.Drawing.Point(74, 407);
      this.txtXMin.Name = "txtXMin";
      this.txtXMin.Size = new System.Drawing.Size(295, 31);
      this.txtXMin.TabIndex = 105;
      this.txtXMin.Text = "-14999999.999999743";
      // 
      // txtYMax
      // 
      this.txtYMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtYMax.Location = new System.Drawing.Point(268, 369);
      this.txtYMax.Name = "txtYMax";
      this.txtYMax.Size = new System.Drawing.Size(295, 31);
      this.txtYMax.TabIndex = 104;
      this.txtYMax.Text = "7841397.327701188";
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(440, 410);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(28, 26);
      this.label6.TabIndex = 103;
      this.label6.Text = "R";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(44, 410);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(24, 26);
      this.label5.TabIndex = 102;
      this.label5.Text = "L";
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(189, 447);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(82, 26);
      this.label4.TabIndex = 101;
      this.label4.Text = "Bottom";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(223, 372);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(48, 26);
      this.label3.TabIndex = 100;
      this.label3.Text = "Top";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 361);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 26);
      this.label2.TabIndex = 95;
      this.label2.Text = "Extent: ";
      // 
      // maskedTextBox1
      // 
      this.maskedTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.maskedTextBox1.Location = new System.Drawing.Point(205, 566);
      this.maskedTextBox1.Mask = "000000";
      this.maskedTextBox1.Name = "maskedTextBox1";
      this.maskedTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.maskedTextBox1.Size = new System.Drawing.Size(86, 31);
      this.maskedTextBox1.TabIndex = 94;
      this.maskedTextBox1.Text = "2000";
      this.maskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFieldName,
            this.ColumnDataType});
      this.dataGridView1.Location = new System.Drawing.Point(13, 36);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersWidth = 25;
      this.dataGridView1.RowTemplate.Height = 33;
      this.dataGridView1.Size = new System.Drawing.Size(739, 314);
      this.dataGridView1.TabIndex = 89;
      // 
      // ColumnFieldName
      // 
      this.ColumnFieldName.HeaderText = "Field Name";
      this.ColumnFieldName.Name = "ColumnFieldName";
      // 
      // ColumnDataType
      // 
      this.ColumnDataType.HeaderText = "Data Type";
      this.ColumnDataType.Items.AddRange(new object[] {
            "Double",
            "Integer",
            "String",
            "Date"});
      this.ColumnDataType.Name = "ColumnDataType";
      this.ColumnDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.ColumnDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 569);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(205, 26);
      this.label1.TabIndex = 88;
      this.label1.Text = "Max Record Count: ";
      // 
      // btnAddDefinitionToLayer
      // 
      this.btnAddDefinitionToLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddDefinitionToLayer.Enabled = false;
      this.btnAddDefinitionToLayer.Location = new System.Drawing.Point(533, 562);
      this.btnAddDefinitionToLayer.Name = "btnAddDefinitionToLayer";
      this.btnAddDefinitionToLayer.Size = new System.Drawing.Size(226, 39);
      this.btnAddDefinitionToLayer.TabIndex = 80;
      this.btnAddDefinitionToLayer.Text = "Add Definition";
      this.btnAddDefinitionToLayer.UseVisualStyleBackColor = true;
      this.btnAddDefinitionToLayer.Click += new System.EventHandler(this.btnAddDefinitionToLayer_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtOrg);
      this.groupBox2.Controls.Add(this.label17);
      this.groupBox2.Controls.Add(this.label14);
      this.groupBox2.Controls.Add(this.txtPassword);
      this.groupBox2.Controls.Add(this.label13);
      this.groupBox2.Controls.Add(this.txtUserName);
      this.groupBox2.Controls.Add(this.btnAuthenticate);
      this.groupBox2.Location = new System.Drawing.Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(776, 215);
      this.groupBox2.TabIndex = 80;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "ArcGIS Online Credentials";
      // 
      // txtOrg
      // 
      this.txtOrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOrg.Location = new System.Drawing.Point(8, 68);
      this.txtOrg.Name = "txtOrg";
      this.txtOrg.Size = new System.Drawing.Size(432, 31);
      this.txtOrg.TabIndex = 83;
      this.txtOrg.Text = "http://startups.maps.arcgis.com/";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(8, 39);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(227, 26);
      this.label17.TabIndex = 82;
      this.label17.Text = "Organisation Endpoint";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(238, 127);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(114, 26);
      this.label14.TabIndex = 81;
      this.label14.Text = "Password:";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(238, 158);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(202, 31);
      this.txtPassword.TabIndex = 80;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(8, 127);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(129, 26);
      this.label13.TabIndex = 79;
      this.label13.Text = "User Name:";
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new System.Drawing.Point(8, 158);
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new System.Drawing.Size(226, 31);
      this.txtUserName.TabIndex = 78;
      // 
      // btnAuthenticate
      // 
      this.btnAuthenticate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAuthenticate.Location = new System.Drawing.Point(533, 154);
      this.btnAuthenticate.Name = "btnAuthenticate";
      this.btnAuthenticate.Size = new System.Drawing.Size(226, 39);
      this.btnAuthenticate.TabIndex = 77;
      this.btnAuthenticate.Text = "Authenticate";
      this.btnAuthenticate.UseVisualStyleBackColor = true;
      this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
      // 
      // lblSuccess
      // 
      this.lblSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblSuccess.AutoSize = true;
      this.lblSuccess.Location = new System.Drawing.Point(196, 1026);
      this.lblSuccess.Name = "lblSuccess";
      this.lblSuccess.Size = new System.Drawing.Size(0, 26);
      this.lblSuccess.TabIndex = 88;
      // 
      // label32
      // 
      this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label32.AutoSize = true;
      this.label32.Location = new System.Drawing.Point(8, 1026);
      this.label32.Name = "label32";
      this.label32.Size = new System.Drawing.Size(101, 26);
      this.label32.TabIndex = 87;
      this.label32.Text = "Success:";
      // 
      // label16
      // 
      this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label16.AutoSize = true;
      this.label16.Enabled = false;
      this.label16.Location = new System.Drawing.Point(385, 991);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(93, 26);
      this.label16.TabIndex = 92;
      this.label16.Text = "Sharing:";
      // 
      // rdbtnGroup
      // 
      this.rdbtnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.rdbtnGroup.AutoSize = true;
      this.rdbtnGroup.Enabled = false;
      this.rdbtnGroup.Location = new System.Drawing.Point(525, 1022);
      this.rdbtnGroup.Name = "rdbtnGroup";
      this.rdbtnGroup.Size = new System.Drawing.Size(97, 30);
      this.rdbtnGroup.TabIndex = 91;
      this.rdbtnGroup.Text = "Group";
      this.rdbtnGroup.UseVisualStyleBackColor = true;
      // 
      // rdbtnOrg
      // 
      this.rdbtnOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.rdbtnOrg.AutoSize = true;
      this.rdbtnOrg.Enabled = false;
      this.rdbtnOrg.Location = new System.Drawing.Point(628, 1022);
      this.rdbtnOrg.Name = "rdbtnOrg";
      this.rdbtnOrg.Size = new System.Drawing.Size(160, 30);
      this.rdbtnOrg.TabIndex = 90;
      this.rdbtnOrg.Text = "Organization";
      this.rdbtnOrg.UseVisualStyleBackColor = true;
      // 
      // rdbtnEveryone
      // 
      this.rdbtnEveryone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.rdbtnEveryone.AutoSize = true;
      this.rdbtnEveryone.Checked = true;
      this.rdbtnEveryone.Enabled = false;
      this.rdbtnEveryone.Location = new System.Drawing.Point(390, 1022);
      this.rdbtnEveryone.Name = "rdbtnEveryone";
      this.rdbtnEveryone.Size = new System.Drawing.Size(129, 30);
      this.rdbtnEveryone.TabIndex = 89;
      this.rdbtnEveryone.TabStop = true;
      this.rdbtnEveryone.Text = "Everyone";
      this.rdbtnEveryone.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 1072);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.rdbtnGroup);
      this.Controls.Add(this.rdbtnOrg);
      this.Controls.Add(this.rdbtnEveryone);
      this.Controls.Add(this.lblSuccess);
      this.Controls.Add(this.label32);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBoxAddDef);
      this.Controls.Add(this.groupBoxFSName);
      this.Name = "Form1";
      this.ShowIcon = false;
      this.groupBoxFSName.ResumeLayout(false);
      this.groupBoxFSName.PerformLayout();
      this.groupBoxAddDef.ResumeLayout(false);
      this.groupBoxAddDef.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxFSName;
    private System.Windows.Forms.Button btnIsNameAvailable;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txtFeatureServiceName;
    private System.Windows.Forms.GroupBox groupBoxAddDef;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnAddDefinitionToLayer;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.Button btnAuthenticate;
    private System.Windows.Forms.Label lblSuccess;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.RadioButton rdbtnGroup;
    private System.Windows.Forms.RadioButton rdbtnOrg;
    private System.Windows.Forms.RadioButton rdbtnEveryone;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldName;
    private System.Windows.Forms.DataGridViewComboBoxColumn ColumnDataType;
    private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    private System.Windows.Forms.TextBox txtOrg;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtYMin;
    private System.Windows.Forms.TextBox txtXMax;
    private System.Windows.Forms.TextBox txtXMin;
    private System.Windows.Forms.TextBox txtYMax;
    private System.Windows.Forms.TextBox txtSpatialRef;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnCreateFeatureService;
  }
}

