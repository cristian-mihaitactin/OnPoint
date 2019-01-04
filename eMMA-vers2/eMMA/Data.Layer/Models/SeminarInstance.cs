﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class SeminarInstance : IPractical
    {
        [Column("Id")]
        public Guid Id { get; private set; }

        public SeminarInstance()
        {
            //EF needs this
        }
    }
}
