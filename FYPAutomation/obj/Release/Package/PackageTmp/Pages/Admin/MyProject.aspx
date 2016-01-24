<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="MyProject.aspx.cs" Inherits="FYPAutomation.Pages.Admin.MyProject" %>
<%@ Register Src="~/UserControls/Admin/CtrlMyProjectsAdmin.ascx" TagPrefix="uc1" TagName="CtrlMyProjectsAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyProjectsAdmin runat="server" id="CtrlMyProjectsAdmin" />
</asp:Content>
