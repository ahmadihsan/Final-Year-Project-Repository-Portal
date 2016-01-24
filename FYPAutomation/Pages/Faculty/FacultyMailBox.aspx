<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/MailBoxFaculty.Master" CodeBehind="FacultyMailBox.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.FacultyMailBox" %>

<%@ Register Src="~/UserControls/Faculty/CtrlFacultyMailBox.ascx" TagPrefix="uc1" TagName="CtrlMailFaculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMailFaculty runat="server" ID="CtrlMailFac" />
</asp:Content>