using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace MenuControl
{
   [ToolboxData("<{0}:MyMenuControl runat=\"server\"></{0}:MyMenuControl>")]
   public class MyMenuControl : System.Web.UI.WebControls.Menu
    {
        
        protected override void OnPreRender(EventArgs e)
        {
            // Don't call base OnPreRender
            //base.OnPreRender(e);
        }
    }
}
