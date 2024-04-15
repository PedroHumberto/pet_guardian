using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.MedicineCommands
{
    public class UpdateMedicineCommand : Notifiable<Notification>, ICommand
    {
        public UpdateMedicineCommand(Guid medicineId, string remedyName, string dosage, string observations, DateTime? endDate)
        {
            MedicineId = medicineId;
            RemedyName = remedyName;
            Dosage = dosage;
            Observations = observations;
            EndDate = endDate;
        }

        public Guid MedicineId { get; set; }
        public string RemedyName { get; set; }
        public string Dosage { get; set; }
        public string Observations { get; set; }
        public DateTime? EndDate { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}