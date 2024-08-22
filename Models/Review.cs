﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem_Backend.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        public DateTime ReviewDate {  get; set; }

        public required string ReviewComment { get; set; }
    }
}
