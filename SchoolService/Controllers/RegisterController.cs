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
        public IActionResult GetAllImportExport()
        {
            return new ObjectResult(_unitOfWork.ImportExportRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImportExport([FromRoute] int id)
        {
            var ie = await _unitOfWork.ImportExportRepository.GetSingleOrDefaultAsync(i => i.ID == id);
            return Ok(ie);
        }


        [HttpPost]
        public async Task<IActionResult> PostImportExport([FromBody] ImportExport importExport)
        {
            _unitOfWork.ImportExportRepository.Insert(importExport);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction("GetImportExport", new { id = importExport.ID }, importExport);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportExport([FromRoute] int id, [FromBody] ImportExport importExport)
        {
            _unitOfWork.ImportExportRepository.Update(importExport);
            await _unitOfWork.CommitAsync();
            return Ok(importExport);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImportExport([FromRoute] int id)
        {
            // var ie = _unitOfWork.ImportExportRepository.GetById(id);
            _unitOfWork.ImportExportRepository.Delete(id);
            await _unitOfWork.CommitAsync();
            return Ok();
        }
    }
}
