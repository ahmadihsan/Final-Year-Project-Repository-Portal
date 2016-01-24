<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuControlForStudent.ascx.cs" Inherits="WebApplication1.comsats.CtrlMenuControlForStudent" %>

<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False">
    <Items>
        <asp:MenuItem Text="Downloads" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Student/Resources.aspx" Text="Templates" Value="Add Faculty"></asp:MenuItem>
            <%--<asp:MenuItem NavigateUrl="#" Text="Presentation Templates" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="#" Text="Project Acceptence Form" Value="View Faculty"></asp:MenuItem>--%>
        </asp:MenuItem>
       
        <asp:MenuItem Text="Projects" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Student/ViewProject.aspx" Text="View Projects" Value="Add Faculty (Bulk)"></asp:MenuItem>
        </asp:MenuItem>
        
        <asp:MenuItem Text="PC Remarks" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/Student/PCRemarsks.aspx"  Text="View Remarks" Value="Add Faculty"></asp:MenuItem>
          <%--  <asp:MenuItem NavigateUrl="#" Text="Test 2" Value="Add Faculty (Bulk)"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="#" Text="Other" Value="View Faculty"></asp:MenuItem>--%>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle CssClass="menu" />
</cc1:MyMenuControl>

