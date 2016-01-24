<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlExternalManager.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlExternalManager" %>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>External Examiner Manager: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="CreateExternalClick" OnClick="CreateExternalClick_Click" CssClass="mybtn_add" ToolTip="Create Group" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnRemoveExternalr" OnClick="btnRemoveExternalr_Click" CssClass="mybtn_remove" ToolTip="Add New" OnClientClick="return confirm('Do you want to delete External Examiner?')" />
                            <span>Delete</span>
                            <span>
                                <br />
                            </span>
                        </label>
                    </div>
                    <div id="Search" style="float: right">

                        <div class="ButtonNavigations">
                            <label>
                                <asp:TextBox runat="server" ID="txtSearchByName" placeholder="Search by Name" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="Button1_Click" />
                        </div>
                    </div>
                    <div class="clearall">
                        <label>
                            <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PsId" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged"></asp:DropDownList>
                            </span>
                        </label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdViewAllExternal" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" OnSelectedIndexChanged="GvdViewAllExternal_SelectedIndexChanged" DataKeyNames="UId" AllowPaging="True" OnRowCommand="GvdViewAllExternal_RowCommand" OnPageIndexChanging="GvdViewAllExternal_PageIndexChanging" PageSize="10" EmptyDataText="No data found">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="2%">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="8%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cboxSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" ItemStyle-Width="60%" />
                            <%-- <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                            <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" ReadOnly="True" SortExpression="MobileNumber" />
                                <asp:CommandField HeaderText="Detail" SelectText="Detail" ShowSelectButton="True" />
                            <asp:BoundField DataField="E_Office" HeaderText="Office Contact" ReadOnly="True" SortExpression="E_Office" />--%>
                            <asp:BoundField DataField="IsGrouped" HeaderText="IsGrouped" ReadOnly="True" SortExpression="IsGrouped" ItemStyle-Width="30%" />

                        </Columns>
                        <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
