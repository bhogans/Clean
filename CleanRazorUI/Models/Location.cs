using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanRazorUI.Models
{
    [Serializable]
    public class Location
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        public string Type { get; set; }
        public List<Coordinates> Coordinates { get; set; }

    }
}
