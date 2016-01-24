<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlStudentDocumentSumbission.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlStudentDocumentSumbission" %>

<style type="text/css">
    .btn-primaryByMe {}
</style>
<div>
<fieldset class="FieldSet">
        <legend>Sumbitte Document For Evaluation:</legend>

        <table style="width: 100%">
            <tr>
                <td>Supervisor Name:</td>
                <td>
                    
                    <asp:Label ID="lblSup" runat="server" ></asp:Label>
                    
                </td>
            </tr>

            <tr>
                <td>Project Name:</td>
                <td>
                    <asp:Label ID="lblProjects" runat="server"></asp:Label>
                   
                    </td>
            </tr>

            <tr>
                <td>Select MileStone:</td>
                <td>
                    <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="DdlMileStoneSelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" >Please select MileStone</asp:RequiredFieldValidator></td>
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
                    <asp:Button ID="btnSumbitDoc" runat="server" Text="Submit Document" OnClick="SubmitDocument" CssClass="btn btn-primaryByMe" OnClientClick="return ConfirmMe()" Width="146px" /></td>
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