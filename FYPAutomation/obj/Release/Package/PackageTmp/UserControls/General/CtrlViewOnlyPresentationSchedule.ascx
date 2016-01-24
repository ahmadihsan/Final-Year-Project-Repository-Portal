<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewOnlyPresentationSchedule.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlMyPresentationSchedule_" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>My Presentation Schedule: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <%--<label>--%>
                            Project session : <asp:Label runat="server" ID="lblSession"></asp:Label>
                        <%--</label>--%>
                    </div>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMileStonesSearch" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="MilestoneSearchIndexChanged"/>
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
        </table>

        <asp:GridView ID="GvdMyPresentationSchedule" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No Schedule exists"  ClientIDMode="AutoID" >
            <Columns>
                <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Mile Stone" />
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
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PresentationDate", "{0:D}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assigned Timings" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTimeFrom" Text='<%#FYPDAL.FrequentAccesses.TimeWithAMorPm(FYPDAL.FrequentAccesses.FormatTime(Eval("TimeFrom").ToString()))%>'></asp:Label>
                        <b>TO</b>
                        &nbsp;
                                <asp:Label runat="server" ID="Label2" Text='<%#FYPDAL.FrequentAccesses.TimeWithAMorPm(FYPDAL.FrequentAccesses.FormatTime(Eval("TimeTo").ToString()))%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Room #" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRoom" Text='<%#Eval("Title")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="16%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </fieldset>
</div>