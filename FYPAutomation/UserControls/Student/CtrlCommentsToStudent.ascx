<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommentsToStudent.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlCommentsToStudent" %>


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
                                    <asp:Label ID="lblMileStoneName" runat="server" Text='<%# Bind("projectMileName") %>' Style="color: #005580"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">Comments By <asp:Label ID="lblCommentBy" runat="server" Text= '<%# Bind("RoleName") %>'></asp:Label>:  <asp:Label runat="server" Text='<%# Bind("Name") %>' ID="lblSN" Style="color:blue"></asp:Label><br />
                            <asp:Label ID="lblCommentsSup" runat="server" Text='<%# Bind("CommentBySupervisor") %>' Style="color: #005580; font-weight: normal" ></asp:Label>
                           <asp:Label ID="lblCommentsConvener" runat="server" Text='<%# Bind("CommentedByPCHead") %>' Style="color: #005580; font-weight: normal" ></asp:Label>
                           <asp:Label ID="lblCommentsExt" runat="server" Text='<%# Bind("CommentByExternal") %>' Style="color: #005580; font-weight: normal" ></asp:Label>
                           <asp:Label ID="lblComments" runat="server" Text='<%# Bind("CommentByHead") %>' Style="color: #005580; font-weight: normal" ></asp:Label>
                                <asp:Label ID="lblCommentsPC" runat="server" Text='<%# Bind("CommentByPC") %>' Style="color: #005580; font-weight: normal" ></asp:Label><br />
                                Project Comments: <asp:Label ID="lblCommentsProc" runat="server" Text='<%# Bind("CommentByPcAboutProject") %>' Style="color: #005580; font-weight: normal" ></asp:Label>
                                <br />   Obtain Marks:  <asp:Label ID="lblObtainMarks" runat="server" Text='<%# Bind("ObtainMarks") %>' Style="color: #005580; font-weight: normal" ></asp:Label>/10
                                </td>
                            </tr>
                            
                        </ItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
