<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="BulkAddStudent.aspx.cs" Inherits="FYPAutomation.Pages.admin.BulkAddStudent" %>

<%@ Register Src="~/UserControls/Admin/CtrlBulkAddStudent.ascx" TagPrefix="uc1" TagName="CtrlBulkAddStudent" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlBulkAddStudent runat="server" ID="CtrlBulkAddStudent" />
    </asp:Content>
