<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="ViewProjects.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.ViewProjects" %>

<%@ Register Src="~/UserControls/Faculty/CtrlViewProjectsForFaculty.ascx" TagPrefix="uc1" TagName="CtrlViewProjectsForFaculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewProjectsForFaculty runat="server" id="CtrlViewProjectsForFaculty" />
</asp:Content>
