<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="ExternalDetail.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ExternalDetail" %>


<%@ Register Src="~/UserControls/Admin/CtrlExternalDetail.ascx" TagName="CtrlExtDetail" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlExtDetail ID="CtrlExtDetail" runat="server" />
</asp:Content>