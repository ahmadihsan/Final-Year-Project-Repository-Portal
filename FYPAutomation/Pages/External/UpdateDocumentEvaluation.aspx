<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/External.Master" CodeBehind="UpdateDocumentEvaluation.aspx.cs" Inherits="FYPAutomation.Pages.External.UpdateDocumentEvaluation" %>

<%@ Register Src="~/UserControls/General/CtrlUpdateDocumentEvaluation.ascx" TagPrefix="uc1" TagName="ReEvaluation" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="Content1" runat="server">
    <uc1:ReEvaluation id="CtrlUpdateDocumentEvaluation" runat="server" />
</asp:Content>