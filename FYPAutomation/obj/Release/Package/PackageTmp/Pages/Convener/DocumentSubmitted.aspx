<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="DocumentSubmitted.aspx.cs" Inherits="FYPAutomation.Pages.Convener.DocumentSubmitted" %>

<%@ Register Src="~/UserControls/Admin/CtrlDocumentSubmitted.ascx" TagPrefix="uc1" TagName="CtrlDocumentSubmitted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDocumentSubmitted runat="server" id="CtrlDocumentSubmitted" />
</asp:Content>
