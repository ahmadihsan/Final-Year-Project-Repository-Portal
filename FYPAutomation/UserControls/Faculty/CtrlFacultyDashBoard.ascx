<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFacultyDashBoard.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlFacultyDashBoard" %>

<%@ Register src="~/UserControls/Admin/AaaaaaaMarquee.ascx" tagname="AaaaaaaMarquee" tagprefix="uc1" %>

<div style="width:50%; float: left">

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Faculty/Resources.aspx")%>'><img src="../../Images/DashBoardImages/category.png" /><span>Downloads</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Faculty/ViewProjects.aspx")%>'><img src="../../Images/DashBoardImages/project.png" /><span style="margin-top: -14px">Projects</span></a></div>

    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Faculty/ProjectArchive.aspx") %>'><img src="../../Images/DashBoardImages/directory.png" /><span style="margin-top: -14px">Project Archive</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Faculty/SubmitDocs.aspx")%>'><img src="../../Images/DashBoardImages/article.png" /><span style="margin-top: -14px">Submit Document</span></a></div>
    <div class="DashIcon"><a href="#"><img src="../../Images/DashBoardImages/milestone.png" /><span style="margin-top: -14px">Submit Document</span></a></div>
    <div class="DashIcon"><a href="#"><img src="../../Images/DashBoardImages/article.png" /><span>test2</span></a></div>
    <%-- <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Faculty/ProjectDirectory.aspx") %>'><img src="../../Images/DashBoardImages/directory.png" /><span style="margin-top: -14px">Project Directory</span></a></div>       --%>       

</div>
<div style="width:45%; float:right">
    
    <uc1:AaaaaaaMarquee ID="AaaaaaaMarquee" runat="server" />
    
</div>