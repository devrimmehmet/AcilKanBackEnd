﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class BloodDontaion
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public int? HospitalId{ get; set; }
        public DateTime DonationDate { get; set; }
        public int DonationStatusId { get; set; }
        public bool DonationType { get; set; }
        public int BloodRequestId { get; set; }
        public BloodRequest BloodRequest { get; set; }
        public Hospital Hospital{ get; set; }
        public DonationStatus DonationStatus { get; set; }
        public AppUser Donor { get; set; }

    }
}
