﻿<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="ViewFaculty.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ViewFaculty" %>

<%@ Register Src="~/UserControls/Admin/CtrlViewFaculty.ascx" TagPrefix="uc1" TagName="CtrlViewFaculty" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewFaculty runat="server" id="CtrlViewFaculty" />
</asp:Content>