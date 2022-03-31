namespace TaskEngAmr.DTOs
{
    public class BranchDTO
    {
        public class Add
        {
            public string ArabicName { get; set; }
            public string EnglishName { get; set; }
            public double Lat { get; set; }
            public double Long { get; set; }
            public string Address { get; set; }
        }
        public class GetEdit
        {
            public int Id { get; set; }
            public string ArabicName { get; set; }
            public string EnglishName { get; set; }
            public double Lat { get; set; }
            public double Long { get; set; }
            public string Address { get; set; }
        }
    }
}
