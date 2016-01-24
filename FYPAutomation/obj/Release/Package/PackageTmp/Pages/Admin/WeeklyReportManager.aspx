<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="WeeklyReportManager.aspx.cs" Inherits="FYPAutomation.Pages.Admin.WeeklyReportManager" %>

<%@ Register Src="~/UserControls/General/CtrlWeeklyReportManager.ascx" TagPrefix="uc1" TagName="CtrlWeeklyReportManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklyReportManager runat="server" ID="CtrlWeeklyReportManager" />
</asp:Content>
