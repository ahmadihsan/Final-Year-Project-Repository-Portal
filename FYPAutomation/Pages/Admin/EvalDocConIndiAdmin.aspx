<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/comsats.Master" CodeBehind="EvalDocConIndiAdmin.aspx.cs" Inherits="FYPAutomation.Pages.Admin.EvalDocIndi" %>

<%@ Register  Src="~/UserControls/General/CtrlEvalDocIndi.ascx" TagPrefix="uc1" TagName="CtrlEvalDocIndi"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlEvalDocIndi ID="CtrlEvalDocIndi" runat="server" />
</asp:Content>
