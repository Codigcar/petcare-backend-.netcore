﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Many-to-Many
        public List<ProviderJoinProduct> ProviderProducts { get; set; }

        //One-To-Many
        public TypeProduct TypeProduct { get; set; }
        public int TypeProductId { get; set; }

        public IList<PersonRequest> Requests { get; set; } = new List<PersonRequest>();
        public Availability Availability { get; set; }

    }
}