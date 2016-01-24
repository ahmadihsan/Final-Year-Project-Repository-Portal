<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/MailBoxConvener.Master" CodeBehind="ConvenerMailBox.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ConvenerMailBox" %>

<%@ Register Src="~/UserControls/Convener/CtrlConvenerMailBox.ascx" TagPrefix="uc1" TagName="CtrlConvenerMailBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlConvenerMailBox ID="CtrlConvenerMailBox" runat="server" />
</asp:Content>