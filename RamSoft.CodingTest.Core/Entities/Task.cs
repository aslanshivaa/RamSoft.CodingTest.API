using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RamSoft.CodingTest.Core.Entities
{
    public class ScrumTask
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(250, ErrorMessage = "Title cannot exceed more than 250 characters.")]
        public string Title { get; set; }

        [Required (ErrorMessage = "Description is required")]
        public string Description { get; set; }

        
        public DateTime? Deadline { get; set; }

        
        public int? OriginalEstimate { get; set; }

        public int? CompletedHours { get; set; }

        public string StatusName { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }

    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }
}
