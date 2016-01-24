<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/PCMember.Master" CodeBehind="EvalDocIndiPC.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.EvalDocIndiPC" %>
<%@ Register Src="~/UserControls/General/CtrlEvalDocIndi.ascx" TagPrefix="uc1" TagName="CtrlEvalDocIndi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlEvalDocIndi ID="CtrlEvalDocIndi" runat="server" />
</asp:Content>
