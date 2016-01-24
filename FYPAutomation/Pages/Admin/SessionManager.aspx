<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="SessionManager.aspx.cs" Inherits="FYPAutomation.Pages.Admin.SessionManager" %>

<%@ Register Src="~/UserControls/Admin/CtrlSessionManager.ascx" TagPrefix="uc1" TagName="CtrlSessionManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlSessionManager runat="server" id="CtrlSessionManager" />
</asp:Content>
