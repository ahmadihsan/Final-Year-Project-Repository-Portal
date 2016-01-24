<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLogin.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlLogin" %>
<script type="text/javascript">
    var SlideWidth = 400;
    var SlideSpeed = 250;

    $(document).ready(function () {
        // set the prev and next buttons display
        SetNavigationDisplay();
    });

    function CurrentMargin() {
        // get current margin of slider
        var currentMargin = $("#slider-wrapper").css("margin-left");

        // first page load, margin will be auto, we need to change this to 0
        if (currentMargin == "auto") {
            currentMargin = 0;
        }

        // return the current margin to the function as an integer
        return parseInt(currentMargin);
    }

    function SetNavigationDisplay() {
        // get current margin
        var currentMargin = CurrentMargin();

        // if current margin is at 0, then we are at the beginning, hide previous
        if (currentMargin == 0) {
            $("#PreviousButton").hide();
        }
        else {
            $("#PreviousButton").show();
        }

        // get wrapper width
        var wrapperWidth = $("#slider-wrapper").width();

        // turn current margin into postive number and calculate if we are at last slide, if so, hide next button
        if ((currentMargin * -1) == (wrapperWidth - SlideWidth)) {
            $("#NextButton").hide();
        }
        else {
            $("#NextButton").show();
        }
    }

    function NextSlide() {
        // get the current margin and subtract the slide width
        var newMargin = CurrentMargin() - SlideWidth;

        // slide the wrapper to the left to show the next panel at the set speed. Then set the nav display on completion of animation.
        $("#slider-wrapper").animate({ marginLeft: newMargin }, SlideSpeed, function () { SetNavigationDisplay() });
    }

    function PreviousSlide() {
        // get the current margin and subtract the slide width
        var newMargin = CurrentMargin() + SlideWidth;

        // slide the wrapper to the right to show the previous panel at the set speed. Then set the nav display on completion of animation.
        $("#slider-wrapper").animate({ marginLeft: newMargin }, SlideSpeed, function () { SetNavigationDisplay() });
    }
   
</script>
<style type="text/css">

    #container {
        width: 400px;
        overflow: hidden;
        margin-left:69%;
        margin-top:10%;
        background-color:darkgrey;
        color-interpolation:auto;
    }

    #slider-wrapper {
        width: 800px;
    }

    .slide {
        width: 400px;
        height: 200px;
        overflow: hidden;
        float: left;
    }
    
</style>

<div id="container">
    <div id="slider-wrapper">

         <div class="slide" id="2">
            <asp:Panel DefaultButton="btnLoginFac" runat="server">
                <fieldset class="FieldSet">
                    <legend>Faculty Login : </legend>
                    <table style="width: 100%">

                        <tr>
                            <td class="TitleTd">Email: </td>
                            <td>
                                <asp:TextBox ID="txtboxEmailFac" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailSFac" runat="server" ControlToValidate="txtboxEmailFac" ErrorMessage="Email required" ForeColor="Red" Display="Dynamic" ValidationGroup="vgLoginFac">*</asp:RequiredFieldValidator><br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorFac" runat="server" ControlToValidate="txtboxEmailFac" ErrorMessage="Invalid Email ID!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgLoginFac"></asp:RegularExpressionValidator>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="TitleTd">Password: </td>
                            <td>
                                <asp:TextBox ID="txtBoxPwdFac" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPwdFac" runat="server" ControlToValidate="txtBoxPwdFac" ErrorMessage="Please Enter Password" ForeColor="Red" Display="Dynamic" ValidationGroup="vgLoginFac">*</asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="TitleTd">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnLoginFac" CssClass="btn btn-primaryByMe" runat="server" Text="Login" Width="100px" OnClick="btnLoginFac_Click" ValidationGroup="vgLoginFac" />
                                <asp:Label runat="server" ID="lblLogFac" ForeColor="Red"></asp:Label>
                                <br />

                            </td>
                            <td></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="TitleTd">&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="linkFac" runat="server" OnClick="LnkForgotPasswordClicked">Forgot Password</asp:LinkButton>
                            </td>
                            <td></td>
                            <td>&nbsp;</td>
                        </tr>
                        
                    </table>
                    
                </fieldset>
            </asp:Panel>
        </div>       

        <div id="1" class="slide">
            <asp:Panel runat="server" DefaultButton="btnLogin">
            <fieldset class="FieldSet">
                <legend>Student Login : </legend>
                <table style="width: 100%">

                    <tr>
                        <td class="TitleTd">Email/Reg No : </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" ForeColor="Red" Display="Dynamic" ValidationGroup="vgLogin">*</asp:RequiredFieldValidator>
                            <%--&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidatorStu" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email ID!" ForeColor="Red" ValidationExpression="" ValidationGroup="vgLogin"></asp:RegularExpressionValidator>--%>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="TitleTd">Password : </td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPwd" ErrorMessage="Please Enter Password" ForeColor="Red" Display="Dynamic" ValidationGroup="vgLogin">*</asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td class="auto-style1">
                            <asp:Button ID="btnLogin" CssClass="btn btn-primaryByMe" runat="server" Text="Login" Width="100px" OnClick="LoginClicked" ValidationGroup="vgLogin" />
                            <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                            <br />

                        </td>
                        <td class="auto-style1"></td>
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td class="TitleTd">&nbsp;</td>
                        <td>
                            <asp:LinkButton ID="lnk" runat="server" OnClick="LnkForgotPasswordClicked">Forgot Password</asp:LinkButton>
                        </td>
                        <td></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
            </asp:Panel>
        </div>


       
    </div>
           <a href="javascript:void(0)" onclick="PreviousSlide()" id="PreviousButton" style="color: black"><< Faculty Login</a>
           <a href="javascript:void(0)" onclick="NextSlide()" id="NextButton" style="color:black">Student Login >></a>
</div>



<div id="forgotPwd" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="position: absolute">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="myModallblst">Forgot Password</h5>
    </div>
    <div class="modal-body">
        <table class="mytable" style="width: 500px">
            <tr id="firstRow" runat="server">
                <td>Enter Email:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtResetEmail"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnSubmitEmail" OnClick="BtnSubmitRestPwdClicked" CssClass="btn btn-primaryByMe" Text="Submit" />

                </td>
            </tr>
        </table>
    </div>
    <div class="modal-footer">
        <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
    </div>
</div>

