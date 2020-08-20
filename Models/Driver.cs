using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Models
{
    public class Driver
    {
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string StartTime { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string EndTime { get; set; }

        [Column(TypeName = "varchar(10)")]
        public TimeSpan TotalTime { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public double Miles { get; set; }

        [Column(TypeName = "varchar(3)")]
        public double Mph { get; set; }

        [Column(TypeName = "varchar(3)")]
        public int trip { get; set; }

    }
}
