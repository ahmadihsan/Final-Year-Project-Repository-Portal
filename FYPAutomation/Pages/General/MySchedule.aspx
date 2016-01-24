<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/comsats.Master" CodeBehind="MySchedule.aspx.cs" Inherits="FYPAutomation.Pages.General.MySchedule" %>

<%@ Register Src="~/UserControls/General/CtrlMySchedule.ascx" TagName="SetMySchedule" TagPrefix="uc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">

    <uc1:SetMyScedule runat="server" id="SetMySchedule" />

</asp:Content>