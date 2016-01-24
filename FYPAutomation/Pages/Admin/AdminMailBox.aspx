<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/MailBoxAdmin.Master" CodeBehind="AdminMailBox.aspx.cs" Inherits="FYPAutomation.Pages.Admin.AdminMailBox" %>

<%@ Register Src="~/UserControls/Admin/CtrlAdminMailBox.ascx" TagPrefix="uc1" TagName="CtrlMail" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMail runat="server" ID="CtrlMail" />
</asp:Content>