using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RamSoft.CodingTest.API.Controllers;
using RamSoft.CodingTest.Core.Entities;
using RamSoft.CodingTest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamSoft.CodingTest.UnitTest
{
    [TestFixture]
    public class TaskControllerTests
    {
        private Mock<ITaskRepository> mockService;
        private TaskController _scrumTaskController;
        public TaskControllerTests()
        {
           
        }

        [SetUp]
        public void Setup()
        {
            mockService = new Mock<ITaskRepository>();
            _scrumTaskController = new TaskController(mockService.Object);
        }

        private static List<ScrumTask> GetInputData()
        {
            return new List<ScrumTask>() { new ScrumTask {
                    TaskId = 1,
                    Title = "Add Logs to existing repos and services",
                    Description = " Find each and every service missing the logs and add necessary logs for each method",
                    StatusName = "New"
                },
                new ScrumTask
                {
                    TaskId = 2,
                    Title = "Amend component to use change detection strategy",
                    Description = " Implement on push strategy to the employee component",
                    StatusName = "Completed"
                }
            };
        }

        [Test]
        public async Task GetAll_WhenCalled_Returns_All_ScrumTasks()
        {
            /// Arrange

            var taskList = GetInputData();
            mockService.Setup(repo => repo.GetAll()).Returns(Task.FromResult(taskList));

            /// Act

            var result = await _scrumTaskController.Get() as OkObjectResult;            
            var items = result.Value as List<ScrumTask>;            

            /// Assert
            
            Assert.That(taskList,Is.EqualTo(items));
            Assert.That(items.Count, Is.EqualTo(items.Count));
        }

       

        [Test]
        public async Task GetAll_WhenCalled_Returns_OK_ObjectResult()
        {
            /// Arrange

            var taskList = GetInputData();
            mockService.Setup(repo => repo.GetAll()).Returns(Task.FromResult(taskList));

            /// Act

            var result = await _scrumTaskController.Get() as OkObjectResult;           

            /// Assert

            Assert.IsNotNull(result);
            Assert.That(200, Is.EqualTo(result.StatusCode));
        }

        [Test]
        public async Task GetById_WhenCalled_Returns_ActualValue()
        {
            /// Arrange

            var taskList = GetInputData();
            mockService.Setup(repo => repo.Get(1)).Returns(Task.FromResult(taskList[0]));

            /// Act

            var result = await _scrumTaskController.GetById(1) as OkObjectResult;
            var item = result.Value as ScrumTask;

            /// Assert            
            Assert.IsNotNull(item);
            Assert.That(200, Is.EqualTo(result.StatusCode));
            Assert.That(1, Is.EqualTo(item.TaskId));
        }

        [Test]
        public async Task GetById_WhenCalled_Returns_NotFound()
        {
            /// Arrange

            var taskList = GetInputData();
            mockService.Setup(repo => repo.Get(3)).Returns(Task.FromResult<ScrumTask>(null));

            /// Act

            var result = await _scrumTaskController.GetById(3) as NotFoundResult;

            /// Assert            
            Assert.That(404, Is.EqualTo(result.StatusCode));
        }

        [Test]
        public async Task Add_ScrumTask_With_InCorrect_Model_ShouldReturn_BadRequest()
        {
            /// Arrange
           
            _scrumTaskController.ModelState.AddModelError("Title", "Title is required");

            /// Act

            var result = await _scrumTaskController.Add(new ScrumTask()) as BadRequestObjectResult;

            /// Assert            
            Assert.That(400, Is.EqualTo(result.StatusCode));
        }

        [Test]
        public async Task Add_ScrumTask_With_Valid_Inputs_Should_Return_AddedItem_Into_The_Original_List()
        {
            /// Arrange
            var allTasks = new List<ScrumTask>();

            mockService.Setup(repo => repo.Add(It.IsAny<ScrumTask>()))
                       .Callback<ScrumTask>(allTasks.Add);

            var scrumTask = new ScrumTask() { 
                TaskId = 3,
                Title = "Http Interceptor implementation",
                Description ="Implement http interceptor in angular for all outgoing http requests."
            };            

            /// Act

            var result = await _scrumTaskController.Add(scrumTask);

            /// Assert     
            Assert.That(1, Is.EqualTo(allTasks.Count()));
            Assert.That(allTasks.Any(t => t.TaskId == 3));
        }

        [Test]
        public async Task Delete_ScrumTask_With_Valid_Inputs_Should_Return_List_With_Removed_Item()
        {
            /// Arrange
            var allTasks = GetInputData();
            var scrumTask = new ScrumTask()
            {
                TaskId = 2
            };

            mockService.Setup(repo => repo.Get(2)).Returns(Task.FromResult(scrumTask))
                .Callback<int>((int id) => {
                    allTasks.Remove(allTasks.Single(t => t.TaskId == id));
                });
            
            /// Act

                    var result = await _scrumTaskController.Delete(scrumTask.TaskId);

            /// Assert     
            Assert.That(1, Is.EqualTo(allTasks.Count()));
            CollectionAssert.DoesNotContain(allTasks, scrumTask);
        }

        [Test]
        public async Task Delete_ScrumTask_With_InValid_Inputs_Should_Return_Error_NotFound()
        {
            /// Arrange
            var allTasks = GetInputData();

            mockService.Setup(repo => repo.Delete(It.IsAny<int>()))
                       .Callback<int>((int id) =>
                       {
                           allTasks.Remove(allTasks.Single(t => t.TaskId == id));
                       });

            var scrumTask = new ScrumTask()
            {
                TaskId = 3
            };

            /// Act

            var result = await _scrumTaskController.Delete(scrumTask.TaskId) as NotFoundResult;

            /// Assert    
            Assert.IsNotNull(result);
            Assert.That(404, Is.EqualTo(result.StatusCode));
            
        }

        [Test]
        public void Exception_Check()
        {
            Assert.Throws<Exception>(() => _scrumTaskController.Exception());
        }

    }
}