using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

    }
}
