<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="BulkAddFaculty.aspx.cs" Inherits="FYPAutomation.Pages.Convener.BulkAddFaculty" %>

<%@ Register Src="~/UserControls/Admin/CtrlBulkAddFaculty.ascx" TagPrefix="uc1" TagName="CtrlBulkAddFaculty" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlBulkAddFaculty runat="server" ID="CtrlBulkAddFaculty" />
</asp:Content>
