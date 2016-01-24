<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="EvaluateProjects.aspx.cs" Inherits="FYPAutomation.Pages.Admin.EvaluateProjects" %>
<%@ Register Src="~/UserControls/General/CtrlEvaluatePresentaion.ascx" TagPrefix="uc1" TagName="CtrlEvaluatePresentaion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <uc1:CtrlEvaluatePresentaion runat="server" ID="CtrlEvaluatePresentation" />
</asp:Content>

