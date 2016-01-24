<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUploadDocument.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlUploadDocument" %>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Sumbit Document For Evaluation:</legend>
        <table style="width: 50%">

            <%--<tr>
                <td>Select Session:</td>
                <td>
                    <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" OnSelectedIndexChanged="DdlSessionChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select Session" ValidationGroup="vgRegisterFac">Please select Session</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Select Project:</td>
                <td>
                    <asp:DropDownList ID="ddlProjects" runat="server" DataTextField="Tiltle" DataValueField="PId" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Please select Project" ForeColor="Red" InitialValue="Select Project" ValidationGroup="vgRegisterFac">Please select Projects</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Select MileStone:</td>
                <td>
                    <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="DdlMileStoneSelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select MileStone</asp:RequiredFieldValidator></td>
            </tr>--%>

           <tr>
                <td>Upload File:</td>
                <td>
                    <ajaxToolkit:AjaxFileUpload ID="asyUploadFile" runat="server" OnUploadComplete="AsyncDocumentUpload" AllowedFileTypes="docx,doc,pdf,xlsx,xls,ppt,pptx" />
                </td>
            </tr>


            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSumbitDoc" runat="server" Text="Submit Document" OnClick="SubmitDocument" CssClass="btn btn-primaryByMe" OnClientClick="return ConfirmMe()" /></td>
            </tr>
        </table>


    </fieldset>
    </div>

<script type="text/javascript">
    function ConfirmMe() {
        if (Page_ClientValidate())
            return confirm('Are you sure that you have selected the correct milestone and files ?');

        return false;
    }
</script>

