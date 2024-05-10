using Laboratorio_Tiaraju.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.Model.Entities
{
    public class Extintor
    {
        public Extintor(int id,string facility, string building, DateTime chargeValidate, DateTime inspectedAt, DateTime hidrostaticTestValidate, string levelMaintenance, StatusExtintorEnum statusEnum, string imagePath)
        {
            Id = id;
            Facility = facility;
            Building = building;
            ChargeValidate = chargeValidate;
            InspectedAt = inspectedAt;
            HidrostaticTestValidate = hidrostaticTestValidate;
            LevelMaintenance = levelMaintenance;
            StatusEnum = statusEnum;
            ImagePath = imagePath;
        }

        public int Id { get; private set; }
        public string Facility { get; private set; } = string.Empty;
        public string Building { get; private set; } = string.Empty;
        public DateTime ChargeValidate { get; private set; }
        public DateTime InspectedAt { get; private set; }
        public DateTime HidrostaticTestValidate { get; private set; }
        public string LevelMaintenance { get; private set; } = string.Empty;
        public StatusExtintorEnum StatusEnum { get; private set; }
        public string ImagePath { get; private set; }
    }
}
