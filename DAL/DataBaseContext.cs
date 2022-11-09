using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DAL
{
    public class DataBaseContext
    {
        string root = Environment.CurrentDirectory;
        public DataContractJsonSerializer JSONFormatterClients = new DataContractJsonSerializer(typeof(List<Client>));
        public DataContractJsonSerializer JSONFormatterEstates = new DataContractJsonSerializer(typeof(List<Estate>));

        // client
        public void ClientWriter(List<Client> obj)
        {
            string s = root + "\\JSONClientsForm.json";
            using (var file = new FileStream(s, FileMode.OpenOrCreate))
            {
                JSONFormatterClients.WriteObject(file, obj);
            }
        }
        public List<Client> ClientReader()
        {
            string s = root + "\\JSONClientsForm.json";
            if (File.Exists(s))
            {
                using (var file = new FileStream(s, FileMode.OpenOrCreate))
                {
                        var ret = JSONFormatterClients.ReadObject(file) as List<Client>;
                        return ret;
                }
            }
            else
            {
                return null;
            }
        }
        public string ClientStringReader()
        {
            string subst = "";
            var ret = ClientReader();
            if (ret != null)
            {
                foreach (var item in ret)
                {
                    subst += $"{item.GetData()} \n";
                }
                return subst;
            }
            return "File is empty, please enter your data firstly";
        }
        public void DeleteClient()
        {
            string s = root + "\\JSONClientsForm.json";
            if (File.Exists(s))
            {
                File.Delete(s);
            }
        }

        // Estate

        public void EstateWriter(List<Estate> obj)
        {
            string s = root + "\\JSONEstatesForm.json";
            using (var file = new FileStream(s, FileMode.OpenOrCreate))
            {
                JSONFormatterEstates.WriteObject(file, obj);
            }
        }
        public List<Estate> EstateReader()
        {
            string s = root + "\\JSONEstatesForm.json";
            if (File.Exists(s))
            {
                using (var file = new FileStream(s, FileMode.OpenOrCreate))
                {
                    var ret = JSONFormatterEstates.ReadObject(file) as List<Estate>;
                    if (ret == null)
                    {
                        return new List<Estate>();
                    }
                    return ret;
                }
            }
            else
            {
                return null;
            }
        }
        public string EstateStringReader()
        {
            string subst = "";
            var ret = EstateReader();
            if (ret != null)
            {
                foreach (var item in ret)
                {
                    subst += $"{item.GetData()} \n";
                }
                return subst;
            }
            return "File is empty, please enter your data firstly";
        }
        public void DeleteEstate()
        {
            string s = root + "\\JSONEstatesForm.json";
            if (File.Exists(s))
            {
                File.Delete(s);
            }
        }
    } 
}
