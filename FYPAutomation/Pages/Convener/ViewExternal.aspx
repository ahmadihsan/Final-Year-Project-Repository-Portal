<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="ViewExternal.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ViewExternal" %>

<%@ Register Src="~/UserControls/Admin/CtrlViewExternal.ascx" TagName="CtrlViewExt" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewExt Id="CtrlViewExt" runat="server" />
</asp:Content>
