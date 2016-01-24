<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewMySchedule.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlViewMySchedule" %>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Presentation Schedule: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddSchedule" OnClick="AddWeeklyScheduleClicked" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                       
                    </div>

                </td>
            </tr>
        </table>
        <asp:GridView ID="GvdMySchedule" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No Schedule exists" DataKeyNames="ScheduleId,day" ClientIDMode="AutoID" OnRowCommand="GvdScheduleRowCommand" OnRowDataBound="GvdScheduleRowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Day">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetStringDayFrom(Convert.ToInt32(Eval("Day"))) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Free Sots">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTimeSlot" runat="server" DataTextField="FreeSlot" DataValueField="TSId"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:GridView runat="server" ID="gvdFreeSlots" CssClass="mytable" EmptyDataText="No Free Slot exists" AutoGenerateColumns="False" ShowHeader="False" Width="540px"  DataKeyNames="ScheduleId,Day,TSId" OnRowEditing="GvdFreeSlotsRowEditing" OnRowUpdating="GvdFreeSlotRowUpdating" OnRowCancelingEdit="GvdFreeSlotRowEditCancelling" OnRowDeleting="GvdFreeSlotRowDeleting">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="50%">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlFreeSlotInside" runat="server"  DataTextField="FreeSlot" DataValueField="TSId">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate >
                                        <asp:Label ID="lblFreeInsideGrid" runat="server" Text='<%#Eval("FreeSlot") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<ItemStyle Width="50%" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="25%">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CommandArgument="<%#((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                    </ItemTemplate>
                                    <%--<ItemStyle Width="25%" />--%>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="25%"/>
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </fieldset>
</div>
