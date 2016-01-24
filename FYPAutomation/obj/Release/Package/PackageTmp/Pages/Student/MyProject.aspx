<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="MyProject.aspx.cs" Inherits="FYPAutomation.Pages.Student.MyProject" %>

<%@ Register Src="~/UserControls/Student/CtrlMyProject.ascx" TagPrefix="uc1" TagName="CtrlMyProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyProject runat="server" id="CtrlMyProject" />
</asp:Content>
