using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Interfaces;

namespace ToDoListApi.Controllers
{
    [Route("api/Status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
           private readonly IStatusRepository _statusRepo;
              public StatusController(IStatusRepository statusRepo)
              {
                _statusRepo = statusRepo;
              }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var statuses = await _statusRepo.GetAllAsync();
                return Ok(statuses);
            }
    }
}