<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlExternalDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlExternalDashBoard" %>
<%@ Register src="../Admin/CtrlAdminNotificationSideBar.ascx" tagname="CtrlAdminNotificationSideBar" tagprefix="uc1" %>


<div style="width:50%; float: left">

    <%--<div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/External/Resources.aspx")%>'><img src="../../Images/DashBoardImages/category.png" /><span>Downloads</span></a></div>--%>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/External/ViewProjects.aspx")%>'><img src="../../Images/DashBoardImages/project.png" /><span style="margin-top: -14px">My Projects</span></a></div>

<%--    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Faculty/ProjectArchive.aspx") %>'><img src="../../Images/DashBoardImages/directory.png" /><span style="margin-top: -14px">Project Archive</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Faculty/SubmitDocs.aspx")%>'><img src="../../Images/DashBoardImages/article.png" /><span style="margin-top: -14px">Submited Document</span></a></div>
    --%>
</div>
<%--<div style="width:45%; float:right">
    
    <uc1:CtrlAdminNotificationSideBar ID="CtrlAdminNotificationSideBar1" runat="server" />
    
</div>--%>