using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HW4.Models;
using HW4.DAL.Abstract;
using HW4.ViewModels;
using HW4.Models.DTO;

namespace HW4.Controllers;

[Route("api/task")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly IToDoTaskRepository _taskRepository;

    public TaskController(IToDoTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet]
    public ActionResult Task()
    {
        IEnumerable<TaskTodo> tasksList = _taskRepository.GetAllTasksTodoWithinTimeWindow(new DateOnly(2022, 11, 30), 7);
        var dto = new List<TaskDTO>();
        foreach(var task in tasksList)
        {
            dto.Add(new TaskDTO(task));
        }
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ItemTask> PostTask([Bind("Name, FirstCompletion, Frequency, Notes, ItemId")] ItemTask task)
    {
        task.Id = 0;
        task.FirstCompletion.AddHours(-8);
        ItemTask t = _taskRepository.AddOrUpdate(task);
        return Redirect("Task");
        //return CreatedAtAction("GetTask", "Task", t);
    }
}
