using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RamSoft.CodingTest.Core.Entities;
using RamSoft.CodingTest.Core.Repositories;
using System;
using System.Threading.Tasks;
using ScrumTask = RamSoft.CodingTest.Core.Entities.ScrumTask;

namespace RamSoft.CodingTest.API.Controllers
{
    [ApiController]
    [Route("ScrumTask")]
    public class TaskController : ControllerBase
    {
        public ITaskRepository _taskRepository { get; }
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var result = await _taskRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _taskRepository.Get(id);
            if (result == null)
            { 
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] ScrumTask task)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _taskRepository.Add(task);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] ScrumTask task)
        {
            var result = await _taskRepository.Update(task);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var scrumTask = await _taskRepository.Get(id);

            if (scrumTask == null)
            {
                return NotFound();
            }
            var result = await _taskRepository.Delete(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("exception")]
        public void Exception()
        {
            throw new Exception("Triggered exception");            
        }
    }
}
