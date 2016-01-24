<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/PCMember.Master" CodeBehind="EvaluateProjectsPC.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.EvaluateProjectsPC" %>

<%@ Register Src="~/UserControls/PCMember/CtrlEvaluatePresentationPC.ascx" TagPrefix="uc1" TagName="CtrlEvalPres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlEvalPres runat="server" ID="CtrlEvaluatePresentation" />
</asp:Content>