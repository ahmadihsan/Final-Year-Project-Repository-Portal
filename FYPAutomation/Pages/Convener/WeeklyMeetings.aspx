<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="WeeklyMeetings.aspx.cs" Inherits="FYPAutomation.Pages.Convener.WeeklyMeetings" %>

<%@ Register Src="~/UserControls/General/CtrlWeeklyMeetings.ascx" TagPrefix="uc1" TagName="CtrlWeeklyMeetings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklyMeetings runat="server" id="CtrlWeeklyMeetings" />
</asp:Content>
