<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuControlForFac.ascx.cs" Inherits="FYPAutomation.comsats.UserControls.CtrlMenuControlForFac" %>

<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False">
    <Items>
        <asp:MenuItem Text="Projects" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Faculty/ViewMyProjects.aspx" Text="My Projects" Value="Add Faculty"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Pages/Faculty/ViewProjects.aspx" Text="View Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="#" Text="Project Acceptence Form" Value="View Faculty"></asp:MenuItem>
        </asp:MenuItem>
       
        <asp:MenuItem Text="Evaluate" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/PCMember/PCMemberComments.aspx" Text="Evaluate" Value="Evaluate"></asp:MenuItem>
        </asp:MenuItem>
        
        <asp:MenuItem Text="MileStones" Value="Admin">
         
        </asp:MenuItem>
         <asp:MenuItem Text="Evaluation" Value="Admin">
             <asp:MenuItem NavigateUrl="~/Pages/PCMember/EvaluateProjects.aspx" Text="Evaluate" Value="Add Faculty (Bulk)"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle CssClass="menu" />
</cc1:MyMenuControl>
