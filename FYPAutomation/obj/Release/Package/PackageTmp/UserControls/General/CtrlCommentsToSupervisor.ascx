<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommentsToSupervisor.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlCommentsToSupervisor" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Project Commitee Comments : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMileStone" OnSelectedIndexChanged="MileStoneSelectedIndexChanged" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlProjects" OnSelectedIndexChanged="ProjectSelectedIndexChanged" DataTextField="Tiltle" DataValueField="PId" AutoPostBack="True" />
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <asp:ListView ID="lstComments" runat="server" ItemPlaceholderID="plItems">
                        <LayoutTemplate>
                            <table style="width: 100%" class="mytable">
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="plItems"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <th>
                                <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("Tiltle") %>'></asp:Label>
                            </th>
                            <tr>
                                <td style="font-weight: bold">Milestone Document:
                                    <asp:Label ID="lblMileStoneName" runat="server" Text='<%# Bind("Name") %>' style="color: #005580"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">Comment:
                                    <asp:Label ID="lblComments" runat="server" Text='<%# Bind("CommentByHead") %>' style="color: #005580; font-weight: normal"></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
