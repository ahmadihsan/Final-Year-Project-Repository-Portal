<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMyRemarksPC.ascx.cs" Inherits="FYPAutomation.UserControls.PCMember.CtrlMyRemarksPC" %>

<style type="text/css">
    .alignRight
    {
        float:right;
    }
</style>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Evaluation Remarks : </legend>
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
                                <asp:HyperLink ID="hplUpdate" runat="server" Text="Update Remarks" NavigateUrl='<%#"~/Pages/PCMember/UpdateDocEvalPC.aspx?project=" + Eval("Tiltle") + "&Doc="+ Eval("projectMileName")%>' CssClass="alignRight" />
                            </th>
                            <tr>
                                <td style="font-weight: bold">Milestone Document:
                                    <asp:Label ID="lblMileStoneName" runat="server" Text='<%# Bind("projectMileName") %>' Style="color: #005580"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">Comments By <asp:Label ID="lblCommentBy" runat="server" Text= '<%# Bind("RoleName") %>'></asp:Label>:  <asp:Label runat="server" Text='<%# Bind("Name") %>' ID="lblSN" Style="color:blue"></asp:Label><br />
                            
                                    <asp:Label ID="lblCommentsExt" runat="server" Text='<%# Bind("CommentByPC") %>' Style="color: #005580; font-weight: normal" ></asp:Label><br />
                                    Comments about Project: <asp:Label ID="lblCommentsProc" runat="server" Text='<%# Bind("CommentByPcAboutProject") %>' Style="color: #005580; font-weight: normal" ></asp:Label><br />
                                    Obtain Marks: <asp:Label ID="lblObtainMarks" runat="server" Text='<%# Bind("ObtainMarks") %>' Style="color: #005580; font-weight: normal" ></asp:Label>
                                </td>
                            </tr>
                            
                        </ItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
    </fieldset>
</div>