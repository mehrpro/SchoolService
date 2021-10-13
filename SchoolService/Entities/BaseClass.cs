using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolService.Models.Entities
{
    public class BaseClass<T>
    {
        [Key]
        public T ID { get; set; }
        [Required]
        public DateTime RegisterTime { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}