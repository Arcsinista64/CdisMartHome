using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CdisMart
{
    public class Tema : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "Tema1";
        }
    }
}