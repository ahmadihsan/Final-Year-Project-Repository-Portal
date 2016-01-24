<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdminAccordian.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlAdminAccordian" %>

<div class="FieldSet">
    <table style="width: 100%" class="mytable">
        <tr>
            <td>
                <div id="dvAccordian" style="width: 400px">
                    <asp:Repeater ID="rptAccordian" runat="server">
                        <ItemTemplate>
                            <h3>
                                <%# Eval("mileStoneName") %></h3>
                            <div>
                                <p>
                                    Dear student : Submit your <h5><%# Eval("mileStoneName") %></h5> document  signed by your supervisor till <h4><%# Eval("DeadLine") %></h4><br/>
                                    No SRS document will be accepted without supervisor signature.<br />
                                    1 day late mean -1 marks. 
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
</div>