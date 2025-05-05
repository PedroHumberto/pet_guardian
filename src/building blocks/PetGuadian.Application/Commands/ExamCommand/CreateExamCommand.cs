using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.ExamCommand
{
    public class CreateExamCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public CreateExamCommand()
        {
        }

        public CreateExamCommand(Guid petId, string examName, Uri examLink, string observations, DateTime examDate)
        {
            PetId = petId;
            ExamName = examName;
            ExamLink = examLink;
            Observations = observations;
            ExamDate = examDate;
        }

        public string ExamName { get; set; }
        public Uri ExamLink { get; set; }
        public string Observations { get; set; }
        public DateTime ExamDate { get; set; }
        public Guid PetId { get; set; }
        public void Execute()
        {
            AddNotifications(new Contract<CreateExamCommand>()
                .Requires()
                .IsNotNullOrEmpty(ExamName, "ExamName", "Exam name is required")
                .IsNotNullOrEmpty(ExamLink.ToString(), "ExamLink", "Exam link is required")
                .IsNotNullOrEmpty(Observations, "Observations", "Observations are required")
                .IsNotNull(ExamDate, "ExamDate", "Exam date is required")
                .IsNotNull(PetId, "PetId", "Pet Id is required")
            );
        }
    }
}