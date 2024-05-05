namespace PatientsApi.Models
{
    public class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public int RoomNumber { get; set; }
    }
}
