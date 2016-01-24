
<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="ProjectArchive.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.ProjectArchive" %>

<%@ Register Src="~/UserControls/Faculty/CtrlProjectArchive.ascx" TagPrefix="uc1" TagName="CtrlProjectArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlProjectArchive runat="server" ID="CtrlProjectArchive" />
</asp:Content>