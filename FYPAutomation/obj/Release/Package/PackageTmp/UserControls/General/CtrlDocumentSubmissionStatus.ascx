<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDocumentSubmissionStatus.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlDocumentSubmissionStatus" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>PC Secretray Manager: </legend>
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
            <tr>
                <td>
                    <asp:GridView ID="GvdDocSubmissionStatus" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No data found" OnRowDataBound="GvdDocSubmissionStatusRowDataBound" DataKeyNames="PId">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Tiltle" HeaderText="Name" ReadOnly="True" SortExpression="Tiltle" ItemStyle-Width="50%"/>
                            <asp:TemplateField HeaderText="Scope">
                                <ItemTemplate>
                                    <asp:Image runat="server" Width="25px" Height="25px" ID="imgScope" style="border: none;border-radius: 0px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SRS">
                                <ItemTemplate>
                                    <asp:Image runat="server" Width="25px" Height="25px" ID="imgSRS" style="border: none;border-radius: 0px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SDS">
                                <ItemTemplate>
                                    <asp:Image runat="server" Width="25px" Height="25px" ID="imgSDS" style="border: none;border-radius: 0px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Final Report">
                                <ItemTemplate>
                                    <asp:Image runat="server" Width="25px" Height="25px" ID="imgRpt" style="border: none;border-radius: 0px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
