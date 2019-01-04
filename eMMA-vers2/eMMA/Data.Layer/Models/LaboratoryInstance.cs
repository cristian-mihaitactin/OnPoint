using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class LaboratoryInstance : IPractical
    {
        [Column("Id")]
        public Guid Id { get; set; }

        public LaboratoryInstance()
        {
            //EF needs this
        }
    }
}
