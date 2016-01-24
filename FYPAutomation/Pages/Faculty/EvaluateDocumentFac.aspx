<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/Faculty.Master" CodeBehind="EvaluateDocumentFac.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.EvaluateDocumentFac" %>

<%@ Register Src="~/UserControls/General/CtrlEvaluateDocument.ascx" TagPrefix="uc1" TagName="CtrlEvaluateDoc"%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:CtrlEvaluateDoc ID="CtrlEvaluateDocument" runat="server" />
</asp:Content>