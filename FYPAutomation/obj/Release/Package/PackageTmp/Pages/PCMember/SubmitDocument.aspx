<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="SubmitDocument.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.SubmitDocument" %>

<%@ Register Src="~/UserControls/Faculty/CtrlDocSubmission.ascx" TagPrefix="uc1" TagName="CtrlDocSubmission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDocSubmission runat="server" ID="CtrlDocSubmission" />
</asp:Content>
