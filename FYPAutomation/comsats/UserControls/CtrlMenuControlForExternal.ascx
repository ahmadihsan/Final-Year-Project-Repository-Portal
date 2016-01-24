<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuControlForExternal.ascx.cs" Inherits="FYPAutomation.comsats.UserControls.CtrlMenuControlForExternal" %>
<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False">
    <Items>
        <asp:MenuItem Text="Projects" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/External/ViewMyProjects.aspx" Text="My Projects" Value=""></asp:MenuItem>
          <%--  <asp:MenuItem NavigateUrl="~/Pages/External/ViewProjects.aspx" Text="View Projects" Value=""></asp:MenuItem>--%>
            </asp:MenuItem>
       
       
              
       <%--  <asp:MenuItem Text="Evaluation" Value="External">
             <asp:MenuItem NavigateUrl="~/Pages/PCMember/EvaluateProjects.aspx" Text="Evaluate" Value="Add Faculty (Bulk)"></asp:MenuItem>
        </asp:MenuItem>--%>
         <asp:MenuItem Text="Evaluation" Value="Admin">
            <asp:MenuItem NavigateUrl="~/Pages/External/EvaluateProjects.aspx"  Text="Evaluate" Value="Add Faculty"></asp:MenuItem>
           </asp:MenuItem>
    </Items>
    <StaticMenuStyle CssClass="menu" />
</cc1:MyMenuControl>