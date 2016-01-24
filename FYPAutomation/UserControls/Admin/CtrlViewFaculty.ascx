<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewFaculty.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlViewFaculty" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>List of Faculty</legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <asp:Panel runat="server" ID="Panel1" DefaultButton="Button1" CssClass="ButtonNavigations">
                            <div class="ButtonNavigations">
                                <label>
                                    <asp:TextBox runat="server" ID="txtSearchByName" placeholder="Search by Name" />
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchByName" ServiceMethod="SearchByFaculty" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2"></ajaxToolkit:AutoCompleteExtender>
                                </label>
                            </div>
                            <div class="ButtonNavigations">
                                <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="BtnSearchClicked" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
        </table>
        <table style="width: 100%" class="mytable">
            <asp:GridView ID="GvdViewAllFaculty" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable"  DataKeyNames="RoleId,UId" AllowPaging="True" OnPageIndexChanging="GvdViewAllFacultyPageIndexChanging" PageSize="25" EmptyDataText="No data found" OnRowCommand="GvdViewAllFacultyRowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" ReadOnly="True" SortExpression="Designation" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" ReadOnly="True" SortExpression="MobileNumber" />
                    <asp:BoundField DataField="CiitExtension" HeaderText="CiitExtension" ReadOnly="True" SortExpression="CiitExtension" />
                    <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                    <asp:BoundField DataField="ResearchId" HeaderText="ResearchId" ReadOnly="True" SortExpression="ResearchId" Visible="False" />
                    <asp:TemplateField HeaderText="Detail" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Detail" Text="Detail" ForeColor="#8C4510" ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remove File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemoveFile" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete this file?')">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
            </asp:GridView>
        </table>
    </fieldset>
</div>


