These validators are meant to temporarily replace the built-in validators until compatible versions of the controls are available from Windows Update.  To use the controls, include the following tagMapping section in the system.web section of your web.config.  The compiled DLL needs to be present in the bin directory of the application.

      <tagMapping>
        <add tagType="System.Web.UI.WebControls.CompareValidator"           mappedTagType="Sample.Web.UI.Compatibility.CompareValidator, Validators, Version=1.0.0.0"/>
        <add tagType="System.Web.UI.WebControls.CustomValidator"            mappedTagType="Sample.Web.UI.Compatibility.CustomValidator, Validators, Version=1.0.0.0"/>
        <add tagType="System.Web.UI.WebControls.RangeValidator"             mappedTagType="Sample.Web.UI.Compatibility.RangeValidator, Validators, Version=1.0.0.0"/>
        <add tagType="System.Web.UI.WebControls.RegularExpressionValidator" mappedTagType="Sample.Web.UI.Compatibility.RegularExpressionValidator, Validators, Version=1.0.0.0"/>
        <add tagType="System.Web.UI.WebControls.RequiredFieldValidator"     mappedTagType="Sample.Web.UI.Compatibility.RequiredFieldValidator, Validators, Version=1.0.0.0"/>
        <add tagType="System.Web.UI.WebControls.ValidationSummary"          mappedTagType="Sample.Web.UI.Compatibility.ValidationSummary, Validators, Version=1.0.0.0"/>
      </tagMapping>

