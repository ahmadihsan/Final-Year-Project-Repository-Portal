<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/PCMember.Master" CodeBehind="UpdateDocEvalPC.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.UpdateDocEvalPC" %>


<%@ Register Src="~/UserControls/General/CtrlUpdateDocumentEvaluation.ascx" TagPrefix="uc1" TagName="CtrlUpdateDocumentEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:CtrlUpdateDocumentEvaluation ID="CtrlUpdateDocumentEvaluation" runat="server" />
</asp:Content>