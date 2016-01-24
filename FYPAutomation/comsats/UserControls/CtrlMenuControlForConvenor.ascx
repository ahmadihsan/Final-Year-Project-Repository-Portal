<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuControlForConvenor.ascx.cs" Inherits="WebApplication1.comsats.CtrlMenuControlForConvenor" %>

<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False">
    <Items>
        <asp:MenuItem Text="User Manager" Value="Admin">
            <asp:MenuItem Text="Faculty Manager" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Convener/AddEditFaculty.aspx" Text="Add Faculty" Value="Add Faculty"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/BulkAddFaculty.aspx" Text="Add Faculty (Bulk)" Value="Add Faculty (Bulk)"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/ViewFaculty.aspx" Text="View Faculty" Value="View Faculty"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Student Manager" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Convener/AddEditStudent.aspx" Text="Add Student" Value="Add Faculty"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/BulkAddStudent.aspx" Text="Add Student (Bulk)" Value="Add Faculty (Bulk)"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/ViewStudent.aspx" Text="View Student" Value="View Student"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="PC Manager" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Convener/PCSecManager.aspx" Text="PC Secratary" Value="PC Secratary"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/PCManager.aspx" Text="PC Member" Value="PC Member"></asp:MenuItem>
            </asp:MenuItem>
             <asp:MenuItem Text="External Manager" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Convener/AddExternal.aspx" Text="Add External" Value="Add External"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/BulkAddExternal.aspx" Text="Add External (Bulk)" Value="Add External (Bulk)"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/ViewExternal.aspx" Text="View External" Value="View External"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/ExternalManager.aspx" Text="Create Group" Value="Manage External"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/ViewExternalGroups.aspx" Text="View Groups" Value="Manage External"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Projects" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Convener/AddProject.aspx" Text="Add Project" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/ViewProject.aspx" Text="View All Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/ViewAssignedProject.aspx" Text="Assigned Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/ViewUnassignedProject.aspx" Text="Unassigned Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem Text="Mile Stones" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Convener/MileStoneManager.aspx" Text="Milestone Manager" Value="Add Faculty"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Convener/MileStoneDeadline.aspx" Text="Deadlines" Value="Add Faculty (Bulk)"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
         <asp:MenuItem Text="Evaluation" Value="Admin">
             <asp:MenuItem NavigateUrl="~/Pages/Convener/EvaluateProjects.aspx" Text="Evaluate" Value="Add Faculty (Bulk)"></asp:MenuItem>
             <asp:MenuItem NavigateUrl="~/Pages/Convener/ProjectWithComments.aspx" Text="View Comments" Value="Add Faculty (Bulk)"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Documents" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Convener/DocumentSubmitted.aspx" Text="Review Docs" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/AssignedDocs.aspx" Text="Assigned Documents" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/SubmitDocs.aspx" Text="Submit Your Project Documents" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/DocumentReSubmission.aspx" Text="Evaluate Documents" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/SubmitDocsOfFaculty.aspx" Text="Submit Documents Of Faculty" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/DocSubmissionStatus.aspx" Text="Document Submission Status" Value="Add Faculty"></asp:MenuItem>
        </asp:MenuItem>

<%--        <asp:MenuItem Text="Downloads" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Convener/Resources.aspx" Text="Resources" Value="Add Faculty"></asp:MenuItem>
        </asp:MenuItem>--%>
        
        <asp:MenuItem Text="Reports" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Convener/WeeklyReportManager.aspx" Text="Weekly Reports" Value="Weekly Reports"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Convener/GenerateCommentReport.aspx" Text="Comment Report" Value="Weekly Reports"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle CssClass="menu" />
</cc1:MyMenuControl>

