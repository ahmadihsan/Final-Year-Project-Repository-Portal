<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewExtGroup.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlViewExtGroup" EnableViewState="true" %>

<style type="text/css">

    .textdec {
        text-decoration:none;
    }

</style>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>External Group: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <asp:GridView ID="GridViewExternalGroup" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" DataKeyNames="Ext_User1" AllowPaging="True" EmptyDataText="No data found" Width="1037px" OnRowDataBound="GridViewExternalGroup_RowDataBound" OnRowCommand="GridViewExternalGroup_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Ext_User1" ReadOnly="True" SortExpression="Ext_User1" Visible="false" />
                            <asp:TemplateField HeaderText="Name" ItemStyle-Width="90%">
                                <ItemTemplate>
                                     <asp:GridView ID="ExternalName" runat="server" AutoGenerateColumns="false" BorderStyle="None" GridLines="None"  ShowHeader="false" CssClass="gridWithNoBorder">
                                       <Columns>
                                           <asp:TemplateField>
                                               <ItemTemplate>
                                                   <%--<asp:LinkButton ID="GroupMemberName" runat="server" CausesValidation="False" CommandName="Detail" CommandArgument='<%# string.Format("{0}", Eval("Name").ToString()) %>' CssClass="textdec" ForeColor="#8C4510" ></asp:LinkButton>--%>
                                                   <asp:Label ID="GroupMemberName" runat="server" Text='<%# string.Format("{0}", Eval("Name").ToString()) %>'></asp:Label>
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                       </Columns>
                                       </asp:GridView>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove Group">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemoveFile" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete this file?')">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </td>
            </tr>
        </table>

    </fieldset>


</div>
