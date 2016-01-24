<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAssignedDocs.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlAssignedDocs" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Assigned Documents: </legend>
        <table style="width: 100%">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <div class="ButtonNavigations">
                                <label>
                                    <asp:DropDownList runat="server" ID="ddlSession" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" OnSelectedIndexChanged="DdlSessionSelectedIndexChanged" />
                                </label>
                            </div>
                            <div class="ButtonNavigations">
                                <label>
                                    <asp:DropDownList runat="server" ID="ddlMileStones" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="DdlMileStonesSelectedIndexChanged" />
                                </label>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdAssignedDocs" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No Document Exists" OnRowCommand="GvdAssignDocsRowCommand" DataKeyNames="UMSDId,UMSId">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Tiltle" HeaderText="Project Name" />
                            <asp:BoundField DataField="DocName" HeaderText="Document" />
                            <asp:BoundField DataField="Name" HeaderText="Assigned To" />
                            <asp:TemplateField HeaderText="Unassign Project" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtn" runat="server" CausesValidation="false" CommandName="unassign" Text="Unassign" OnClientClick="return confirm('Do you want to unassign this document?')"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>



    </fieldset>



</div>
