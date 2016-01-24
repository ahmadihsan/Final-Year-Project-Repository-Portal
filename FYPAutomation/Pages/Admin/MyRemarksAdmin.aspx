<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/comsats.Master" CodeBehind="MyRemarksAdmin.aspx.cs" Inherits="FYPAutomation.Pages.Admin.MyRemarksAdmin" %>


<%@ Register Src="~/UserControls/Admin/CtrlMyRemarksAdmin.ascx" TagPrefix="uc1" TagName="CtrlMyRemarksAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:CtrlMyRemarksAdmin ID="CtrlMyRemarksAdmin" runat="server" />

</asp:Content>