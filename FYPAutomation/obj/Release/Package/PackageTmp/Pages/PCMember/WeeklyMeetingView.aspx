<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="WeeklyMeetingView.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.WeeklyMeetingView" %>

<%@ Register Src="~/UserControls/General/CtrlWeeklyMeetingGeneralView.ascx" TagPrefix="uc1" TagName="CtrlWeeklyMeetingGeneralView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklyMeetingGeneralView runat="server" id="CtrlWeeklyMeetingGeneralView" />
</asp:Content>
