<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="Announcment.aspx.cs" Inherits="FYPAutomation.Pages.Convener.Announcment" %>

<%@ Register Src="~/UserControls/General/CtrlAnnouncments.ascx" TagPrefix="uc1" TagName="CtrlAnnouncments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAnnouncments runat="server" id="CtrlAnnouncments" />
</asp:Content>
