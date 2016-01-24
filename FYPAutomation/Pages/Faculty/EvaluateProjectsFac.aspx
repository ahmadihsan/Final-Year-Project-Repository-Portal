<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/Faculty.Master" CodeBehind="EvaluateProjectsFac.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.EvaluateProjectsFac" %>

<%@ Register Src="~/UserControls/Faculty/CtrlEvaluatePresentationFac.ascx" TagPrefix="uc1" TagName="CtrlEvaluatePres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlEvaluatePres ID="CtrlEvaluatePresentationFac" runat="server" />
</asp:Content>
