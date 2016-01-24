<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="WeeklyReportDetail.aspx.cs" Inherits="FYPAutomation.Pages.Convener.WeeklyReportDetail" %>

<%@ Register Src="~/UserControls/General/CtrlWeeklyReportDetail.ascx" TagPrefix="uc1" TagName="CtrlWeeklyReportDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklyReportDetail runat="server" id="CtrlWeeklyReportDetail" />
</asp:Content>
