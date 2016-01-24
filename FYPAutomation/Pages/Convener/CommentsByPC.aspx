<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="CommentsByPC.aspx.cs" Inherits="FYPAutomation.Pages.Convener.CommentsByPC" %>

<%@ Register Src="~/UserControls/Convener/CtrlViewAndAddComments.ascx" TagPrefix="uc1" TagName="CtrlViewAndAddComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewAndAddComments runat="server" id="CtrlViewAndAddComments" />
</asp:Content>
