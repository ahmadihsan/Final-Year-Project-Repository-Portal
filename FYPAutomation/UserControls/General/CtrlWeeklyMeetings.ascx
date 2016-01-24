<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWeeklyMeetings.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlWeeklyMeetings" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Weekly Meetings : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddMeeting" OnClick="AddMeetingClicked" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <h5><asp:Label runat="server" Text='<%#Eval("Tiltle") %>' ID="lblTitleProj" style="color: skyblue"></asp:Label></h5>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListView ID="lstWeeklyMeetings" runat="server" ItemPlaceholderID="plcWeeklyMeeting" DataKeyNames="MId">
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
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Width="500px" Height="50px" placeholder="Comment Here..."></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComment" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="vgSubmit">Please Enter some text</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primaryByMe" OnClick="SubmitCommentClicked" ValidationGroup="vgSubmit"/>
                </td>
            </tr>
        </table>
    </fieldset>
</div>

<div id="AddWeeklyMeeting" class="modal hide fade ckEditorSettingWindow" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="myModalLabel">Add Weekly Meeting</h5>
    </div>
    <div class="modal-body">
        <div class="FieldSet">
            <fieldset class="FieldSet">
                <legend>Add Weekly Meeting: </legend>
                <table style="width: 100%">
                    <tr>
                        <td>Title/Week:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTilte"></asp:TextBox>e.g Week-1234</td>
                    </tr>
                    <tr>
                        <td>Description:</td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtDescription" runat="server"></CKEditor:CKEditorControl>
                            <%--<asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Width="350px" Height="150px"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="btnAddMeetingSubmit" OnClick="AddMeetingSubmitClicked" Text="Add Meeting" CssClass="btn btn-primaryByMe"></asp:Button></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    <div class="modal-footer">
        <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
    </div>
</div>

