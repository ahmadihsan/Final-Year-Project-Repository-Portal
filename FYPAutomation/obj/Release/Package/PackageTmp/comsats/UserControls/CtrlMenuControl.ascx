<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuControl.ascx.cs" Inherits="WebApplication1.comsats.CtrlMenuControl" %>

<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False">
    <Items>
        <asp:MenuItem Text="User Manager" Value="Admin">
            <asp:MenuItem Text="Faculty Manager" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Admin/AddEditFaculty.aspx" Text="Add Faculty" Value="Add Faculty"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Admin/BulkAddFaculty.aspx" Text="Add Faculty (Bulk)" Value="Add Faculty (Bulk)"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Admin/ViewFaculty.aspx" Text="View Faculty" Value="View Faculty"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Student Manager" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Admin/AddEditStudent.aspx" Text="Add Student" Value="Add Faculty"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Admin/BulkAddStudent.aspx" Text="Add Student (Bulk)" Value="Add Faculty (Bulk)"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Admin/ViewStudent.aspx" Text="View Student" Value="View Student"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="PC Manager" Value="Admin">
                
                <asp:MenuItem NavigateUrl="~/Pages/Admin/PCManager.aspx" Text="PC Member" Value="PC Member"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
         <asp:MenuItem Text="Projects" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Admin/AddProject.aspx" Text="Add Project" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/ViewProject.aspx" Text="View All Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/ViewAssignedProject.aspx" Text="Assigned Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/ViewUnassignedProject.aspx" Text="Unassigned Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem Text="Mile Stones" Value="Admin">
                <asp:MenuItem NavigateUrl="~/Pages/Admin/MileStoneManager.aspx" Text="Add Milestone" Value="Add Faculty"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Pages/Admin/Announcment.aspx" Text="View Milestone deadline" Value="Add Faculty (Bulk)"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
        
        
         <asp:MenuItem Text="Evaluation" Value="Admin">
             <asp:MenuItem NavigateUrl="~/Pages/Admin/EvaluateProjects.aspx" Text="Evaluate" Value="Add Faculty (Bulk)"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Documents" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Admin/DocumentSubmitted.aspx" Text="Review Docs" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/AssignedDocs.aspx" Text="Assigned Documents" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/SubmitDocs.aspx" Text="Submit Documents" Value="Add Faculty"></asp:MenuItem>
             <asp:MenuItem NavigateUrl="~/Pages/Admin/DocumentReSubmission.aspx" Text="Evaluate Documents" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/SubmitDocsOfFaculty.aspx" Text="Submit Documents Of Faculty" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/DocSubmissionStatus.aspx" Text="Document Submission Status" Value="Add Faculty"></asp:MenuItem>
        </asp:MenuItem>

        <asp:MenuItem Text="Downloads" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Admin/Resources.aspx" Text="Resources" Value="Add Faculty"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Reports" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Admin/WeeklyReportManager.aspx" Text="Weekly Reports" Value="Weekly Reports"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Admin/GenerateCommentReport.aspx" Text="Comment Report" Value="Weekly Reports"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle CssClass="menu" />
</cc1:MyMenuControl>

