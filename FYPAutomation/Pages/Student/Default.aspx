<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYPAutomation.Pages.Student.Default" %>

<%@ Register Src="~/UserControls/Student/CtrlStudentDashBoard.ascx" TagPrefix="uc1" TagName="CtrlStudentDashBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlStudentDashBoard runat="server" id="CtrlStudentDashBoard" />
</asp:Content>
