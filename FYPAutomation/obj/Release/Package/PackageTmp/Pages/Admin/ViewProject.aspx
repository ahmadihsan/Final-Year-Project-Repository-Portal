<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="ViewProject.aspx.cs" Inherits="FYPAutomation.Pages.General.ViewProject" %>

<%@ Register Src="~/UserControls/Admin/CtrlViewProjects.ascx" TagPrefix="uc1" TagName="CtrlViewProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewProjects runat="server" id="CtrlViewProjects" />
</asp:Content>

