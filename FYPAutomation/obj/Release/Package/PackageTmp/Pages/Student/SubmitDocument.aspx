<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="SubmitDocument.aspx.cs" Inherits="FYPAutomation.Pages.Student.SubmitDocument" %>

<%@ Register Src="~/UserControls/Student/CtrlStudentDocumentSumbission.ascx" TagPrefix="uc1" TagName="CtrlStudentDocumentSumbission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlStudentDocumentSumbission runat="server" ID="CtrlStudentDocumentSumbission" />
</asp:Content>
