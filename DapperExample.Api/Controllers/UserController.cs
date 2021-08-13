using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperExample.Core.Entities;
using DapperExample.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperExample.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.User.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.User.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            var data = await unitOfWork.User.Add(user);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var data = await unitOfWork.User.Update(user);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.User.Delete(id);
            return Ok(data);
        }
    }
}
