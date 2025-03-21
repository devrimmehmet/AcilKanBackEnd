﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodDonationResults
{
    public class GetBloodDonationQueryResult
    {
        public int Id { get; set; }
        public int BloodRequestId { get; set; }
        public int DonorId { get; set; }
        public int? UnitsDonated { get; set; }
        public DateTime RequestedDonationDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DonationCompletionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Status { get; set; }
        public string? RejectedReason { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public string HospitalName { get; set; }
        public string PatientFullName { get; set; }
        public string DonorFullName { get; set; }
        public string RequesterFullName { get; set; }
    }

}
