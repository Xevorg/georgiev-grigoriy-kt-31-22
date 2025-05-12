namespace georgiev_grigoriy_kt_31_22.Models
{
    public class Prepods
    {
        public int IdPrepod { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MidName { get; set; }

        public int DegreeId { get; set; }
        public Degrees Degrees { get; set; }

        public int PositionId { get; set; }
        public Positions Positions { get; set; }
    }
}
