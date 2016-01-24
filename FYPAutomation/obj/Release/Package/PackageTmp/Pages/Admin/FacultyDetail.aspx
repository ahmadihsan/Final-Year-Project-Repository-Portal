<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="FacultyDetail.aspx.cs" Inherits="FYPAutomation.Pages.admin.FacultyDetail" %>

<%@ Register Src="~/UserControls/Admin/CtrlFacultyDetail.ascx" TagPrefix="uc1" TagName="CtrlFacultyDetail" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlFacultyDetail runat="server" id="CtrlFacultyDetail" />
</asp:Content>
