<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWeeklyReportDetail.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlWeeklyReportDetail" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Project Weekly Report: </legend>
        <table style="width: 100%" class="mytable">
            <asp:GridView ID="GvdReportDetail" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" DataKeyNames="MId" AllowPaging="True" EmptyDataText="No Report Exists">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Weeks" ItemStyle-Width="10%" />
                    <asp:BoundField DataField="MeetingDate" HeaderText="Meeting Date" DataFormatString="{0:D}" ItemStyle-Width="20%" />
                    <asp:BoundField DataField="Description" HeaderText="Tasks" ItemStyle-Width="25%" />
                    <asp:BoundField DataField="CommentBySupervisor" HeaderText="Comment" ItemStyle-Width="45%" />
                </Columns>
            </asp:GridView>
        </table>
    </fieldset>
</div>
