<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="FacultyDetail.aspx.cs" Inherits="FYPAutomation.Pages.Convener.FacultyDetail" %>

<%@ Register Src="~/UserControls/Admin/CtrlFacultyDetail.ascx" TagPrefix="uc1" TagName="CtrlFacultyDetail" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlFacultyDetail runat="server" id="CtrlFacultyDetail" />
</asp:Content>
