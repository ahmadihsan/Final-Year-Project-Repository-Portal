<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlScripts.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlScripts" %>
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    <Scripts>
        <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=272931&clcid=0x409 --%>
        <%--Framework Scripts--%>
        <%--<asp:ScriptReference Name="MsAjaxBundle" />--%>
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="jquery.ui.combined" />
        <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
        <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
        <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
        <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
        <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
        <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
        <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
        <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
        <asp:ScriptReference Name="WebFormsBundle" />
        <asp:ScriptReference Path="~/Scripts/bootstrap.min.js"></asp:ScriptReference>
        <asp:ScriptReference Path="~/Scripts/DynamicMessages.js"></asp:ScriptReference>
    </Scripts>
</ajaxToolkit:ToolkitScriptManager>

