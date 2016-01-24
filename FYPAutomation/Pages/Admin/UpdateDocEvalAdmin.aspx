<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/comsats.Master" CodeBehind="UpdateDocEvalAdmin.aspx.cs" Inherits="FYPAutomation.Pages.Admin.UpdateDocEvalAdmin" %>

<%@ Register Src="~/UserControls/Admin/CtrlUpdateDocEvalAdmin.ascx" TagPrefix="uc1" TagName="CtrlUpdateDocEvalAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlUpdateDocEvalAdmin ID="CtrlUpdateDocEvalAdmin" runat="server" />
</asp:Content>