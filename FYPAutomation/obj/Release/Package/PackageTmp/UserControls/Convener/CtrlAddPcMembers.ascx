<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddPcMembers.ascx.cs" Inherits="FYPAutomation.UserControls.Convener.CtrlAddPcMembers" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Add PC Member : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddPCMember" OnClick="AddPcClick" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Save</span>
                        </label>
                    </div>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:TextBox runat="server" ID="txtSearchByName" placeholder="Search by Name" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="BtnSearchClicked" />
                        </div>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
        </table>
<%--        <table style="width: 100%" class="mytable">--%>
            <asp:GridView ID="GvdViewAllFaculty" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" OnSelectedIndexChanged="GvdViewAllFacultySelectedIndexChanged" DataKeyNames="RoleId,UId" AllowPaging="True" OnPageIndexChanging="GvdViewAllFacultyPageIndexChanging" PageSize="25" EmptyDataText="No data found">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cboxSelect" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" ReadOnly="True" SortExpression="Designation" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" ReadOnly="True" SortExpression="MobileNumber" />
                    <asp:BoundField DataField="CiitExtension" HeaderText="CiitExtension" ReadOnly="True" SortExpression="CiitExtension" />
                    <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                    <asp:BoundField DataField="ResearchId" HeaderText="ResearchId" ReadOnly="True" SortExpression="ResearchId" Visible="False" />
                    <asp:CommandField HeaderText="Detail" SelectText="Detail" ShowSelectButton="True" />
                </Columns>
                <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
            </asp:GridView>
<%--        </table>--%>
    </fieldset>
</div>
