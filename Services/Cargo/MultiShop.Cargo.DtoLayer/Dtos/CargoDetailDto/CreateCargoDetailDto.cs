﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto
{
    public class CreateCargoDetailDto
    {
        public string SenderCustormer { get; set; }

        public string ReceiverCustomer { get; set; }

        public int Barcode { get; set; }

        public int CargoCompanyId { get; set; }

    }
}