<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="PCRemarsks.aspx.cs" Inherits="FYPAutomation.Pages.Student.PCRemarsks" %>

<%@ Register Src="~/UserControls/Student/CtrlCommentsToStudent.ascx" TagPrefix="uc1" TagName="CtrlCommentsToStudent" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlCommentsToStudent runat="server" id="CtrlCommentsToStudent" />
</asp:Content>
