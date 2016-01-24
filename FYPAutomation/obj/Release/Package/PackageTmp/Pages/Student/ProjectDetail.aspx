<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="FYPAutomation.Pages.Student.ProjectDetail" %>

<%@ Register Src="~/UserControls/Admin/CtrlProjectDetail.ascx" TagPrefix="uc1" TagName="CtrlProjectDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlProjectDetail runat="server" id="CtrlProjectDetail" />
</asp:Content>
