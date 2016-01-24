<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomsManager.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlRoomsManager" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Rooms For Presentations:</legend>

        <table style="width: 100%" class="mytable">
           <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnRooms" OnClick="AddRoomsClickedToShowPopUp" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr> 
            <tr>
                <td>
                    <asp:GridView ID="GvdRooms" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="mytable" DataKeyNames="RoomId" DataSourceID="EdRooms" >
                        <Columns>

                            <asp:BoundField DataField="RoomId" HeaderText="RoomId" ReadOnly="True" SortExpression="RoomId" Visible="False" ItemStyle-Width="50%"/>
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:EntityDataSource ID="EdRooms" runat="server" ConnectionString="name=FYPEntities" DefaultContainerName="FYPEntities" EnableDelete="True" EnableFlattening="False" EnableUpdate="True" EntitySetName="RoomsForPresentations">
                    </asp:EntityDataSource>
                </td>
            </tr>
        </table>

    </fieldset>


    <div id="AddDeadLine" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 590px">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Add New Rooms</h5>
        </div>
        <div class="modal-body">
            <table style="width: 100%" class="mytable">
                <tr runat="server" id="lbll">
                    <td>Enter Room Number:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRoom" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRoom" ErrorMessage="Please select Room" ForeColor="Red" ValidationGroup="vgRegisterFac">Please Enter Room Number/Name</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                <td>
                    <asp:Button ID="btnAddRoom" runat="server" Text="Add Room" OnClick="AddRoomClicked" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegisterFac" /></td>
                <td></td>
            </tr>
            </table>
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>
</div>




