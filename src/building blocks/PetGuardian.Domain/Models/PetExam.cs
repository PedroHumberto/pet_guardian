using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Models
{
    public class PetExam : Entity
    {
        public PetExam(Guid petId, string examLink, string examName, DateTime examDate)
        {
            PetId = petId;
            ExamLink = examLink;
            ExamName = examName;
            ExamDate = examDate;
        }

        protected PetExam() { }
        public Guid PetId { get; private set; }
        public Pet Pet { get; set; }
        public string ExamName { get; private set; }
        public string ExamLink { get; private set; }
        public string Observations { get; private set; }
        public DateTime ExamDate { get; private set; }
        
    }
}