using System.Diagnostics;
using System.Linq.Expressions;
namespace LegacyApp
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ClientStatus ClientStatus { get; set; }

        public ClientType ClientType
        {
            get
            {
                return Name switch
                {
                    "VeryImportantClient" => ClientType.VeryImportantClient,
                    "ImportantClient" => ClientType.ImportantClient,
                    _ => ClientType.GeneralClient,
                };
            }
        }
    }
}