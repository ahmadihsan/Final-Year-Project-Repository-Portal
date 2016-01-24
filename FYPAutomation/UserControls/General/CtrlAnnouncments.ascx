<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAnnouncments.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlAnnouncments" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Announcments:</legend>

        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddAnnounmcent" OnClick="AddAnnouenmentPopUpClicked" CssClass="mybtn_add" ToolTip="Add New" ValidationGroup="AddNewClicked" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                Please change the session from drop down to view other session's Announcments
                                <asp:DropDownList runat="server" ID="ddlSessionSearch" OnSelectedIndexChanged="SessionSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdAnnouncment" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="mytable" DataKeyNames="AnnId,PSId" OnRowCommand="GvdGvdAnnouncmentRowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Session">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSessionGrid" runat="server" DataTextField="Name" DataValueField="PSId" ItemType="FYPDAL.ProjectSession">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlSessionGrid" ErrorMessage="Please select depratment" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("PSId")!=null?FYPDAL.FrequentAccesses.GetProjectSessionNameById(Convert.ToInt64(Eval("PSId"))): FYPDAL.FrequentAccesses.GetProjectSessionNameById(-1)%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="Title" />
                            <%--<asp:BoundField DataField="Description" HeaderText="Description">
                                <ItemStyle Width="60%" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkFileExistOrNot" runat="server" NavigateUrl='<%#Eval("Upload")!=null?string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("Upload")):"#" %>' Text='<%#Eval("Upload")==null?"No file exist":"Download" %>' Enabled='<%#Eval("Upload") != null %>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit/Detail">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" CommandName="EditRow" ForeColor="#8C4510" runat="server">Edit/Detail</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lbUpdate" CommandName="UpdateRow" ForeColor="#8C4510" runat="server">Update</asp:LinkButton>
                                    <asp:LinkButton ID="lbCancel" CommandName="CancelUpdate" ForeColor="#8C4510" runat="server" CausesValidation="false">Cancel</asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return  confirm('Are you sure! you want to delete this announcement?')">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    </fieldset>


    <div id="AddAnnouncment" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 970px; margin-left: -488px">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Add New Announcment</h5>
        </div>
        <div class="modal-body">
            <table style="width: 100%" class="mytable">
                <tr runat="server" id="secondRow">
                    <td>Announcement for both FYP-I & FYP-II:</td>
                    <td colspan="2">
                        <asp:CheckBox runat="server" ID="cbxBothSession" OnClick="CbxSelectionBothChanged()" />
                    </td>
                </tr>
                <tr runat="server" id="firstRow">
                    <td>Select Session:</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PSId"></asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please select Session" ForeColor="Red" InitialValue="Select Session" ValidationGroup="AddAnouncement">Please select Session</asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>Title:</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtTitle" Width="400px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="AddAnouncement">Title required</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td colspan="2">
                        <%--<asp:TextBox runat="server" ID="txtDesc" Width="400px" TextMode="MultiLine" Height="140px"></asp:TextBox>--%>
                        <CKEditor:CKEditorControl ID="txtDesc" runat="server"></CKEditor:CKEditorControl>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDesc" ErrorMessage="Description required" ForeColor="Red" ValidationGroup="AddAnouncement">Description required</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Upload File:(Optional)</td>
                    <td>
                        <ajaxToolkit:AjaxFileUpload ID="asyUploadFile" runat="server" OnUploadComplete="AsyncDocumentUpload" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAddAnn" runat="server" Text="Add Announcment" OnClick="AddAnnouncmentClick" CssClass="btn btn-primaryByMe" ValidationGroup="AddAnouncement" /></td>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="UpdateAnnouncmentClick" CssClass="btn btn-primaryByMe" ValidationGroup="AddAnouncement" Visible="False" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="CancelAnnouncmentClick" CssClass="btn btn-primaryByMe" Visible="False" Style="height: 26px" />
                    </td>
                </tr>

            </table>
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>
</div>

<script type="text/javascript">
    function CbxSelectionBothChanged() {
        var cbx = document.getElementById('<%= cbxBothSession.ClientID%>');
        var rowToHide = document.getElementById('<%=firstRow.ClientID%>');
        var ddlS = document.getElementById('<%=ddlSession.ClientID%>');
        //alert(cbx);
        if (cbx.checked) {
            ddlS.value = null;
            rowToHide.style.display = "none";
        }
        else {
            rowToHide.style.display = "table-row";
        }
    }
</script>
<%--<script type="text/javascript">
    function DdlAnnouncementTypeChangedScript() {
        var ddType = document.getElementById('<%= ddlType.ClientID %>');
        var index = ddType.selectedIndex;
        var opendate = document.getElementById('openDateRow');
        var closedate = document.getElementById('closedateRow');
        if (index == 1) {
            opendate.style.display = "table-row";
            closedate.style.display = "table-row";
        } else {
            opendate.style.display = "none";
            closedate.style.display = "none";
        }

    }
    function ValidateStartDate(sender, args) {
        var ddType = document.getElementById('<%= ddlType.ClientID %>');
        var index = ddType.selectedIndex;
        var startDate = document.getElementById('<%= cldStartDate.ClientID %>');
        if (index == 1) {
            if (startDate != null && startDate.value != "") {
                args.IsValid = true;
                return;
            } else {
                args.IsValid = false;
                return;
            }
        } else {
            args.IsValid = true;
            return;
        }
        args.IsValid = false;
    }
    function ValidateCloseDate(sender, args) {
        var ddType = document.getElementById('<%= ddlType.ClientID %>');
        var closeDate = document.getElementById('<%= cldCloseDate.ClientID %>');
        var index = ddType.selectedIndex;
        if (index == 1) {
            if (closeDate != null && closeDate.value != "") {
                args.IsValid = true;
                return;
            } else {
                args.IsValid = false;
                return;
            }
        } else {
            args.IsValid = true;
            return;
        }
        args.IsValid = false;
    }

</script>--%>
