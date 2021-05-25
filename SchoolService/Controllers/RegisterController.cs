using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolService.Data;
using SchoolService.Data.Infrastructure;
using SchoolService.Models.Entities;

namespace SchoolService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UnitOfWork<ApplicationContext> _unitOfWork;

        public RegisterController(UnitOfWork<ApplicationContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IList<ImportExport> Index()
        {
            return _unitOfWork.ImportExportRepository.GetActiveUsers();
        }



    }
}
