<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAssignedProjects.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.AssignedProjects" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Assigned Projects : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSession" OnSelectedIndexChanged="MileStoneSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:Button runat="server" ID="btnExport" Text="Export to Excel Sheet" OnClick="BtnExportClicked" CssClass="btn btn-primaryByMe" />
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
            <asp:GridView ID="GvdAssignedProjects" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No data found" GridLines="None" OnRowDataBound="GvdAssignedProjectsRowDataBound" DataKeyNames="PId">
                <Columns>
                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Tiltle" HeaderText="Project" ItemStyle-Width="45%" />
                    <asp:TemplateField HeaderText="Student">
                        <ItemTemplate>
                            <asp:GridView ID="gdvStudents" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" ShowHeader="False" CssClass="gridWithNoBorder">
                                <Columns>
                                    <asp:TemplateField HeaderText="StudentName" ItemStyle-Width="40%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudents" runat="server" Text='<%# string.Format("{0}",Eval("Name").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Supervisor" ItemStyle-Width="10%" />
                </Columns>

            </asp:GridView>

        </table>

    </fieldset>
</div>
