<%@ Page Language="C#" MasterPageFile="~/comsats/External.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYPAutomation.Pages.External.Default" %>

<%@ Register Src="~/UserControls/External/CtrlExternalDashBoard.ascx" TagPrefix="uc1" TagName="ExternalDashBoard" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ExternalDashBoard runat="server" ID="CtrlExternalDashBoard" />
</asp:Content>