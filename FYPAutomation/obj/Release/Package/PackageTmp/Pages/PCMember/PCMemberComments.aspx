<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="PCMemberComments.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.PCMemberComments" %>
<%@ Register Src="~/UserControls/General/CtrlEvaluatePresentation.ascx" TagPrefix="uc1" TagName="CtrlEvaluatePresentation" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<uc1:CtrlPCMemberComments runat="server" id="CtrlPCMemberComments" />--%>
    <uc1:CtrlEvaluatePresentation runat="server" ID="CtrlEvaluatePresentation" />
</asp:Content>
