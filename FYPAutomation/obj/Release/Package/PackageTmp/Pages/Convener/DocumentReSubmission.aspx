<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="DocumentReSubmission.aspx.cs" Inherits="FYPAutomation.Pages.Convener.DocumentReSubmission" %>

<%@ Register Src="~/UserControls/PCMember/CtrlDocsOfPc.ascx" TagPrefix="uc1" TagName="CtrlDocsOfPc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDocsOfPc runat="server" ID="CtrlDocsOfPc" />
</asp:Content>
