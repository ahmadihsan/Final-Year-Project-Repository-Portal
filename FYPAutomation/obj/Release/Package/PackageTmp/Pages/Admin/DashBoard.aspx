<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="FYPAutomation.Pages.Admin.DashBoard" %>

<%@ Register Src="~/UserControls/Admin/CtrlAdminDashBoard.ascx" TagPrefix="uc1" TagName="CtrlAdminDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAdminDashBoard runat="server" ID="CtrlAdminDashBoard" />
</asp:Content>
