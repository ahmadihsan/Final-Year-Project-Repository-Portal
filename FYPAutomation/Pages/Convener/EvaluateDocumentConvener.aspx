<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="EvaluateDocumentConvener.aspx.cs" Inherits="FYPAutomation.Pages.Convener.EvaluateDocumentConvener" %>

<%@ Register Src="~/UserControls/General/CtrlEvaluateDocument.ascx" TagPrefix="uc1"  TagName="CtrlEvaluateDoc"%>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">

    <uc1:CtrlEvaluateDoc ID="CtrlEvaluateDocument" runat="server" />

</asp:Content>