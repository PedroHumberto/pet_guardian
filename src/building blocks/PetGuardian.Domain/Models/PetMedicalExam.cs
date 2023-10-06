namespace PetGuardian.Models.Models
{
    public class PetMedicalExam
    {
        public IEnumerable<string> Exams { get; private set; }

        public void AddExam(string exameFile)
        {
            Exams.Append(exameFile);
        }
    }
}