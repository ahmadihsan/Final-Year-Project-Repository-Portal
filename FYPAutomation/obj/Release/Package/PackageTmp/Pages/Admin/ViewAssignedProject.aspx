<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="ViewAssignedProject.aspx.cs" Inherits="FYPAutomation.Pages.Admin.ViewAssignedProject" %>

<%@ Register Src="~/UserControls/Admin/CtrlAssignedProjects.ascx" TagPrefix="uc1" TagName="CtrlAssignedProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAssignedProjects runat="server" id="CtrlAssignedProjects" />
    <asp:GridView ID="gvdExcelAssignProj" runat="server" Visible="False"></asp:GridView>
</asp:Content>
