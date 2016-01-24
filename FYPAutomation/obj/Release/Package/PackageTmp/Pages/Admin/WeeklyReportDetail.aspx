<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="WeeklyReportDetail.aspx.cs" Inherits="FYPAutomation.Pages.Admin.WeeklyReportDetail" %>

<%@ Register Src="~/UserControls/General/CtrlWeeklyReportDetail.ascx" TagPrefix="uc1" TagName="CtrlWeeklyReportDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklyReportDetail runat="server" id="CtrlWeeklyReportDetail" />
</asp:Content>
