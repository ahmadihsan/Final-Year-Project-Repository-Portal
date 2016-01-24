<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="FYPAutomation.Pages.Convener.Resources" %>

<%@ Register Src="~/UserControls/Convener/CtrlUploadResources.ascx" TagPrefix="uc1" TagName="CtrlUploadResources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlUploadResources runat="server" id="CtrlUploadResources" />
</asp:Content>
