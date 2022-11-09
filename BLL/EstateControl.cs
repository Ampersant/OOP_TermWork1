using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstateControl
    {
        protected static DataBaseContext datb = new DataBaseContext(); // obj to work with DB
        protected List<Estate> EstateList
        {
            get; set;
        }
        public void SaveChanges() // working with DB, save changes with estate list 
        {
            datb.EstateWriter(EstateList);
            EstateList = datb.EstateReader();
        }
        public bool checkList() // checking for null
        {
            EstateList = datb.EstateReader();
            if (EstateList == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CreateEstate() // creation
        {
            EstateList = datb.EstateReader();
            int id = Inputs.InputEstateID();
            if (EstateList != null)
            {
                while (EstateList.Any(item => item.Id == id))
                {
                    id = Inputs.InputEstateID(Exception.ErrorAlreadyExist());
                }
            }
            string type = Inputs.InputEstateType();
            double cost = Inputs.InputEstateCost();
            double square = Inputs.InputEstateSquare();

            Estate estate = new Estate(type, id, cost, square);
            if (EstateList == null)
            {
                EstateList = new List<Estate>();
                EstateList.Add(estate);
                SaveChanges();
            }
            else
            {
                EstateList.Add(estate);
                SaveChanges();
            }
        }
        public Estate SearchEstate()  // searching
        {
            EstateList = datb.EstateReader();
            int id = Inputs.InputEstateID();
            if (EstateList != null)
            {
                foreach (var item in EstateList)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public string DeleteEstate()  // deleting
        {
            if (checkList())
            {
                return Exception.ErrorNullFile();
            }
            else if (EstateList.Count == 1)
            {
                datb.DeleteEstate();
                return "There was the last estate, deleting is successfull";
            }
            Estate obj = SearchEstate();
            if (obj != null)
            {
                EstateList.Remove(obj);
                SaveChanges();
                return "Deleting is successfull";
            }
            else
            {
                return Exception.ErrorID();
            }
        }
        public string EditEstate(Estate item = null) // editing
        {
            if (checkList())
            {
                return Exception.ErrorNullFile();
            }
            else
            {
                if (item != null)
                {
                    var obj = item;
                    foreach (var key in EstateList)
                    {
                        if (obj == key)
                        {
                            item.Availibility = 0;
                            SaveChanges();
                        }
                    }
                    return $"New object: {item.GetData()}";
                }
                else
                {
                    Estate obj = SearchEstate();
                    if (obj != null)
                    {
                        string s = Inputs.InputWhatToEditEs();
                        if (s == "1")
                        {
                            string type = Inputs.InputEstateType();
                            obj.Type = type;
                        }
                        else if (s == "2")
                        {
                            double cost = Inputs.InputEstateCost();
                            obj.Cost = cost;
                        }
                        else if (s == "3")
                        {
                            int id = Inputs.InputEstateID();
                            obj.Id = id;
                        }
                        else if (s == "4")
                        {
                            double square = Inputs.InputEstateSquare();
                            obj.Square = square;

                        }
                        else
                        {
                            return "This field is accessible only for administration! Please try again.";
                        }
                        SaveChanges();
                        return $"Updated object: {obj.GetData()}";
                    }
                    else
                    {
                        return Exception.ErrorID();
                    }
                }
            }
        }
        public string ShowEstate() // look for an especial estate
        {
            Estate obj = SearchEstate();
            if (obj != null)
            {
                return obj.GetData();
            }
            else
            {
                return Exception.ErrorID();
            }
        }
        public string GetEstateList()  // reeturn all information about estates as string
        {
            string s = "";
            EstateList = datb.EstateReader();
            if (EstateList != null)
            {
                foreach (var item in EstateList)
                {
                    s += $"{item.GetData()}  \n";
                }
                return s;
            }
            return Exception.ErrorList();
        }

        public string GetSortedList() // return sorted list of estates as string 
        {
            string s = "";
            List<Estate> sorted = new List<Estate>();
            EstateList = datb.EstateReader();
            string type = Inputs.InputEstateSort();
            if (EstateList != null)
            {
                if (type == "1")
                {
                    sorted = EstateList.OrderBy(x => x.Type).ToList();
                }
                else 
                {
                    sorted = EstateList.OrderBy(x => x.Cost).ToList();
                }
            }
            else
            {
                return Exception.ErrorList();
            }
            foreach (var item in sorted)
            {
                s += $"{item.GetData()}  \n";
            }
            return s;
        }
        public List<Estate> GetAll() // return estates as the List<Estate> object
        {
            EstateList = datb.EstateReader();
            return EstateList;
        }
        public string SearchEsByKeyword(string s) // searching estate by keyword
        {
            List<Estate> res = new List<Estate>();
            string subst = "";
            EstateList = datb.EstateReader();
            if (EstateList == null)
            {
                return Exception.ErrorList();
            }

            foreach (var item in EstateList)
            {
                if (item.Type == s || item.Id.ToString() == s || item.Cost.ToString() == s)
                {
                    res.Add(item);
                }
            }
            subst += "By your keyword we have found the next estates: \n";
            foreach (var key in res)
            {
                subst += key.GetData() + "\n";
            }
            return subst;
        }
    }
}
