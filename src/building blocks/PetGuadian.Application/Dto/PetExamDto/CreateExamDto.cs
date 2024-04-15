namespace PetGuadian.Application.Dto.PetExamDto
{
    public record CreateExamDto (
        Guid PetId, 
        string ExamName, 
        string ExamLink, 
        string Observations, 
        DateTime ExamDate);
}