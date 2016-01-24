<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/comsats.Master" CodeBehind="ExternalManager.aspx.cs" Inherits="FYPAutomation.Pages.Admin.ExternalManager" EnableViewState="true" %>
<%@ Register Src="~/UserControls/Admin/CtrlExternalManager.ascx" TagName="CtrExtManager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrExtManager Id="CtrExtManager" runat="server" />
</asp:Content>
