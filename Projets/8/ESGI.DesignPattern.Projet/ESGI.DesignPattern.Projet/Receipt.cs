﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public class Receipt
    {
        public Money Amount { get; set; }
        public Money Tax { get; set; }
        public Money Total { get; set; }

        public IEnumerable<string> Format()
        {
            return new List<string>() { //
                    "Receipt", //
                    "=======", //
                    "Item 1 ... " + Amount.Format(), //
                    "Tax    ... " + Tax.Format(), //
                    "----------------", //
                    "Total  ... " + Total.Format() //
            };
        }
    }
}
