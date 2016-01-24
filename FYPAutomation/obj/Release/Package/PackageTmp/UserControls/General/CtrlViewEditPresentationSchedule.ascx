<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewEditPresentationSchedule.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlViewEditPresentationSchedule" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Presentation Schedule: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddPresentations" OnClick="AddPresentationScheduleClicked" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSessionSearch" OnSelectedIndexChanged="SessionSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMileStonesSearch" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="MilestoneSearchIndexChanged"/>
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GvdPresentationSchedule" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No Schedule exists" DataKeyNames="PId,PRSCId" OnRowDataBound="GvdPresentationDataBound" ClientIDMode="AutoID" >
            <Columns>
                <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:BoundField DataField="Tiltle" HeaderText="Project" ItemStyle-Width="22%">
                    <ItemStyle Width="22%"></ItemStyle>
                </asp:BoundField>
                <%--<asp:TemplateField HeaderText="Free Slot" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:GridView runat="server" ID="gvdSuggestedTimes" CssClass="mytable" EmptyDataText="No Time match exist" AutoGenerateColumns="False" ShowHeader="False" Width="240px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetStringDayFrom(Convert.ToInt32(Eval("Day"))) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FreeTime" />
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>

                    <ItemStyle Width="25%"></ItemStyle>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSelectDate" runat="server" Text='<%# Bind("PresentationDate") %>' CssClass="datepick"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PresentationDate", "{0:D}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assign Time" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTimeFrom" Text='<%#FYPDAL.FrequentAccesses.TimeWithAMorPm(FYPDAL.FrequentAccesses.FormatTime(Eval("TimeFrom").ToString()))%>'></asp:Label>
                        <b>TO</b>
                        &nbsp;
                                <asp:Label runat="server" ID="Label2" Text='<%#FYPDAL.FrequentAccesses.TimeWithAMorPm(FYPDAL.FrequentAccesses.FormatTime(Eval("TimeTo").ToString()))%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtStartTimeEdit" runat="server" CssClass="timepic" Width="68px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStartTimeEdit" ID="rfvroma" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <b>TO</b>
                        <asp:TextBox ID="txtEndTimeEdit" runat="server" CssClass="timepic" Width="68px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEndTimeEdit" ID="RequiredFieldValidator2" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemStyle Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Room #" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRoom" Text='<%#Eval("Title")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlRoomEdit" runat="server" Width="121px" DataTextField="Title" DataValueField="RoomId"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRoomEdit" ID="rfvrom11" Text="*" ForeColor="Red" ValidationGroup='<%# "Group_" + Container.DataItemIndex %>' InitialValue="Select Room"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemStyle Width="16%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <EditItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkUpdate" Text="Update" OnClick="LnkUpdateClicked" ValidationGroup='<%# "Group_" + Container.DataItemIndex %>' />
                        <asp:LinkButton runat="server" ID="lnkCancel" Text="Cancel" OnClick="LnkCancelClicked"/>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkEditt" Text="Edit" OnClick="LinkEditClicked" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table class="mytable" style="width: 100%" id="myTableToShow" runat="server">
            <tr>
                <td>
                    <div id="Div1" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:Button ID="btnCheckConflict" runat="server" Text="Check Conflict" CssClass="btn btn-primaryByMe" OnClick="BtnCheckConflictClicked" />
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
</div>

<style type="text/css">
    .mytable td {
        background: none !important;
    }
</style>