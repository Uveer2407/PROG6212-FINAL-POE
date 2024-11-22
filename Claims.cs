namespace CMCS.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int LecturerId { get; set; }
        public string Description { get; set; } = default!;
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string Status { get; set; } = default!; 
        public string UploadedDocumentPath { get; set; } = default!;
        public string RejectionReason { get; set; } = default!;
    }

    
}
