<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.ChangePassword" %>

<%@ Register Src="~/UserControls/General/CtrlChangePassword.ascx" TagPrefix="uc1" TagName="CtrlChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlChangePassword runat="server" ID="CtrlChangePassword" />
</asp:Content>
