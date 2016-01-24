<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/comsats.Master" CodeBehind="ViewExternalGroups.aspx.cs" Inherits="FYPAutomation.Pages.Admin.ViewExternalGroups" EnableViewState="true" %>
<%@ Register Src="~/UserControls/General/CtrlViewExtGroup.ascx" TagName="ViewExtGroup" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ViewExtGroup Id="ViewExtGroup" runat="server" />
</asp:Content>

