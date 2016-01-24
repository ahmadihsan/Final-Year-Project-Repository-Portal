<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWeeklyReportManager.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlWeeklyReportManager" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Weekly Reports: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSessionSearch" OnSelectedIndexChanged="SessionSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:TextBox runat="server" ID="txtByProjectName" placeholder="Search by Project" />
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtByProjectName" ServiceMethod="SearchProjectsByTitle" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2"></ajaxToolkit:AutoCompleteExtender>
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
        <table style="width: 100%" class="mytable">
            <asp:GridView ID="GvdViewReports" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" DataKeyNames="PId" EmptyDataText="No data found" OnSelectedIndexChanged="GvdViewReportsSelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Tiltle" HeaderText="Project" ItemStyle-Width="65%" >
<ItemStyle Width="65%"></ItemStyle>
                    </asp:BoundField>
                    <asp:CommandField SelectText="Weekly Report" ShowSelectButton="True" ItemStyle-Width="35%" >
<ItemStyle Width="35%" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        </table>

    </fieldset>
</div>

