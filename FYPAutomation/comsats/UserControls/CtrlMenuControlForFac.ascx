<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuControlForFac.ascx.cs" Inherits="FYPAutomation.comsats.UserControls.CtrlMenuControlForFac" %>

<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False">
    <Items>
        <asp:MenuItem Text="Projects" Value="Faculty">
            <asp:MenuItem NavigateUrl="~/Pages/Faculty/ViewMyProjects.aspx" Text="My Projects" Value="My Projects"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Faculty/ViewProjects.aspx" Text="View Projects" Value="View Projects"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Faculty/AddProject.aspx" Text="Add Project" Value="Add Project"></asp:MenuItem>
        </asp:MenuItem>
              
        <asp:MenuItem Text="MileStones" Value="Faculty">
         
        </asp:MenuItem>
         <asp:MenuItem Text="Evaluation" Value="Faculty">
             <asp:MenuItem NavigateUrl="~/Pages/Faculty/EvaluateProjectsFac.aspx" Text="Evaluate" Value="Evaluate"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle CssClass="menu" />
</cc1:MyMenuControl>
