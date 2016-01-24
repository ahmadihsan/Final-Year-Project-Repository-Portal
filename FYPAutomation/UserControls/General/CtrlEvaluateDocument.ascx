<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEvaluateDocument.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlEvaluateDocument" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    .auto-style6 {
        height: 74px;
    }
    .auto-style7 {
        width: 230px;
        height: 74px;
    }
</style>

<div>

    <fieldset class="FieldSet">

        <legend>Evaluation of Document: </legend>



        <table style="width: 100%" runat="server" id="tblStudentEvaluation"  class="mytable">
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
                <td rowspan="10" colspan="4" class="auto-style3">
                   
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                          <div style="background-color:ThreeDFace; width: 608px;">
                              Enter Text:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="doctext" runat="server" Height="40px" Width="349px"></asp:TextBox>
                              <asp:Button ID="AddText" runat="server" CssClass="btn btn-primaryByMe" Text="Add Text" OnClick="AddText_Click" Height="42px" Width="81px" />
                              <br />
                              Select Image&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:DropDownList ID="ddlImageName" runat="server" ClientIDMode ="Static" Height="30px" Width="194px">
                              </asp:DropDownList>
                             
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             
                               <asp:Button ID="AddImage" runat="server" CssClass="btn btn-primaryByMe" Text="Add Image" OnClick="AddImage_Click" Height="42px" Width="88px" />
                              <br /> Enter Page No.&nbsp;&nbsp; <asp:TextBox ID="PageNum" runat="server" Height="23px" Width="179px"></asp:TextBox>
                              &nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                          </div>
                          <iframe id="docPreview" style="width:600px; height: 700px; " runat="server"></iframe>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>Milestone:</td>
                <td class="auto-style2">
                    <%--<asp:DropDownList runat="server" ID="ddlMilestoneSelection" ClientIDMode="Static" DataTextField="Name" AutoPostBack="true" DataValueField="PMSId"  OnSelectedIndexChanged="ddlMilestoneSelection_SelectedIndexChanged" Height="29px" Width="212px" /><br />--%>
                    <asp:Label id="lblddlMilstone"    runat="server"></asp:Label>
                    <br />
                </td>

            </tr>
            <tr>
                <td class="auto-style6">Select Document:</td>
                <td class="auto-style7">
                    <asp:DropDownList runat="server" ID="ddlDocumentSelection" ClientIDMode ="Static" AutoPostBack="true" DataTextField="UploadedFile" DataValueField="UMSId" OnSelectedIndexChanged="ddlDocumentSelection_SelectedIndexChanged" Height="29px" Width="216px" /><%--<label id="lblddlD" style="color:red" runat="server"></label>--%>
                    <br />
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <h5>Evaluate Students:</h5>
                    <asp:Label runat="server" ID="lblStudents"></asp:Label>
                </td>

            </tr>
           <%--  <tr>
                        <td>Select Date:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDateSelection" CssClass="datepick" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="PresentationDateTextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtDateSelection" Text="Please Select Date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>--%>
            <tr>
                <td>Total Marks:</td>
                <td class="auto-style2">
                    <%--<asp:TextBox runat="server" ID="txtTotalMarks" Width="226px"></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTotalMarks" ErrorMessage="Only  Numbers  are allowed!" ForeColor="Red" ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>--%>
                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                    <br />
                </td>

            </tr>
            <tr>
                <td>Obtain Marks:</td>
                <td class="auto-style2">
                    <asp:TextBox runat="server" ID="txtObtainMarks" Width="223px"></asp:TextBox><%--<label id="lbltxtObtainMarks" runat="server" style="color:red"></label>--%>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtObtainMarks" ErrorMessage="Only Numbers are allowed!" ForeColor="Red" ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>
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
           <%-- <tr>
                <td>
                    <asp:Table ID="tblStudentEval" runat="server" ></asp:Table>
                </td>
            </tr>--%>
            <tr>
                <td>Select  Verdict:</td>

                <td style="border:none" id="btnVerdictRadio">
                    <%--<label id="lblRadio" style="color:red" runat="server"></label>--%>
                    <asp:RadioButtonList ID="rbtnVerdict" runat="server">
                        <asp:ListItem>Pass</asp:ListItem>
                        <asp:ListItem>Pass with Minner Changes</asp:ListItem>
                        <asp:ListItem>Major Revision</asp:ListItem>
                        <asp:ListItem>Fail</asp:ListItem>
                    </asp:RadioButtonList>                    
                </td>

            </tr>
            <tr>
                <td>

                </td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style2">
                    <asp:Button ID="btnSubmitEvaluationt" runat="server" Text="Submit" OnClick="BtnSubmitEvaluation" CssClass="btn btn-primaryByMe" /></td>
            </tr>
            

        </table>






    </fieldset>

</div>

<asp:Label runat="server" ID="CommentsStudent" Text="Comments to " Font-Bold="true" Visible="false"></asp:Label>
<asp:Label  runat="server" ID="CommentsaboutProc" Text="Comments about Project: " Font-Bold="true" Visible="false"></asp:Label>
<asp:Label runat="server" ID="Verdict" Text="Verdict: " Font-Bold="true" Visible="false"></asp:Label>
<%--<script type="text/javascript">

    //window.onload = function () {
    //    var lblddM = document.getElementById('lblddlMilstone');

    //    lblddM.textContent = "Please Select Milstone!";
    //}
    //var lblddM = document.getElementById('lblddlMilstone');
    ////var ddlM = document.getElementById('ddlMilestoneSelection');
    ////var selectedVal = ddlM.options[ddlM.selectedIndex].value;
    //function update() {
    //    if (lblddM.textContent != "") {
    //        //&& selectedVal == "Select MileStone"
    //        lblddM.textContent = "";

    //    }
    //    //else {
    //    //lblddM.textContent = "Please Select Milstone!";

    //    //}
    //}
    //update();
    //setInterval(update, 1000);

</script>--%>