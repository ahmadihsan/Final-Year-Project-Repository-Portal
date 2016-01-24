<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="PCSecManager.aspx.cs" Inherits="FYPAutomation.Pages.Convener.PCSecManager" %>

<%@ Register Src="~/UserControls/Convener/CtrlPCSecManager.ascx" TagPrefix="uc1" TagName="CtrlPCSecManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPCSecManager runat="server" ID="CtrlPCSecManager" />
</asp:Content>
