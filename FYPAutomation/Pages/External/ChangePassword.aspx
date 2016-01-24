<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/External.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="FYPAutomation.Pages.External.ChangePassword" %>


<%@ Register Src="~/UserControls/General/CtrlChangePassword.ascx" TagPrefix="uc1" TagName="CtrlChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlChangePassword runat="server" ID="CtrlChangePassword" />
</asp:Content>

