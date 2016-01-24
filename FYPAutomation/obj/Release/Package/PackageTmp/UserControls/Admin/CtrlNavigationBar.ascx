<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlNavigationBar.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlNavigationBar" %>

<tr>
    <td>
        <div class="ButtonNavigations">
            <label>
                <asp:Button runat="server" ID="btnAddDeadLine" OnClick="AddDedLineClick" CssClass="mybtn_add" ToolTip="Add New" />
                <span>Add New</span>
            </label>
        </div>
        <div id="Search" style="float: right">
            <div class="ButtonNavigations">
                <label>
                    <asp:DropDownList runat="server" ID="ddlDropDown" />
                </label>
            </div>
            <div class="ButtonNavigations">
                <label>
                    <asp:TextBox runat="server" ID="txtSearch" ToolTip="Search DeadLines"></asp:TextBox>
                    <asp:Button runat="server" ID="BtnSearch" OnClick="BtnSearchClicked" CssClass="mybtn_Search" />
                </label>
            </div>
        </div>
        <div class="clearall"></div>
    </td>
</tr>
