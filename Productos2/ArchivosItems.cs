using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Productos2
{
    public class ArchivosItems
    {
        public static string dir = System.Web.HttpContext.Current.Server.MapPath("~")+"/items.txt";
        protected List<ItemP> ListaItems;
        public ArchivosItems()
        {
            this.fileExits();

        }
        public void saveData(ItemP e)
        {
            if (this.fileExits())
            {
                List<ItemP>  items = this.getData();
                bool p = items.Exists(r => r.getName() == e.getName());
                if(p == false)
                {
                    StringBuilder st = new StringBuilder(File.ReadAllText(ArchivosItems.dir));
                    st.AppendLine(e.getName() + "@"
                                 + e.getCant() + "@"
                                 + e.getCost() + "@"
                                 + e.getDescription() + "@"
                                 + e.getURL());
                    File.WriteAllText(dir, st.ToString());
                }
                
            }
            else
            {

                File.Create(dir).Close();
                StringBuilder st = new StringBuilder(File.ReadAllText(ArchivosItems.dir));
                st.AppendLine(e.getName() + "@"
                             + e.getCant() + "@"
                             + e.getCost() + "@"
                             + e.getDescription() + "@"
                             + e.getURL());
                File.WriteAllText(dir, st.ToString());
            }

           
        }
        private ItemP convertItem(String [] arr)
        {
            string name = arr[0];
            int cant = int.Parse(arr[1]);
            double cost = double.Parse(arr[2]);
            string description =arr[3];
            string URL = arr[4];

            ItemP convertido = new ItemP(name, cost, description, cant, URL);
            return convertido;
        }
        public  List<ItemP> getData(){

            if (this.fileExits())
            {
                StreamReader streader = new StreamReader(dir);
                string line;
                List<ItemP> ListaLlena = new List<ItemP>();
                while ((line = streader.ReadLine()) != null)
                {
                    string[] cadena = line.Split('@');
                    ListaLlena.Add(this.convertItem(cadena));
                }
                streader.Close();
                this.ListaItems = ListaLlena;
                return this.ListaItems;
                this.ListaItems =new List<ItemP>();
                return this.ListaItems;
            }
            else
            {
                File.Create(dir).Close();
                this.ListaItems = new List<ItemP>();
                return this.ListaItems;
            }
        }
        private bool fileExits()
        {
            if (File.Exists(dir))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}