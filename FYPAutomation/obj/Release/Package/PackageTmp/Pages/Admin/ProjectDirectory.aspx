<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="ProjectDirectory.aspx.cs" Inherits="FYPAutomation.Pages.Admin.DashBoard" %>

<%@ Register Src="~/UserControls/General/CtrlViewAllArchive.ascx" TagPrefix="uc1" TagName="CtrlViewAllArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewAllArchive runat="server" ID="CtrlViewAllArchive" />
</asp:Content>
