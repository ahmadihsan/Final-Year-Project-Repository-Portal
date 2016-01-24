<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPCMemberDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlPCMemberDashBoard" %>

<%@ Register src="../Admin/CtrlAdminNotificationSideBar.ascx" tagname="CtrlAdminNotificationSideBar" tagprefix="uc1" %>

<div style="width:50%; float: left">

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/PCMember/Resources.aspx")%>'><img src="../../Images/DashBoardImages/category.png" /><span>Downloads</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/PCMember/ViewProjects.aspx")%>'><img src="../../Images/DashBoardImages/project.png" /><span style="margin-top: -14px">Projects</span></a></div>


    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/PCMember/SubmitDocument.aspx")%>'><img src="../../Images/DashBoardImages/article.png" /><span style="margin-top: -14px">Submit Document</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/PCMember/PCMemberComments.aspx")%>'><img src="../../Images/DashBoardImages/milestone.png" /><span style="margin-top: -14px">Evaluation</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/PCMember/WeeklyMeetingView.aspx")%>'><img src="../../Images/DashBoardImages/research.png" /><span style="margin-top: -14px">Weekly Meetings</span></a></div>
                   

</div>
<div style="width:45%; float:right">
    
    <uc1:CtrlAdminNotificationSideBar ID="CtrlAdminNotificationSideBar1" runat="server" />
    
</div>