<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/student.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="FYPAutomation.Pages.Student.UserProfile" %>
<%@ Register Src="~/UserControls/Student/CtrlUserProfileStudent.ascx" TagPrefix="uc1" TagName="CtrlUserProfileStudent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<uc1:CtrlUserProfile runat="server" id="CtrlUserProfile" />--%>
    <uc1:CtrlUserProfileStudent runat="server" id="CtrlUserProfileStudent" />
</asp:Content>
