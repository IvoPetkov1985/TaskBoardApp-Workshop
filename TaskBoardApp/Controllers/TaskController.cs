using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.ViewModels;
using static TaskBoardApp.Data.DataConstants.DataConstants;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext context;

        public TaskController(TaskBoardAppDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var taskModel = new TaskFormViewModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormViewModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), BoardNotExisting);
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            var task = new TaskBoardApp.Data.DataModels.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            var boards = context.Boards;

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await context.Tasks
                .AsNoTracking()
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString(TaskCreationFormat),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var taskToEdit = await context.Tasks.FindAsync(id);

            if (taskToEdit == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToEdit.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskFormViewModel()
            {
                Title = taskToEdit.Title,
                Description = taskToEdit.Description,
                BoardId = taskToEdit.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormViewModel taskModel)
        {
            var taskToEdit = await context.Tasks.FindAsync(id);

            if (taskToEdit == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToEdit.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskToEdit.BoardId))
            {
                ModelState.AddModelError(nameof(taskToEdit.BoardId), BoardNotExisting);
            }

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            taskToEdit.Title = taskModel.Title;
            taskToEdit.Description = taskModel.Description;
            taskToEdit.BoardId = taskModel.BoardId;

            await context.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = await context.Tasks.FindAsync(id);

            if (taskToDelete == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToDelete.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskViewModel()
            {
                Id = taskToDelete.Id,
                Title = taskToDelete.Title,
                Description = taskToDelete.Description,
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var taskToDelete = await context.Tasks.FindAsync(taskModel.Id);

            if (taskToDelete == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToDelete.OwnerId)
            {
                return Unauthorized();
            }

            context.Tasks.Remove(taskToDelete);
            await context.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        private IEnumerable<TaskBoardViewModel> GetBoards()
            => context.Boards.Select(b => new TaskBoardViewModel()
            {
                Id = b.Id,
                Name = b.Name
            });

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
