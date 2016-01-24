<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="AddPcSec.aspx.cs" Inherits="FYPAutomation.Pages.Convener.AddPcSec" %>

<%@ Register Src="~/UserControls/Convener/CtrlAddPcSec.ascx" TagPrefix="uc1" TagName="CtrlAddPcSec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddPcSec runat="server" ID="CtrlAddPcSec" />
</asp:Content>
