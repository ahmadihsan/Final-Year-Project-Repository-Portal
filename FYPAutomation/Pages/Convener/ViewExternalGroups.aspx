<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="ViewExternalGroups.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ViewExternalGroups" %>

<%@ Register Src="~/UserControls/General/CtrlViewExtGroup.ascx" TagName="ViewExtGroup" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ViewExtGroup Id="ViewExtGroup" runat="server" />
</asp:Content>
