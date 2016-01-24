<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWeeklyMeetingGeneralView.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlWeeklyMeetingGeneralView" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Weekly Meetings View : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    
                    <div id="Search" style="float: right">
                       Filter : <asp:DropDownList ID="ddlProjects" runat="server" DataTextField="Tiltle" DataValueField="PId" AutoPostBack="True" OnSelectedIndexChanged="DddlProjectChanged"></asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table>
        <table style="width: 100%" class="mytable">
            <%--<tr>
                <td>
                    <h5>
                        <asp:LinkButton runat="server" ID="lnkWeeklyMeeting" OnClick="WeeklyMeetingClicked" CommandArgument='<%#Eval("PId") %>'></asp:LinkButton></h5>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:ListView ID="lstWeeklyMeetings" runat="server" ItemPlaceholderID="plcWeeklyMeeting">
                        <LayoutTemplate>
                            <table style="width: 100%" class="mytable">
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="plcWeeklyMeeting"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <h6>
                                        <asp:LinkButton runat="server" Text='<%#Eval("Tiltle") %>' ID="lnkWeeklyMeeting" OnClick="WeeklyMeetingClicked" CommandArgument='<%#Eval("PId") %>'></asp:LinkButton></h6>
                                </td>
                            </tr>
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
