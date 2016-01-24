<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/convenor.Master" CodeBehind="MyRemarks.aspx.cs" Inherits="FYPAutomation.Pages.Convener.MyRemarks" %>

<%@ Register Src="~/UserControls/Convener/CtrlMyRemarksCon.ascx" TagPrefix="uc1" TagName="CtrlMyRemarksCon" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:CtrlMyRemarksCon ID="CtrlMyRemarksCon" runat="server" />

</asp:Content>