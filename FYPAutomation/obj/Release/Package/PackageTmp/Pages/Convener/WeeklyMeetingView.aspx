﻿<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="WeeklyMeetingView.aspx.cs" Inherits="FYPAutomation.Pages.Convener.WeeklyMeetingView" %>

<%@ Register Src="~/UserControls/General/CtrlWeeklyMeetingGeneralView.ascx" TagPrefix="uc1" TagName="CtrlWeeklyMeetingGeneralView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklyMeetingGeneralView runat="server" ID="CtrlWeeklyMeetingGeneralView" />
</asp:Content>
