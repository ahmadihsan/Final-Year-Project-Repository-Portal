<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddProject.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlAddProject" %>
<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Add Project</legend>
        <table style="width: 100%" class="mytable">

            <tr>
                <td class="TitleTd">Select Session:</td>
                <td>
                    <asp:DropDownList ID="ddlProjectSession" runat="server" DataTextField="Name" DataValueField="PSId">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlProjectSession" ErrorMessage="Session required" ForeColor="Red" InitialValue="Select Session">Please Select Session</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

           
            <tr>
                <td class="TitleTd">Project Title :</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title required" ForeColor="Red">Title required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Proposed By : </td>
                <td>
                    
                     <asp:Label ID="SupervisorName" runat="server" ForeColor="#0033CC"></asp:Label>
                    
                     </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Research Group Name : </td>
                <td>
                    <asp:DropDownList ID="ddlResearchGroup" runat="server" DataTextField="Title" DataValueField="ResearchId">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlResearchGroup" ErrorMessage="Research Group Name required" ForeColor="Red" InitialValue="Select ResearchGroup">Please Select Research Group</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Brief Description of Scope : </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="500px" Height="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description required" ForeColor="Red">Description required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Key Features : </td>
                <td>
                    <asp:TextBox ID="txtKeyFeatures" runat="server" Width="500px" Height="150px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtKeyFeatures" ErrorMessage="Key Features required" ForeColor="Red">Key Features required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Complexity : </td>
                <td>
                    <asp:DropDownList ID="ddlComplexity" runat="server">
                        <asp:ListItem>Select Complexity</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlComplexity" ErrorMessage="Complexity required" ForeColor="Red" InitialValue="Select Complexity">Please Select Complexity</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Efforts Required : </td>
                <td>
                    <asp:TextBox ID="txtEffortsRequired" runat="server" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEffortsRequired" ErrorMessage="Efforts required" ForeColor="Red">Efforts required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Domain :</td>
                <td>
                    <asp:TextBox ID="txtDomain" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDomain" ErrorMessage="Domain required" ForeColor="Red">Domain required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Required Tools and Technologies :</td>
                <td>
                    <asp:TextBox ID="txtReqAndTech" runat="server" TextMode="MultiLine" Width="500px" Height="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtReqAndTech" ErrorMessage="Tools & Technologies required" ForeColor="Red">Tools & Technologies required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Special Characteristics Required :</td>
                <td>
                    <asp:TextBox ID="txtSpecialCharReq" runat="server" TextMode="MultiLine" Width="500px" Height="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtSpecialCharReq" ErrorMessage="Special characteristics required" ForeColor="Red">Special characteristics required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Upload Document :</td>
                <td>
                    <ajaxToolkit:AjaxFileUpload ID="AfuProjectDoc" runat="server" AllowedFileTypes="docx,doc,pdf,xlsx,xls,ppt,pptx" ContextKeys="fred" MaximumNumberOfFiles="1"  OnUploadComplete="AfuProjectDoc_UploadComplete" ThrobberID="myThrobber" />(optional)<br/>
                    <p style="color: red">only file of type (docx,doc,pdf,xlsx,xls)</p>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAddProject" CssClass="btn btn-primaryByMe" runat="server" Width="100px" OnClick="btnAddProject_Click" Text="Add Project" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
</div>
