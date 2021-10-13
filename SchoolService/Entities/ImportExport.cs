using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolService.Models.Entities
{
    public class ImportExport : BaseClass<long>
    {

        public ImportExport()
        {
            ID = new long();
            RegisterTime = DateTime.Now;
            IsActive = true;
        }
        [StringLength(45)]
        public string TagID { get; set; }
        [Required]
        public bool ImportExportType { get; set; }

    }
}