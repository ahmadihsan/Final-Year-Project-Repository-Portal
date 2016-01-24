<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBulkAdExternal.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlBulkAdExternal" %>
<style type="text/css">
    .auto-style1 {
        height: 26px;
    }
    .auto-style2 {
        height: 26px;
        width: 242px;
    }
    .auto-style3 {
        width: 242px;
    }
</style>
<script type="text/javascript">
    function OnUploadComplete() {
        var btnHidden = document.getElementById('<%=btnHidden.ClientID%>');
        btnHidden.click();
    }
</script>
<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Upload User Info:</legend>
        <table style="width: 100%">

            <tr>
                <td class="TitleTd">Upload File :</td>
                <td>
                    <table style="width: 80%">
                        <tr>
                            <td>
                                <ajaxToolkit:AjaxFileUpload ID="afuUploader"
                                    ThrobberID="myThrobber"
                                    ContextKeys="fred"
                                    AllowedFileTypes="xlsx,xls"
                                    MaximumNumberOfFiles="1"
                                    Width="100%"
                                    OnUploadComplete="afuUploader_UploadComplete"
                                    runat="server" OnClientUploadCompleteAll="OnUploadComplete" />
                                <p style="color: red">only file of type (xlsx,xls)</p>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:Label ID="lblUploadedDataMessage" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="TitleTd" colspan="4">
                    <asp:GridView ID="GdvBulkExternalUploadsValidData" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 98%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">

                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# ((GridViewRow)Container).RowIndex + 1%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                             <asp:BoundField DataField="E_Specialization" HeaderText="Specialization" />   
                            <asp:BoundField DataField="E_ContactAddresss" HeaderText="Office Address" /> 
                             <asp:BoundField DataField="E_Office" HeaderText="Office Contact Number" />
                             <asp:BoundField DataField="E_CNIC" HeaderText="CNIC" />  
                                    
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>

        </table>
    </fieldset>
    <fieldset class="FieldSet">
        <legend>Other</legend>
        <table style="width: 100%">
            <tr>
                <td class="auto-style2">Role : </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlRole" runat="server" DataTextField="Name" DataValueField="Rid" EnableViewState="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRole" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Role" ValidationGroup="vgRegister">Please select role</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <asp:Button ID="btnHidden" Text="Hidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Department :</td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="DId" EnableViewState="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please select depratment" ForeColor="Red" InitialValue="Select Department" ValidationGroup="vgRegister">Please select depratment</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
        </table>
    </fieldset>

    <table style="width: 99%">
        <tr>
            <td class="TitleTd"></td>
            <td></td>
            <td></td>
            <td class="TextAlignRight">
                <asp:Button ID="btnRegisterBulkExternal" CssClass="btn btn-primaryByMe" runat="server" Text="Register Valid Records" OnClick="btnRegisterBulkExternal_Click" ValidationGroup="vgRegister" />
                &nbsp;<asp:HyperLink ID="HyDownloadInvalidExcelData" CssClass="btn btn-primaryByMe" runat="server" NavigateUrl="../../Pages/General/ExcelDownload.aspx">Download Invalid Records</asp:HyperLink>

            </td>
        </tr>
        <tr>
            <td class="TitleTd"></td>
            <td></td>
            <td></td>
            <td class="TextAlignRight"></td>
        </tr>
    </table>

</div>