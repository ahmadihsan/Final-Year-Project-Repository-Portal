<%@ Page Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="EvaluateDocument.aspx.cs" Inherits="FYPAutomation.Pages.Admin.EvaluateDocument" %>
<%@ Register Src="~/UserControls/General/CtrlEvaluateDocument.ascx" TagPrefix="uc1" TagName="CtrlEvaluateDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<uc1:CtrlEvaluateDocument runat="server" ID="CtrlEvaluateDocument" />--%>
    <uc1:CtrlEvaluateDocument runat="server" ID="CtrlEvaluateDocument" />
</asp:Content>

