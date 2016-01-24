<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="WeeklyMeeting.aspx.cs" Inherits="FYPAutomation.Pages.Student.WeeklyMeeting" %>

<%@ Register Src="~/UserControls/Student/CtrlWeeklyMeetingStudentView.ascx" TagPrefix="uc1" TagName="CtrlWeeklyMeetingStudentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlWeeklyMeetingStudentView runat="server" ID="CtrlWeeklyMeetingStudentView" />
</asp:Content>
