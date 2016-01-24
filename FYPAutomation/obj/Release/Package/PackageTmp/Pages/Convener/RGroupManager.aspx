<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="RGroupManager.aspx.cs" Inherits="FYPAutomation.Pages.Convener.RGroupManager" %>

<%@ Register Src="~/UserControls/Admin/CtrlRGManager.ascx" TagPrefix="uc1" TagName="CtrlRGManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlRGManager runat="server" ID="CtrlRGManager" />
</asp:Content>
