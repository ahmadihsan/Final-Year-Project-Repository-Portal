<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="DocSubmissionStatus.aspx.cs" Inherits="FYPAutomation.Pages.Admin.DocSubmissionStatus" %>

<%@ Register Src="~/UserControls/General/CtrlDocumentSubmissionStatus.ascx" TagPrefix="uc1" TagName="CtrlDocumentSubmissionStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDocumentSubmissionStatus runat="server" id="CtrlDocumentSubmissionStatus" />
</asp:Content>
