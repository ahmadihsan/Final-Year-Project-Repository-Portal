﻿<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Student.Master" AutoEventWireup="true" CodeBehind="WeeklySchedule.aspx.cs" Inherits="FYPAutomation.Pages.Student.WeeklySchedule" %>

<%@ Register Src="~/UserControls/General/CtrlWeeklySchedule.ascx" TagPrefix="uc1" TagName="CtrlWeeklySchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklySchedule runat="server" id="CtrlWeeklySchedule" />
</asp:Content>