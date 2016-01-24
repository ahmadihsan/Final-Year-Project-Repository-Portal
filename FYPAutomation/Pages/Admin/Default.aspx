<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYPAutomation.Pages.admin.Default" %>

<%@ Register Src="~/UserControls/Admin/CtrlAdminDashBoard.ascx" TagPrefix="uc1" TagName="CtrlAdminDashBoard" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAdminDashBoard runat="server" ID="CtrlAdminDashBoard" />
</asp:Content>
