<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/PCMember.Master" CodeBehind="EvaluateDocumentPC.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.EvaluateDocumentPC" %>

<%@ Register Src="~/UserControls/General/CtrlEvaluateDocument.ascx" TagPrefix="uc1" TagName="CtrlEvaluateDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <uc1:CtrlEvaluateDoc runat="server" ID="CtrlEvaluateDocument" />

</asp:Content>