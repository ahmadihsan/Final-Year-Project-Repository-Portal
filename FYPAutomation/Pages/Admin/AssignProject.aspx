<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="AssignProject.aspx.cs" Inherits="FYPAutomation.Pages.Admin.AssignProject" %>

<%@ Register Src="~/UserControls/Admin/CtrlAssignProject.ascx" TagPrefix="uc1" TagName="CtrlAssignProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAssignProject runat="server" ID="CtrlAssignProject" />
</asp:Content>
