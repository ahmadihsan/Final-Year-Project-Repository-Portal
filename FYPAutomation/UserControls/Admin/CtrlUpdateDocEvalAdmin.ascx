<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUpdateDocEvalAdmin.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlUpdateDocEvalAdmin" %>

<style type="text/css">
    .auto-style2 {
        width: 230px;
    }

    .auto-style3 {
        width: 222px;
    }

    .auto-style4 {
        width: 131px;
    }

    .auto-style5 {
        width: 134px;
    }
</style>

<div>

    <fieldset class="FieldSet">

        <legend>Evaluation of Document: </legend>



        <table style="width: 100%" runat="server" id="tblStudentEvaluation" class="mytable">
            <tr>
                <td class="auto-style4">
                    <h5>Project Title:</h5>
                </td>
                <td>
                    <asp:Label ID="lblProjectTitle" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">
                    <h5>Supervised By:</h5>
                </td>
                <td>
                    <asp:Label ID="lblSuperviserName" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">
                    <h5>Group Members:</h5>
                </td>
                <td>
                    <asp:Label ID="lblGroupMembers" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <h5>Select Parameters</h5>
                </td>
                <td rowspan="9" colspan="4" class="auto-style3">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div style="background-color: ThreeDFace; width: 608px;">
                                Enter Text:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="doctext" runat="server" Height="40px" Width="375px"></asp:TextBox>
                                &nbsp;<br />
                                Enter Page No.
                                <asp:TextBox ID="PageNum" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                              <asp:Button ID="AddText" runat="server" CssClass="btn btn-primaryByMe" Text="Add Text" OnClick="AddText_Click" Height="42px" />
                            </div>
                            <iframe id="docPreview" style="width: 600px; height: 1000px;" runat="server"></iframe>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>Milestone:</td>
                <td class="auto-style2">                   
                    <asp:Label ID="lblMileStone" runat="server"></asp:Label>
                    <br />
                </td>

            </tr>
            <tr>
                <td>Document:</td>
                <td class="auto-style2">
                    <asp:DropDownList runat="server" ID="ddlDocumentSelection" ClientIDMode="Static" AutoPostBack="true" DataTextField="UploadedFile" DataValueField="UMSId" OnSelectedIndexChanged="ddlDocumentSelection_SelectedIndexChanged" /><%--<label id="lblddlD" style="color:red" runat="server"></label>--%>
                    <br />
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <h5>Evaluate Students:</h5>
                    <asp:Label runat="server" ID="lblStudents"></asp:Label>
                </td>

            </tr>
            <tr>
                <td>Total Marks:</td>
                <td class="auto-style2">
                   <%-- <asp:TextBox runat="server" ID="txtTotalMarks"></asp:TextBox><label id="lbltxtTotalMarks" runat="server" style="color:red;"></label>--%>
                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                    <br />
                    <br />
                </td>

            </tr>
            <tr>
                <td>Obtain Marks:</td>
                <td class="auto-style2">
                    <asp:TextBox runat="server" ID="txtObtainMarks"></asp:TextBox><%--<label id="lbltxtObtainMarks" runat="server" style="color:red"></label>--%>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>Comments for Students:</td>
                <td class="auto-style2">

                    <textarea id="txtComment" name="Comment" style="height: 68px; width: 260px" runat="server"></textarea></td>
            </tr>
            <tr>
                <td>Project Comments:</td>

                <td class="auto-style2">
                    <textarea id="txtCommentProj" name="Comment" style="height: 68px; width: 260px" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td>Select  Verdict:</td>

                <td style="border: none" id="btnVerdictRadio">

                    <asp:RadioButtonList ID="rbtnVerdict" runat="server">
                        <asp:ListItem>Pass</asp:ListItem>
                        <asp:ListItem>Pass with Minner Changes</asp:ListItem>
                        <asp:ListItem>Major Revision</asp:ListItem>
                        <asp:ListItem>Fail</asp:ListItem>
                    </asp:RadioButtonList>
                </td>

            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style2">
                    <asp:Button ID="btnUpdateEvaluationt" runat="server" Text="Update" OnClick="btnUpdateEvaluationt_Click" CssClass="btn btn-primaryByMe" /></td>
            </tr>


        </table>
    </fieldset>

</div>
<asp:Label runat="server" ID="Marks" Text="Marks: " Font-Bold="true" Visible="false"></asp:Label>
<asp:Label runat="server" ID="CommentsStudent" Text="Comments to " Font-Bold="true" Visible="false"></asp:Label>
<asp:Label runat="server" ID="CommentsaboutProc" Text="Comments about Project: " Font-Bold="true" Visible="false"></asp:Label>
<asp:Label runat="server" ID="Verdict" Text="Verdict: " Font-Bold="true" Visible="false"></asp:Label>