<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/PCMember.Master" CodeBehind="MyRemarksPC.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.MyRemarksPC" %>


<%@ Register Src="~/UserControls/PCMember/CtrlMyRemarksPC.ascx" TagPrefix="uc1" TagName="CtrlMyRemarksPC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyRemarksPC ID="CtrlMyRemarksPC" runat="server" />
</asp:Content>