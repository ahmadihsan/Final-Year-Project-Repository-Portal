<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="ViewMyProjects.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.ViewMyProjects" %>
<%@ Register Src="~/UserControls/Faculty/CtrlMyProjectsFac.ascx" TagPrefix="uc1" TagName="CtrlMyProjectsFac" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyProjectsFac runat="server" id="CtrlMyProjectsFac" />
</asp:Content>
