<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/PCMember.Master" CodeBehind="StudentDetail.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.StudentDetail" %>

<%@ Register Src="~/UserControls/Admin/CtrlStudentDetail.ascx" TagPrefix="uc1" TagName="CtrlStudentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlStudentDetail runat="server" id="CtrlStudentDetail" />
</asp:Content>

