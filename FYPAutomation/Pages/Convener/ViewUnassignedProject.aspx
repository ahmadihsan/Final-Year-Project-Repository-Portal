<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="ViewUnassignedProject.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ViewUnassignedProject" %>

<%@ Register Src="~/UserControls/Admin/CtrlUnassignedProjects.ascx" TagPrefix="uc1" TagName="CtrlUnassignedProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlUnassignedProjects runat="server" id="CtrlUnassignedProjects" />
</asp:Content>
