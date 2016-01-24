<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="RoomsManager.aspx.cs" Inherits="FYPAutomation.Pages.Convener.RoomsManager" %>

<%@ Register Src="~/UserControls/General/CtrlRoomsManager.ascx" TagPrefix="uc1" TagName="CtrlRoomsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlRoomsManager runat="server" id="CtrlRoomsManager" />
</asp:Content>
