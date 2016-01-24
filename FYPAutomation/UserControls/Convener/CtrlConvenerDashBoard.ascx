<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlConvenerDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlConvenerDashBoard" %>
<%@ Register Src="~/UserControls/Admin/AaaaaaaMarquee.ascx" TagPrefix="uc1" TagName="AaaaaaaMarquee" %>


<div style="width:50%; float: left">

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/ViewFaculty.aspx") %>'><img src="../../Images/DashBoardImages/faculty.png" /><span>Faculty Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/ViewStudent.aspx") %>'><img src="../../Images/DashBoardImages/Student.png" /><span style="margin-top: -14px">Student Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/PCManager.aspx") %>'><img src="../../Images/DashBoardImages/Group.png" /><span style="margin-top: -14px">Project Committe Members</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/PCSecManager.aspx") %>'><img src="../../Images/DashBoardImages/Group.png" /><span style="margin-top: -14px">Project Committe Secretary</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/ViewProject.aspx") %>'><img src="../../Images/DashBoardImages/project.png" /><span style="margin-top: -14px">Project Info Manager</span></a></div>


    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/MileStoneManager") %>'><img src="../../Images/DashBoardImages/milestone.png" /><span>MileStones</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/Resources.aspx") %>'><img src="../../Images/DashBoardImages/category.png" /><span style="margin-top: -14px">Resource/ Downloads</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/MileStoneDeadline.aspx") %>'><img src="../../Images/DashBoardImages/announcment.png" /><span style="margin-top: -14px">Milestone Deadline</span></a></div>
                   
                    
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/SessionManager.aspx") %>'><img src="../../Images/DashBoardImages/session.png"/><span style="margin-top: -14px">Session Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/RGroupManager.aspx") %>'><img src="../../Images/DashBoardImages/research.png" /><span style="margin-top: -14px">ResearchGroup Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/DocumentSubmitted.aspx") %>'><img src="../../Images/DashBoardImages/PDFDocument.png" /><span style="margin-top: -14px">Document Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/Announcment.aspx") %>'><img src="../../Images/DashBoardImages/announcment.png" /><span style="margin-top: -14px">Announcments</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/PSViewEdit.aspx") %>'><img src="../../Images/DashBoardImages/presentation.png" /><span style="margin-top: -14px">Schedule Management</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/RoomsManager.aspx") %>'><img src="../../Images/DashBoardImages/Keynote.png" /><span style="margin-top: -14px">Room Management</span></a></div>
     <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Convener/ProjectDirectory.aspx") %>'><img src="../../Images/DashBoardImages/directory.png" /><span style="margin-top: -14px">Project Directory</span></a></div>
</div>
<div style="width:45%; float:right">

    <uc1:AaaaaaaMarquee runat="server" ID="AaaaaaaMarquee" />
</div>