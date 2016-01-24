<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="ExternalManager.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ExternalManager" %>

<%@ Register Src="~/UserControls/Admin/CtrlExternalManager.ascx" TagName="CtrExtManager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrExtManager Id="CtrExtManager" runat="server" />
</asp:Content>