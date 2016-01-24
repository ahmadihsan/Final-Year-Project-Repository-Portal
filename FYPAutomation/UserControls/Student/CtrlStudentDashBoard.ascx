<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlStudentDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlStudentDashBoard" %>
<%@ Register Src="~/UserControls/Admin/AaaaaaaMarquee.ascx" TagPrefix="uc1" TagName="AaaaaaaMarquee" %>


<div style="width: 50%; float: left">

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Student/Resources.aspx")%>'>
        <img src="../../Images/DashBoardImages/category.png" /><span>Downloads</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Student/ViewProject.aspx")%>'>
        <img src="../../Images/DashBoardImages/article.png" /><span style="margin-top: -14px">Projects</span></a></div>


    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Student/SubmitDocument.aspx")%>'>
        <img src="../../Images/DashBoardImages/article.png" /><span style="margin-top: -14px">MY Submissions</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Student/ViewPresentationSchedule.aspx")%>'>
        <img src="../../Images/DashBoardImages/announcment.png" /><span style="margin-top: -14px">Presentation Schedule</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Student/EvaluatedDocs.aspx")%>'>
        <img src="../../Images/DashBoardImages/directory.png" /><span style="margin-top: -14px">Evaluated Documents</span></a></div>


</div>
<div style="width: 45%; float: right">

    <uc1:AaaaaaaMarquee runat="server" ID="AaaaaaaMarquee" />

</div>
