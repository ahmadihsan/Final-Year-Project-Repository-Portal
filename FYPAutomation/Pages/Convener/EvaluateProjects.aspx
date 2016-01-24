<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="EvaluateProjects.aspx.cs" Inherits="FYPAutomation.Pages.Convener.EvaluateProjects" %>
<%@ Register Src="~/UserControls/Convener/CtrlEvaluatePresentationConvener.ascx" TagPrefix="uc1" TagName="CtrlEvaluatePresentaion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <uc1:CtrlEvaluatePresentaion runat="server" ID="CtrlEvaluatePresentationConvener" />
</asp:Content>
