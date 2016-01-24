<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlGenerateReport.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlGenerateReport" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Generate Report : </legend>
        <asp:MultiView runat="server" ID="mvReportGenerator">
            <asp:View runat="server" ID="vwTakeParams">
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td colspan="2">
                            <h4>Step 1 - Select Parameters</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>Select Session:</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlSessionSelection" DataTextField="Name" DataValueField="PSId" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddlSessionSelection" InitialValue="Select Session" Text="Please Select Session" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Select Milestone:</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlMilestoneSelection" DataTextField="Name" DataValueField="PMSId" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="ddlMilestoneSelection" InitialValue="Select MileStone" Text="Please Select Milestone" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="btnGoToStep2" runat="server" Text="Next >>" OnClick="BtnGoToStep2Clicked" CssClass="btn btn-primaryByMe" />
                        </td>
                    </tr>
                </table>
            </asp:View>

            <asp:View runat="server" ID="vwReport">
                <table style="width: 800px">
                    <tr>
                        <td>
                            <div id="Search" style="float: right">
                                <div class="ButtonNavigations">
                                    <label>
                                        <asp:Button runat="server" ID="btnExport" OnClick="BtnExportToExcelClicked" Text="Export to Excel" CssClass="btn btn-primaryByMe" />
                                    </label>
                                </div>
                            </div>
                            <%--<div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMileStoneSearch" OnSelectedIndexChanged="MileStoneSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSessionSearch" OnSelectedIndexChanged="SessionSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                    </div>
                    <div class="clearall"></div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="overflow: scroll">
                            <div style="width: 1055px">
                                <asp:GridView ID="gvdReports" runat="server" CssClass="mytable" Width="100%" EmptyDataText="Not Data Exists yet">
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </fieldset>
</div>

