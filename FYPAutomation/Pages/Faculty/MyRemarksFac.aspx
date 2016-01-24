<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/Faculty.Master" CodeBehind="MyRemarksFac.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.MyRemarksFac" %>

<%@ Register Src="~/UserControls/Faculty/CtrlMyRemarksFac.ascx"  TagPrefix="uc1" TagName="CtrlMyRemarksFac"%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyRemarksFac ID="CtrlMyRemarksFac" runat="server" />
</asp:Content>