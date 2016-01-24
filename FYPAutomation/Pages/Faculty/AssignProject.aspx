<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/Faculty.Master" CodeBehind="AssignProject.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.AssignProject" EnableViewState="true" %>
<%@ Register Src="~/UserControls/Admin/CtrlAssignProject.ascx" TagPrefix="uc1" TagName="CtrlAssignProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAssignProject runat="server" ID="CtrlAssignProject" />
</asp:Content>

