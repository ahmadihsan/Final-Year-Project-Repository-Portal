<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="UpdateDocEvalCon.aspx.cs" Inherits="FYPAutomation.Pages.Convener.UpdateDocEvalCon" %>

<%@ Register Src="~/UserControls/General/CtrlUpdateDocumentEvaluation.ascx" TagPrefix="uc1" TagName="CtrlUpdateDocumentEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:CtrlUpdateDocumentEvaluation ID="CtrlUpdateDocumentEvaluation" runat="server" />
</asp:Content>