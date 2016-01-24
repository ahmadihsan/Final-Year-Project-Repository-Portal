<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="AddExternal.aspx.cs" Inherits="FYPAutomation.Pages.Convener.AddExternal" EnableViewState="true" %>


<%@ Register Src="~/UserControls/Admin/CtrlAddExternal.ascx" TagName="CtrlAddExt" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <uc1:CtrlAddExt ID="CtrlAddExternal" runat="server" />
</asp:Content>