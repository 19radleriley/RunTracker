using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunTracker.Models
{
	public class RunModel
	{
		[Key]
		public int Run_Id { get; set; }
        [Column("route_name")]
        public String? Route { get; set; }
        [Column("run_date")]
        public DateTime Date { get; set; }
		public float Distance { get; set; }
        [Column("pace_minutes")]
        public int PaceMinutes { get; set; }
        [Column("pace_seconds")]
        public int PaceSeconds { get; set; }
        public String? Notes { get; set; }
	}
}

