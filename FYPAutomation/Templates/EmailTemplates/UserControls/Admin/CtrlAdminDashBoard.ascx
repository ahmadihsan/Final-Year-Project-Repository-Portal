<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdminDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAdminDashBoard" %>
<%@ Register Src="~/UserControls/Admin/CtrlAdminAccordian.ascx" TagPrefix="uc1" TagName="CtrlAdminAccordian" %>

<div style="width:50%; float: left">

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ViewFaculty.aspx") %>'><img src="../../Images/DashBoardImages/Student.png" /><span>Faculty Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ViewStudent.aspx") %>'><img src="../../Images/DashBoardImages/Student.png" /><span style="margin-top: -14px">Student Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ViewProject.aspx") %>'><img src="../../Images/DashBoardImages/article.png" /><span style="margin-top: -14px">Project Info Manager</span></a></div>

    <%--MileStonesDocs // Downloads--%>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/DashBoard.aspx") %>'><img src="../../Images/DashBoardImages/Student.png" /><span>MileStones</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/DashBoard.aspx") %>'><img src="../../Images/DashBoardImages/category.png" /><span style="margin-top: -14px">Resource/ Downloads</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/Announcment.aspx") %>'><img src="../../Images/DashBoardImages/article.png" /><span>Announcments</span></a></div>
                   
                    
    <div class="DashIcon"><a href="../Pages/DashBoard.aspx"><img src="../../Images/DashBoardImages/category.png"/><span>User Manager</span></a></div>
    <div class="DashIcon"><a href="../Pages/DashBoard.aspx"><img src="../../Images/DashBoardImages/Student.png" /><span>User Manager</span></a></div>
    <div class="DashIcon"><a href="../Pages/DashBoard.aspx"><img src="../../Images/DashBoardImages/article.png" /><span>User Manager</span></a></div>

</div>
<div style="width:45%; float:right">
<%--This is just Dummy Text for future Use--%>
    <uc1:CtrlAdminAccordian runat="server" id="CtrlAdminAccordian" />
</div>