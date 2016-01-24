
<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="ProjectArchive.aspx.cs" Inherits="FYPAutomation.Pages.Admin.DashBoard" %>

<%@ Register Src="~/UserControls/General/CtrlProjectArchive.ascx" TagPrefix="uc1" TagName="CtrlProjectArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlProjectArchive runat="server" ID="CtrlProjectArchive" />
</asp:Content>