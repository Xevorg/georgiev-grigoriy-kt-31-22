namespace georgiev_grigoriy_kt_31_22.Models
{
    public class Nagruzka
    {
        public int Id { get; set; }

        public int DisciplineId { get; set; }
        public Disciplines Disciplines { get; set; }

        public int PrepodId { get; set; }
        public Prepods Prepod { get; set; }

        //public int CafedraId { get; set; }

        public int totalHours { get; set; }

    }
}
