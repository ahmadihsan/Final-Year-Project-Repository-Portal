<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="ViewProject.aspx.cs" Inherits="FYPAutomation.Pages.Student.ViewProject" %>

<%@ Register Src="~/UserControls/Student/CtrlViewProjectsForStudent.ascx" TagPrefix="uc1" TagName="CtrlViewProjectsForStudent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewProjectsForStudent runat="server" id="CtrlViewProjectsForStudent" />
</asp:Content>

