<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.Default" %>

<%@ Register Src="~/UserControls/Faculty/CtrlFacultyDashBoard.ascx" TagPrefix="uc1" TagName="CtrlFacultyDashBoard" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlFacultyDashBoard runat="server" ID="CtrlFacultyDashBoard" />
</asp:Content>
