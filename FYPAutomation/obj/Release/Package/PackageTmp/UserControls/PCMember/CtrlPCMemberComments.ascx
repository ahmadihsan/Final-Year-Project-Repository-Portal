<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPCMemberComments.ascx.cs" Inherits="FYPAutomation.UserControls.PCMembers.CtrlPCMemberComments" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Selection Criteria for Comments : </legend>
        <table class="mytable" style="width: 100%">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                Session:
                        <asp:DropDownList ID="ddlSession" runat="server" DataValueField="PSId" DataTextField="Name" AutoPostBack="True">
                        </asp:DropDownList>
                            </label>
                        </div>

                        <div class="ButtonNavigations">
                            <label>
                                    <asp:TextBox runat="server" ID="txtByProjectName" PlaceHolder="Search by Project Name" onkeyup = "SetContextKey()"/>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtByProjectName" ServiceMethod="SearchProjectBySessionId" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                                </label>
                        </div>

                        <div class="ButtonNavigations">
                            <label>
                                Milestone:
                    <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId">
                    </asp:DropDownList>
                            </label>
                        </div>

                        <div class="ButtonNavigations">
                            <label>
                                <asp:Button runat="server" ID="btnEvaluate" OnClick="EvaluationClicked" CssClass="btn btn-primaryByMe" ToolTip="Evaluate" Text="Evaluate" />
                            </label>
                            <asp:HiddenField ID="hfEvaludateClicked" runat="server" Visible="False" />
                        </div>
                    </div>
            </tr>
        </table>
        <asp:Table ID="tblStudents" runat="server" CssClass="mytable" Width="100%"></asp:Table>
        <table>
            <%--<tr id="txtProj" runat="server">
                <td>About Project:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtProjectComment" Width="800px" Height="150px"/>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Button runat="server" ID="SubmittComments" Style="margin: 10px 40px;" OnClick="SubmitClicked" Text="Submit" CssClass="btn btn-primaryByMe" />
                </td>
            </tr>
        </table>
    </fieldset>

</div>

<script type = "text/javascript">
    function SetContextKey() {
        $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=ddlSession.ClientID %>").value);
    }
</script>
