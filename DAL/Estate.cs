using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [DataContract]
    public class Estate
    {
        [DataMember]
        protected string type;
        [DataMember]
        protected int id;
        [DataMember]
        protected double cost;
        [DataMember]
        protected double square;
        [DataMember]
        protected int availiblity; 

        public string Type 
        {
            get { return type; }
            set { type = value; }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Square
        {
            get { return square; }
            set { square = value; }
        }
        public int Availibility
        {
            get { return availiblity; }
            set { availiblity = value; }
        }
        public Estate(string type, int id, double cost, double square)
        {
            Type = type;
            Id = id;
            Cost = cost;
            Square = square;
            Availibility = 1;
        }
        public string GetData()
        {
            string s = $"Estate {this.Id}: \n\tType = {this.Type} \n\tPrice = {this.Cost} \n\tSquare = {this.Square} \n\tAvailible (1-yes, 0-no) = {this.Availibility}";
            return s;
        }
    }
}
