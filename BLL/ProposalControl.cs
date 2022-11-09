using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class ProposalControl
    {

        // sorting a Estates with LINQ for making a proposal List 
        public List<Estate> SelectDefaultProp(List<Estate> list, Client client)
        {
            if (list != null)
            {
                string prefer = client.PreferType;
                List<Estate> props = new List<Estate>();
                foreach (var item in from Estate in list
                                     where Estate.Type == prefer && Estate.Availibility == 1
                                     select new { Estate })
                {
                    props.Add(item.Estate);
                }
                return props;
            }
            else
            {
                return new List<Estate>();
            }
        }

        public List<Estate> SelectBoundProp(List<Estate> list, Client client, string Type, double HighCost, double LowCost = 0)
        {
            if (list != null)
            {
                List<Estate> props = new List<Estate>();
                foreach (var item in from Estate in list
                                     where Estate.Cost <= HighCost && Estate.Cost >= LowCost && Estate.Availibility == 1
                                     && Estate.Type == Type
                                     select new { Estate })
                {
                    props.Add(item.Estate);
                }
                return props;
            }
            else
            {
                return new List<Estate>();
            }
        }
    }
}
