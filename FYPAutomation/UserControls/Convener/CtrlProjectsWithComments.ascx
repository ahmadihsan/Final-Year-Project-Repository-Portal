<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProjectsWithComments.ascx.cs" Inherits="FYPAutomation.UserControls.Convener.CtrlProjectsWithComments" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Project Comments : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSession" OnSelectedIndexChanged="SessionSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="Please Select session" ControlToValidate="ddlSession" ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMileStone"  DataTextField="Name" DataValueField="PMSId" />
                                <asp:RequiredFieldValidator runat="server" Text="Please Select milestone" ControlToValidate="ddlMileStone" ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:Button runat="server" ID="btnShowComments" Text="Visible to Students" OnClick="BtnCommentsClicked" CssClass="btn btn-primaryByMe" ValidationGroup="vg"/>
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
            

        </table>
        <asp:GridView ID="GvdAssignedProjects" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No data found" GridLines="Both"  DataKeyNames="PId" OnSelectedIndexChanged="GvdAssignedProjectsSelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                        </ItemTemplate>

<ItemStyle Width="5%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Tiltle" HeaderText="Project" ItemStyle-Width="45%" >
<ItemStyle Width="45%"></ItemStyle>
                    </asp:BoundField>
                    <asp:CommandField HeaderText="Comments" SelectText="View Comments" ShowSelectButton="True" >
                    <ItemStyle Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>

            </asp:GridView>
    </fieldset>
</div>