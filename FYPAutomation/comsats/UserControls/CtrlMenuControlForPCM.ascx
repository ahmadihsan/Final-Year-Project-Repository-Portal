<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuControlForPCM.ascx.cs" Inherits="FYPAutomation.comsats.UserControls.CtrlMenuControlForPCM" %>

<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False">
    <Items>
        <asp:MenuItem Text="Projects" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/PCMember/ViewMyProjects.aspx" Text="My Projects" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/PCMember/ViewProjects.aspx" Text="View Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/PCMember/AddProject.aspx" Text="Add Project" Value="Add Project"></asp:MenuItem>
        </asp:MenuItem>
       
        <asp:MenuItem Text="Evaluate" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/PCMember/EvaluateProjectsPC.aspx" Text="Evaluate" Value="Evaluate"></asp:MenuItem>
        </asp:MenuItem>
        
        <asp:MenuItem Text="Documents" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/PCMember/DocumentReSubmission.aspx"  Text="Evaluate Doc" Value="Add Faculty"></asp:MenuItem>
            <%--<asp:MenuItem NavigateUrl="#" Text="Test 2" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="#" Text="Other" Value="View Faculty"></asp:MenuItem>--%>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle CssClass="menu" />
</cc1:MyMenuControl>
