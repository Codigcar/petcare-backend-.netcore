﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int Qualification { get; set; }

        public string Commentary { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ProviderId { get; set; }

        public Provider Provider { get; set; }

    }
}
