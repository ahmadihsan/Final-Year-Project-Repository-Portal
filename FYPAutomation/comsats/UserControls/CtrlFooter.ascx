<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFooter.ascx.cs" Inherits="WebApplication1.comsats.CtrlFooter" %>

<div class="footer">
    
    <div class="ft">
        <div class="address" >
            <h2 style="background: transparent url(<%=VirtualPathUtility.ToAbsolute("~/comsats/images/phone_icon.png")%>) center left no-repeat; display: inline-block; padding-left: 22px; line-height: 17px;">Contact</h2>
            <p>
                Tel: +92-51-9247000-9247002 and 9049802<br>
                UAN: +92-51-111-001-007 
            </p>
        </div>
        <div class="address" style="margin-left: 200px">
            <h2 style="background: transparent url(<%=VirtualPathUtility.ToAbsolute("~/comsats/images/reach_icon.png")%>) center left no-repeat; display: inline-block; padding-left: 22px; line-height: 17px;">Reach Us at</h2>
            <p>
                Park Road, Chak Shahzad,
                        <br>
                Islamabad, Pakistan
            </p>
        </div>
        <div class="socio_icons"></div>
    </div>
    <div class="footdown" >
    <div class="ftdown">
        <p>© 2012-2016 COMSATS Institute of Information Technology</p>
        <p style="float: left;">Developed by: Ahmad Ehsan &amp; Adil Rasheed Khan</p>
    </div>
</div>
</div>


<script src="<%= VirtualPathUtility.ToAbsolute("~/comsats/MenuScripts/superfish.js") %>"></script>
<script src="<%= VirtualPathUtility.ToAbsolute("~/comsats/MenuScripts/hoverIntent.js") %>"></script>

<script type="text/javascript">
    var menuDiv = $("div#TopMyMenuControl > ul").addClass("sf-menu").attr("id", "myCustomMenu");
    $('#myCustomMenu').superfish({

    });

</script>
