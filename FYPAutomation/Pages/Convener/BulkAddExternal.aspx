﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="BulkAddExternal.aspx.cs" Inherits="FYPAutomation.Pages.Convener.BulkAddExternal" %>

<%@ Register Src="~/UserControls/Admin/CtrlBulkAdExternal.ascx" TagName="CtrlBulkAddExt" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlBulkAddExt Id="CtrlBulkAddExt" runat="server" />

</asp:Content>
