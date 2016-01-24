<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/MailBoxAdmin.Master" CodeBehind="ViewAdminMail.aspx.cs" Inherits="FYPAutomation.Pages.Admin.ViewAdminMail" EnableViewState="true" %>


<%@ Register Src="~/UserControls/General/CtrlViewMail.ascx" TagPrefix="uc1" TagName="CtrlView" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlView runat="server" ID="CtrlView" />
</asp:Content>
