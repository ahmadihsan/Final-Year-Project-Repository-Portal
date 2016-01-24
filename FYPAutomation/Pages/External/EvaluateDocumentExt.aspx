<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/External.Master" CodeBehind="EvaluateDocumentExt.aspx.cs" Inherits="FYPAutomation.Pages.External.EvaluateDocumentExt" %>

<%@ Register Src="~/UserControls/General/CtrlEvaluateDocument.ascx" TagPrefix="uc1" TagName="CtrlEvaluateDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:CtrlEvaluateDoc runat="server" ID ="CtrlEvaluateDocument" />

</asp:Content>