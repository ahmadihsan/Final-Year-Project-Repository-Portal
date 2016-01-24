<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWeeklyMeetingStudentView.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlWeeklyMeetingStudentView" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Weekly Meetings : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <asp:ListView ID="lstWeeklyMeetings" runat="server" ItemPlaceholderID="plcWeeklyMeeting" >
                        <LayoutTemplate>
                            <table style="width: 100%" class="mytable">
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="plcWeeklyMeeting"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <th>
                                <asp:Label runat="server" ID="lblTitle" Text='<%#Bind("Title") %>'></asp:Label>
                                (<asp:Label runat="server" ID="lblDate" Text='<%#Bind("MeetingDate","{0:D}") %>'></asp:Label>)
                            </th>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDesc" Text='<%#Bind("Description") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Comment:</b>
                                    <asp:Label runat="server" ID="lblComment" Text='<%#Eval("CommentBySupervisor") ?? "Nill" %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
    </fieldset>
</div>