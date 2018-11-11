using Pagina_Maestra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagina_Maestra.Views
{
    public partial class Comentario : System.Web.UI.Page
    {
        ComentarioContext context = new ComentarioContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCommment();
            }

            var id = Request.QueryString["id"];
            if (id != null)
            {
                var _contenido = context.Contenidos.FirstOrDefault(c => c.Id == new Guid(id));
                if (_contenido != null)
                {
                    context.Contenidos.Remove(_contenido);
                    context.SaveChanges();
                    loadCommment();
                    Clear();
                }
            }

        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            var nombre = txtSearch.Value;
            tblComentario.DataSource = context.Contenidos.Where(c => c.Nombre.Contains(nombre)).ToList();
            tblComentario.DataBind();
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            Contenido contenido = new Contenido
            {
                 Id = string.IsNullOrEmpty(hidenId.Value)? Guid.Empty : new Guid(hidenId.Value),
                 Nombre = txtNombre.Value,
                 Asunto = txtAsunto.Value,
                 Content = txtContenido.Value
            };

            if (!validateError(contenido))
            {
                showError(false);
            }
            else
            {
                return;
            }

            if (string.IsNullOrEmpty(hidenId.Value))
            {
                context.Add(contenido);
                context.SaveChanges();
            }
            else
            {
                var _contenido = context.Contenidos.FirstOrDefault(c => c.Id == contenido.Id);
                if (_contenido != null)
                {
                    _contenido.Nombre = contenido.Nombre;
                    _contenido.Asunto = contenido.Asunto;
                    _contenido.Content = contenido.Content;

                    context.Contenidos.Update(_contenido);
                    context.SaveChanges();
                }
            }
            
            loadCommment();
            Clear();
        }

        private void loadCommment()
        {
            tblComentario.DataSource = context.Contenidos.ToList();
            tblComentario.DataBind();
        }

        private void Clear()
        {
            txtAsunto.Value = "";
            txtContenido.Value = "";
            txtNombre.Value = "";
            hidenId.Value = "";
        }

        private bool validateError(Contenido contenido)
        {
            bool error = false;

            if (string.IsNullOrEmpty(contenido.Nombre))
            {
                lblNombre.Visible = true;
                error = true;
            }
            if (string.IsNullOrEmpty(contenido.Asunto))
            {
                lblAsunto.Visible = true;
                error = true;
            }
            if (string.IsNullOrEmpty(contenido.Content))
            {
                lblContenido.Visible = true;
                error = true;
            }

            return error;
        }

        private void showError(bool show)
        {
            lblNombre.Visible = show;
            lblAsunto.Visible = show;
            lblContenido.Visible = show;
        }
    }
}