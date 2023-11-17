using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Core.PetGuardianCore.DomainObjects;
using PetGuardian.Models.Models;

namespace PetGuardian.Domain.Models
{
    public class Medicine : Entity
    {
        protected Medicine(){}

        public Medicine(string remedyName, string dosage, string observations, DateTime startDate, DateTime? endDate)
        {
            RemedyName = remedyName;
            Dosage = dosage;
            Observations = observations;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string RemedyName { get; private set; }
        public string Dosage { get; private set; }
        public string Observations { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public Guid PetId { get; private set; }
        public Pet Pet { get; set; }


        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}