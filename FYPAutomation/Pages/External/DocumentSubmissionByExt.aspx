<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/External.Master" CodeBehind="DocumentSubmissionByExt.aspx.cs" Inherits="FYPAutomation.Pages.External.DocumentSubmissionByExt" EnableViewState="true"%>
<%@ Register Src="~/UserControls/External/CtrlDocumentSubmissionByExt.ascx" TagName="CtrlDocument" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDocument Id="CtrlDocument" runat="server" />
</asp:Content>


