using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AllControl
    {
        protected static ClientsControl ClientWork = new ClientsControl();
        protected static EstateControl EstateWork = new EstateControl();
        protected static ProposalControl PropWork = new ProposalControl();

        public static ClientsControl Clientwork { get; }
        public static string WorkWithClient() // Create + Delte + Edit for clients
        {
            string s = Inputs.InputDo();
            if (s == "Create")
            {
                 ClientWork.CreateClient();
                return "Create successfull";
            }
            else if (s == "Delete")
            {
                return ClientWork.DeleteClient();
            }
            else
            {
               return ClientWork.EditClient();
            }
        }
        public static string WorkWithEstate() // Create + Delte + Edit for estates
        {
            string s = Inputs.InputDo();
            if (s == "Create")
            {
                EstateWork.CreateEstate();
                return "Create successfull";
            }
            else if (s == "Delete")
            {
                return EstateWork.DeleteEstate();
            }
            else
            {
                return EstateWork.EditEstate();
            }
        }
        public static string ShowDefaultList() // showing non-sorted lists of clients or estates
        {
            string s = Inputs.InputWhatList();
            if (s == "1")
            {
               return ClientWork.GetClientList();
            }
            else
            {
                return EstateWork.GetEstateList();
            }
        }
        public static string ShowSortedList() // showing sorted lists of clients or estates by some rules 
        {
            string s = Inputs.InputWhatList();
            if (s == "1")
            {
                return ClientWork.GetSortedList();
            }
            else
            {
                return EstateWork.GetSortedList();
            }
        }
        public static string MakeProposalList() // generating the proposal list for speific user by his preferences or filtrs
        {
            int count = 0;
            Client client = ClientWork.SearchClient();
            if (client != null)
            {
                List<Estate> props = new List<Estate>();
                string s = Inputs.InputWhatProps();
                Random rng = new Random();
                if (s == "1")
                {
                    double HCostBounds = Inputs.InputBoundsHCost();
                    double LCostBounds = Inputs.InputBoundsLCost();
                    string Type = Inputs.InputEstateType();
                    props = PropWork.SelectBoundProp(EstateWork.GetAll(), client, Type, HCostBounds, LCostBounds);
                    int q = props.Count();
                    if (props != null)
                    {
                        for (int i = 0; i < 5 & i < q; i++)
                        {

                            int id = rng.Next(q);

                            string agree = Inputs.InputWhatAgree(props[id].GetData());
                            if (agree == "1")
                            { 
                                EstateWork.EditEstate(props[id]);
                                return "You have bought it succesfully!";
                            }
                        }
                        return "The end of list, please make a new one";
                    }
                    return null;
                }
                else
                {
                    props = PropWork.SelectDefaultProp(EstateWork.GetAll(), client);
                    int q = props.Count();
                    bool check = false;
                    if (props != null)
                    {
                        for (int i = 0; i < q; i++)
                        {
                            int id = rng.Next(q);
                            string agree = Inputs.InputWhatAgree(props[id].GetData());
                            if (agree == "1")
                            {
                                EstateWork.EditEstate(props[id]);
                                return "You have bought it succesfully!";
                            }  
                        }
                        return "The end of list, please make a new one";
                    }
                    return "The list is null";
                }
            }
            else
            {
                return Exception.ErrorID();
            }
        }
        public static string SearchByKeyword() //search by keyword for list of clients or estates or clients+estates 
        {
            string s = Inputs.InputTypeSearch();
            string keyword = Inputs.InputKeywordSearch();
            if (s == "1")
            {
              return ClientWork.SearchClByKeyword(keyword);
            }
            else if (s == "2")
            {
                return EstateWork.SearchEsByKeyword(keyword);
            }
            string subst = ClientWork.SearchClByKeyword(keyword) + EstateWork.SearchEsByKeyword(keyword);
            return subst;
        }
        public static string GetEsp()
        {
            string s = Inputs.InputWhatList();
            if (s == "1")
            {
                return ClientWork.ShowClient();
            }
            else
            {
                return EstateWork.ShowEstate();
            }
        }
    }
}
