<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdminDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAdminDashBoard" %>
<%@ Register Src="~/UserControls/Admin/AaaaaaaMarquee.ascx" TagPrefix="uc1" TagName="AaaaaaaMarquee" %>

<div style="width:50%; float: left">

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ViewFaculty.aspx") %>'><img src="../../Images/DashBoardImages/faculty.png" /><span>Faculty Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ViewStudent.aspx") %>'><img src="../../Images/DashBoardImages/Student.png" /><span style="margin-top: -14px">Student Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ViewProject.aspx") %>'><img src="../../Images/DashBoardImages/project.png" /><span style="margin-top: -14px">Project Info Manager</span></a></div>


    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/MileStoneManager") %>'><img src="../../Images/DashBoardImages/milestone.png" /><span>MileStones</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/Downloads.aspx") %>'><img src="../../Images/DashBoardImages/category.png" /><span style="margin-top: -14px">Resource/ Downloads</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/MileStoneDeadline.aspx") %>'><img src="../../Images/DashBoardImages/announcment.png" /><span style="margin-top: -14px">Milestone Deadlines</span></a></div>
                   
                    
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/SessionManager.aspx") %>'><img src="../../Images/DashBoardImages/session.png"/><span style="margin-top: -14px">Session Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/RGroupManager.aspx") %>'><img src="../../Images/DashBoardImages/research.png" /><span style="margin-top: -14px">ResearchGroup Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/DocumentSubmitted.aspx") %>'><img src="../../Images/DashBoardImages/PDFDocument.png" /><span style="margin-top: -14px">Document Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/Announcment.aspx") %>'><img src="../../Images/DashBoardImages/announcment.png" /><span style="margin-top: -14px">Announcments</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/PSViewEdit.aspx") %>'><img src="../../Images/DashBoardImages/presentation.png" /><span style="margin-top: -14px">Schedule Management</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/RoomsManager.aspx") %>'><img src="../../Images/DashBoardImages/Keynote.png" /><span style="margin-top: -14px">Room Management</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ProjectDirectory.aspx") %>'><img src="../../Images/DashBoardImages/directory.png" /><span style="margin-top: -14px">Project Directory</span></a></div>
</div>
 

<div style="width:40%; float:right">
<%--This is just Dummy Text for future Use--%>
    <uc1:AaaaaaaMarquee Id="AaaaaaaMarquee" runat="server" />
</div>