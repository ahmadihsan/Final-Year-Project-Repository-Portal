<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExternal.aspx.cs"  MasterPageFile="~/comsats/comsats.Master"  Inherits="FYPAutomation.Pages.Admin.AddExternal" %>


<%@ Register Src="~/UserControls/Admin/CtrlAddExternal.ascx" TagName="CtrlAddExt" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <uc1:CtrlAddExt ID="CtrlAddExternal" runat="server" />
</asp:Content>