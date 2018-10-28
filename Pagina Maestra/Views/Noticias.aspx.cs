using Pagina_Maestra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Maestra.Views
{
    public partial class Noticias : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CnnContext cnnContext = new CnnContext();
            var news = cnnContext.Noticias.ToList();
            tblNoticias.DataSource = news;
            tblNoticias.DataBind();
        }
    }
}