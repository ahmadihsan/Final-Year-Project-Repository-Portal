<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYPAutomation.UserControls.Convenor.Default" %>

<%@ Register Src="~/UserControls/Convener/CtrlConvenerDashBoard.ascx" TagPrefix="uc1" TagName="CtrlConvenerDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlConvenerDashBoard runat="server" id="CtrlConvenerDashBoard" />
</asp:Content>
