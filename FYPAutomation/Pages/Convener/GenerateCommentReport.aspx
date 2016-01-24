<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="GenerateCommentReport.aspx.cs" Inherits="FYPAutomation.Pages.Convener.GenerateCommentReport" %>

<%@ Register Src="~/UserControls/General/CtrlGenerateReport.ascx" TagPrefix="uc1" TagName="CtrlGenerateReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlGenerateReport runat="server" ID="CtrlGenerateReport" />
</asp:Content>
