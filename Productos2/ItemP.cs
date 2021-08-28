using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Productos2
{
    public class ItemP
    {
        private string name;
        private string URL;
        private double cost;
        private string description;
        private int cant;

        public ItemP(string name, double cost, string description, int cant,string url)
        {
            this.name = name;
            this.cost = cost;
            this.description = description;
            this.cant = cant;
            this.URL = url;
        }
        public ItemP(string name, double cost, string description, int cant)
        {
            this.name = name;
            this.cost = cost;
            this.description = description;
            this.cant = cant;
            this.URL = "./Upload/default2.jpg";
        }
        public void setURL(string url)
        {
            this.URL = url;
        }

        public string getName()
        {
            return this.name;
        }
        public double getCost()
        {
            return this.cost;
        }
        public string getDescription()
        {
            return this.description;
        }
        public int getCant()
        {
            return this.cant;
        }
        public string getURL()
        {
            return this.URL;
        }
    }
}