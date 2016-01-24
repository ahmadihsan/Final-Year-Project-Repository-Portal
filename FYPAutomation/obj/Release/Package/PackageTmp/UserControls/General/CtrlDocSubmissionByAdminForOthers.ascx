<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDocSubmissionByAdminForOthers.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlDocSubmissionByAdminForOthers" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Sumbit Document:</legend>
        <table style="width: 100%">

            <tr>
                <td>Select Session:</td>
                <td>
                    <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PSId"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select Session</asp:RequiredFieldValidator>
                    </td>
            </tr>
            
            
            <tr>
                <td>Select Supervisor:</td>
                <td>
                    <asp:DropDownList ID="ddlSupervisor" runat="server" DataTextField="Name" DataValueField="UId" AutoPostBack="True" OnSelectedIndexChanged="DdlSupervisorIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select Supervisor" ForeColor="Red" InitialValue="Select Supervisor" ValidationGroup="vgRegisterFac">Please select Supervisor</asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>Select Project:</td>
                <td>
                    <asp:DropDownList ID="ddlProjects" runat="server" DataTextField="Tiltle" DataValueField="PId" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="DdlProjectsSelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select Projects</asp:RequiredFieldValidator>    
                </td>
            </tr>
            
            <tr>
                <td>Select MileStone:</td>
                <td>
                    <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="DdlMileStoneSelectedIndexChanged" Enabled="False"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select MileStone</asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>Comment :</td>
                <td><asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Width="557px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtComment" ForeColor="Red"  ValidationGroup="vgRegisterFac">Please Write Comment</asp:RequiredFieldValidator>
                </td>
            </tr>

            

            <tr>
                <td>Upload File:</td>
                <td>
                    <ajaxToolkit:AjaxFileUpload ID="asyUploadFile" runat="server" OnUploadComplete="AsyncDocumentUpload" />
                </td>
            </tr>


            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSumbitDoc" runat="server" Text="Submit Document" OnClick="SubmitDocument" CssClass="btn btn-primaryByMe" OnClientClick="return ConfirmMe()" ValidationGroup="vgRegisterFac" /></td>
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