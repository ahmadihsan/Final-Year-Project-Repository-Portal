<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/External.Master" CodeBehind="Remarks.aspx.cs" Inherits="FYPAutomation.Pages.External.Remarks" %>


<%@ Register Src="~/UserControls/External/CtrlExtRemarksRecord.ascx" TagPrefix="uc1" TagName="ExtRemarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ExtRemarks id="CtrlExtRemarksRecord" runat="server" />
</asp:Content>