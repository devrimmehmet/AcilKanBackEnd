﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodRequestResults
{
    public class GetBloodRequestQueryResult
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int HospitalId { get; set; }
        public int BloodGroupId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
