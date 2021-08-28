using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Productos2;

namespace Productos2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<ItemP> Lproducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArchivosItems data = new ArchivosItems();
            Lproducts = data.getData();
            listProducts.Controls.Clear();
            Lproducts.ForEach((pro) =>
            {
                Button b = this.createBtn(pro.getName());
                Panel p = this.createPanel(pro.getName(), b);
                listProducts.Controls.Add(p);
            });
        }
        
        private Button createBtn(string name)
        {
            Button btn = new Button();
            btn.Click += new EventHandler(this.showDetails);
            btn.CssClass = "btn btn-success";
            btn.Text = "Detalles";
            btn.ID = name;
            return btn;
        }
        private Panel createPanel(string t, Button btn)
        {
            Panel panel = new Panel();
            panel.CssClass = "containerP";
            panel.Controls.Add(new LiteralControl(t));
            panel.Controls.Add(btn);
            return panel;
        }


        public void showDetails(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            ItemP m =  Lproducts.Find(r => r.getName() == btn.ID);

            NombreDetalle.Value = "Nombre: " + m.getName();
            CantidadDetalle.Value = "Cantidad: "+m.getCant().ToString();
            PrecioDetalle.Value = "Precio: "+m.getCost().ToString();
            DescripcionDetalle.Value = m.getDescription();
            Image2.ImageUrl = m.getURL();
        }

        protected void Add_Click(object sender, EventArgs e)
        {

            ArchivosItems n = new ArchivosItems();

            ItemP addItem = this.validarCampos();
            if(addItem != null)
            {
                if (FileUpload1.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                    ext = ext.ToLower();
                    int tam = FileUpload1.PostedFile.ContentLength;
                    if (ext == ".png" || ext == ".jpg")
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/Upload/" + addItem.getName() + ext));
                        addItem.setURL("./Upload/"+addItem.getName()+ext);
                        n.saveData(addItem);
                        this.vaciarCampos();
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        addItem.setURL("./Upload/default2.jpg");
                        n.saveData(addItem);
                        Response.Redirect(Request.RawUrl);
                        this.vaciarCampos();
                    }
                }
                else
                {
                    addItem.setURL("./Upload/default2.jpg");
                    n.saveData(addItem);
                    Response.Redirect(Request.RawUrl);
                    this.vaciarCampos();
                }
            }
            else
            {
                Response.Write("Algunos campos no son validos");
            }

            
        }
        private void vaciarCampos()
        {
            Nombre.Text = "";
            Descripcion.Text = "";
            Cantidad.Text = "";
            Precio.Text = "";

        }
        private ItemP validarCampos()
        {
            string name = Nombre.Text;
            string description = Descripcion.Text;
            if(name == "")
            {
                return null;
            }else if (description == "")
            {
                return null;
            }
            else
            {
                try
                {
                    int cant = int.Parse(Cantidad.Text);
                    double price = double.Parse(Precio.Text);
                    ItemP item = new ItemP(name, price,description,cant);
                    return item;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }
    }
}