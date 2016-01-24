<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProjectDetail.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlProjectDetail" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Project Detail</legend>
        <asp:FormView ID="FVProjectDetail" runat="server" OnModeChanging="FvProjectDetailModeChanging" OnItemUpdating="FvProjectDetailItemUpdating" DefaultMode="ReadOnly" OnDataBound="FvProjectDetailDataBound" Width="100%">
            <ItemTemplate>
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td>Tiltle:</td>
                        <td>
                            <asp:Label ID="TiltleLabel" runat="server" Text='<%# Bind("Tiltle") %>' /></td>
                    </tr>

                    <tr>
                        <td>Description:</td>
                        <td>
                            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>' /></td>
                    </tr>

                    <tr>
                        <td>UploadedFile:</td>
                        <td>
                            <asp:HyperLink ID="UploadedFileLabel" runat="server" Text='<%#Eval("UploadedFile")==null?"No file exist":"Download" %>' NavigateUrl='<%#Eval("UploadedFile")!=null?string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile")):"#" %>' Enabled='<%#Eval("UploadedFile")!=null %>' /></td>

                    </tr>

                    <tr>
                        <td>Status:</td>
                        <td>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>' /></td>
                    </tr>

                    <tr>
                        <td>Proposed By:</td>
                        <td>
                            <asp:Label ID="ProposedByLabel" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetFacultyById(Convert.ToInt32(Eval("ProposedBy"))) %>' /></td>
                    </tr>
                    
                    <tr>
                        <td>Research Group:</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetResearchGroupById(Convert.ToInt32(Eval("researchGroupId"))) %>' /></td>
                    </tr>

                    <tr>
                        <td>Key Features:</td>
                        <td>
                            <asp:Label ID="KeyFeaturesLabel" runat="server" Text='<%# Bind("KeyFeatures") %>' /></td>
                    </tr>

                    <tr>
                        <td>Complexity:</td>
                        <td>
                            <asp:Label ID="ComplexityLabel" runat="server" Text='<%# Bind("Complexity") %>' /></td>
                    </tr>

                    <tr>
                        <td>Efforts Required:</td>
                        <td>
                            <asp:Label ID="EffortsRequiredLabel" runat="server" Text='<%# Bind("EffortsRequired") %>' /></td>
                    </tr>

                    <tr>
                        <td>Domain:</td>
                        <td>
                            <asp:Label ID="DomainLabel" runat="server" Text='<%# Bind("Domain") %>' /></td>
                    </tr>

                    <tr>
                        <td>Required Tools And Technologies:</td>
                        <td>
                            <asp:Label ID="RequiredToolsAndTechLabel" runat="server" Text='<%# Bind("RequiredToolsAndTech") %>' /></td>
                    </tr>
                    <tr>
                        <td>Other detail:</td>
                        <td>
                            <asp:Label ID="SpecialCharactersRequiredLabel" runat="server" Text='<%# Bind("SpecialCharactersRequired") %>' /></td>
                    </tr>
                    <%--<tr><td colspan="2" style="text-align: right"><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" /></td></tr>--%>
                    <tr>
                        <td style="border-right: none">
                            <asp:LinkButton runat="server" ID="lnkAssign" CausesValidation="False" CssClass="left" Text="Assign/UnAssign This Project To Student" OnClick="LnkAssignThisProject"></asp:LinkButton>
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" /></td>
                    </tr>
                </table>
            </ItemTemplate>

            <EditItemTemplate>
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td>Tiltle:</td>
                        <td>
                            <asp:TextBox ID="TiltleTextBox" runat="server" Width="500px" Text='<%# Bind("Tiltle") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TiltleTextBox" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="FVProjectDetail">Title required</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Description:</td>
                        <td>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" Width="500px" Rows="4" Text='<%#Bind("Description") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DescriptionTextBox" ErrorMessage="Description required" ForeColor="Red" ValidationGroup="FVProjectDetail">Description required</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>UploadedFile:</td>
                        <td>
                            <ajaxToolkit:AjaxFileUpload ID="afuProjectDocUploader" runat="server" OnUploadComplete="AfuProjectDocUploaderUploadComplete" />
                            <br />
                            <asp:HyperLink ID="UploadedFileLabel" runat="server" Text='<%#Eval("UploadedFile")!=null?"Already Uploaded File":"No File Exists" %>' NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile")) %>' Enabled='<%#Eval("UploadedFile")!=null %>'/>
                        </td>
                    </tr>
                    <caption>
                        <br />
                    <tr>
                        <td>Status:</td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" ItemType="FYPDAL.KeyValue" DataTextField="Value" DataValueField="Key" SelectMethod="GetProjectStatuses" OnDataBound="BindStatuses">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Status required" ForeColor="Red" InitialValue="Select Status" ValidationGroup="FVProjectDetail">Status required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Proposed By:</td>
                        <td>
                            <asp:DropDownList ID="ddlProposedBy" runat="server" ItemType="FYPDAL.User" DataTextField='Name' DataValueField='UId' SelectMethod="GetFacultyStaffs" OnDataBound="BindProposeBy">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlProposedBy" ErrorMessage="Faculty required" ForeColor="Red" InitialValue="Select Faculty" ValidationGroup="FVProjectDetail">Select Faculty</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>Research Group:</td>
                        <td>
                            <asp:DropDownList ID="ddlgroup" runat="server" ItemType="FYPDAL.ResearchGroup" DataTextField='Title' DataValueField='ResearchId' SelectMethod="GetResearchGroups" OnDataBound="BindResearchGroup">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlgroup" ErrorMessage="Faculty required" ForeColor="Red" InitialValue="Select Researchgroup" ValidationGroup="FVProjectDetail">Select ResearchGroup</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Key Features:</td>
                        <td>
                            <asp:TextBox ID="KeyFeaturesTextBox" runat="server" TextMode="MultiLine" Width="500px" Text='<%#Bind("KeyFeatures") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="KeyFeaturesTextBox" ErrorMessage="Key Features required" ForeColor="Red" ValidationGroup="FVProjectDetail">Key Features required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Complexity:</td>
                        <td>
                            <asp:DropDownList ID="ddlComplexity" OnDataBound="BindComplexities" runat="server" ItemType="FYPDAL.KeyValue" SelectMethod="GetComplexeties" DataTextField="Key" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlComplexity" ErrorMessage="Complexity required" ForeColor="Red" InitialValue="Select Complexity" ValidationGroup="FVProjectDetail">Select Complexity</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Efforts Required:</td>
                        <td>
                            <asp:TextBox ID="EffortsRequiredTextBox" runat="server" TextMode="MultiLine" Width="500px" Text='<%#Bind("EffortsRequired") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="EffortsRequiredTextBox" ErrorMessage="Efforts required" ForeColor="Red" ValidationGroup="FVProjectDetail">Efforts required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Domain:</td>
                        <td>
                            <asp:TextBox ID="DomainTextBox" runat="server" TextMode="MultiLine" Width="500px" Text='<%#Bind("Domain") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DomainTextBox" ErrorMessage="Domain required" ForeColor="Red" ValidationGroup="FVProjectDetail">Domain required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Required Tools And Technologies:</td>
                        <td>
                            <asp:TextBox ID="RequiredToolsAndTechTextBox" runat="server" TextMode="MultiLine" Width="500px" Text='<%#Bind("RequiredToolsAndTech") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="RequiredToolsAndTechTextBox" ErrorMessage="Tools & Technologies required" ForeColor="Red" ValidationGroup="FVProjectDetail">Tools & Technologies required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Other Detail:</td>
                        <td>
                            <asp:TextBox ID="SpecialCharactersRequiredTextBox" runat="server" TextMode="MultiLine" Width="500px" Text='<%#Bind("SpecialCharactersRequired") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="SpecialCharactersRequiredTextBox" ErrorMessage="Special characteristics required" ForeColor="Red" ValidationGroup="FVProjectDetail">Special characteristics required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" ValidationGroup="FVProjectDetail"/>
                            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>

        </asp:FormView>
    </fieldset>
</div>


