﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSale.Services.Catalog.Dtos
{
    public class CourseUpdateDto
    {
        public string İd { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public string UserId { get; set; }

        public FeatureDto Feature { get; set; }

        public string CategoryId { get; set; }
    }
}
