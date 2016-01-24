<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUploadResourceDoc.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlUploadResourceDoc" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Upload Document:</legend>
        <table style="width: 100%">
            
            <tr>
                <td>Select Session:</td>
                <td>
                    <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PSId"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please select Session" ForeColor="Red" InitialValue="Select Session" ValidationGroup="vgRegisterFac">Please select Session</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Title:</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title Required" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please write the Title</asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>Upload File:</td>
                <td>
                    <ajaxToolkit:AjaxFileUpload ID="asyUploadFile" runat="server" OnUploadComplete="AsyncDocumentUpload" AllowedFileTypes="docx,doc,pdf,xlsx,xls,ppt,pptx" />
                </td>
            </tr>


            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSumbitDoc" runat="server" Text="Submit Document" OnClick="SubmitDocument" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegisterFac" OnClientClick="return confirm('Are you sure that you have selected correct session?')" /></td>
            </tr>
        </table>
    </fieldset>


</div>
