<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlStudentDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlStudentDashBoard" %>
<%@ Register Src="~/UserControls/Admin/CtrlAdminAccordian.ascx" TagPrefix="uc1" TagName="CtrlAdminAccordian" %>



<div style="width: 50%; float: left">

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Student/Default.aspx")%>'>
        <img src="../../Images/DashBoardImages/category.png" /><span>Mile Stones</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Student/ViewProject.aspx")%>'>
        <img src="../../Images/DashBoardImages/article.png" /><span style="margin-top: -14px">Projects</span></a></div>


    <div class="DashIcon"><a href="#">
        <img src="../../Images/DashBoardImages/article.png" /><span>Downloads</span></a></div>
    <div class="DashIcon"><a href="#">
        <img src="../../Images/DashBoardImages/category.png" /><span>Submissionsr</span></a></div>
    <div class="DashIcon"><a href="#">
        <img src="../../Images/DashBoardImages/article.png" /><span>test</span></a></div>


</div>
<div style="width: 45%; float: right">
    This is just Dummy Text for future Use
<%--    <uc1:CtrlStudentAccordian runat="server" id="CtrlStudentAccordian" />--%>
    <uc1:CtrlAdminAccordian runat="server" ID="CtrlAdminAccordian" />
</div>
