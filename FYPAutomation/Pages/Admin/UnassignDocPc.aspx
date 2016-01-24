<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="UnassignDocPc.aspx.cs" Inherits="FYPAutomation.Pages.Admin.UnassignDocPc" %>

<%@ Register Src="~/UserControls/Admin/CtrlUnassignDocsFromPc.ascx" TagPrefix="uc1" TagName="CtrlUnassignDocsFromPc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlUnassignDocsFromPc runat="server" ID="CtrlUnassignDocsFromPc" />
</asp:Content>
