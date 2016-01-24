<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="EvaluateProjects.aspx.cs" Inherits="FYPAutomation.Pages.Convener.EvaluateProjects" %>
<%@ Register Src="~/UserControls/General/CtrlEvaluatePresentation.ascx" TagPrefix="uc1" TagName="CtrlEvaluatePresentation" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<uc1:CtrlPCMemberComments runat="server" ID="CtrlPCMemberComments" />--%>
    <uc1:CtrlEvaluatePresentation runat="server" ID="CtrlEvaluatePresentation" />
</asp:Content>
