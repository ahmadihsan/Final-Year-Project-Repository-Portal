<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewAndAddComments.ascx.cs" Inherits="FYPAutomation.UserControls.Convener.CtrlViewAndAddComments" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>PC Comments : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMileStone" OnSelectedIndexChanged="MileStoneSelectedIndexChanged" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select Milestone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vg">Please select Milestone</asp:RequiredFieldValidator>
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">Project:<asp:Label runat="server" ID="lblProjectName" style="color: #005580; font-weight: normal"></asp:Label>
                    <asp:Label runat="server" ID="lblMileStoneDoc" style="color: #005580; font-weight: bold;float: right"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvdComments" runat="server" CssClass="mytable" Width="100%" EmptyDataText="Not Evalauated yet">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtFinalComment" Width="1022px" Height="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFinalComment" ErrorMessage="Name required" ForeColor="Red" ValidationGroup="vg">Enter Some text</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnComment" runat="server" Text="Submit Comments" OnClick="FinalCommentClicked" CssClass="btn btn-primaryByMe" ValidationGroup="vg" />
                </td>
            </tr>
        </table>

    </fieldset>
</div>
