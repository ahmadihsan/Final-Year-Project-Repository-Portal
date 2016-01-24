<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FYPAutomation.Pages.Login" %>

<%@ Register Src="~/UserControls/General/CtrlLogin.ascx" TagPrefix="uc1" TagName="CtrlLogin" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlLogin runat="server" ID="CtrlLogin" />
</asp:Content>
