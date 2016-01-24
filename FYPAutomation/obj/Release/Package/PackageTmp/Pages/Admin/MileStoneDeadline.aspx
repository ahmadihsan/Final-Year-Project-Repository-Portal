<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="MileStoneDeadline.aspx.cs" Inherits="FYPAutomation.Pages.Admin.MileStoneDeadline" %>

<%@ Register Src="~/UserControls/Admin/CtrlAnnouncmentDeadLines.ascx" TagPrefix="uc1" TagName="CtrlAnnouncmentDeadLines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAnnouncmentDeadLines runat="server" id="CtrlAnnouncmentDeadLines" />
</asp:Content>
