<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/External.Master" CodeBehind="EvaluateProjects.aspx.cs" Inherits="FYPAutomation.Pages.External.EvaluateProjects" %>

<%@ Register Src="~/UserControls/External/CtrlEvaluatePresentationExt.ascx" TagPrefix="uc1" TagName="CtrlEvalPresentaion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlEvalPresentaion runat="server" ID="CtrlEvaluatePresentationExt" />
</asp:Content>