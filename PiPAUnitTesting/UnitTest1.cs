using PiPA.Data;
using PiPA.Models;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PiPA.Models.Services;

namespace PiPAUnitTesting
{
    public class UnitTest1
    {
        //lists====================================================
        //getter for userid
        [Fact]
        public void TestGetUserID()
        {
            Lists testList1 = new Lists();
            testList1.UserID = "aUserID";
            Assert.Equal("aUserID", testList1.UserID);
        }
        //setter for userid
        [Fact]
        public void TestSetUserID()
        {
            Lists testList2 = new Lists();
            testList2.UserID = "aUserID";
            testList2.UserID = "NewUserID";
            Assert.Equal("NewUserID", testList2.UserID);
        }

        //getter for list name
        [Fact]
        public void TestGetLastName()
        {
            Lists testList3 = new Lists();
            testList3.ListName = "aListName";
            Assert.Equal("aListName", testList3.ListName);
        }

        //setter for list name
        [Fact]
        public void TestsetLastName()
        {
            Lists testList4 = new Lists();
            testList4.ListName = "aListName";
            testList4.ListName = "NewListName";
            Assert.Equal("NewListName", testList4.ListName);
        }

        //Create list
        [Fact]
        public async void TestCreateList()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("CreateList").Options;

            using (PADbcontext context = new PADbcontext(options))
            {

                Lists testLists5 = new Lists();
                testLists5.ID = 1;
                testLists5.UserID = "aUserName";
                testLists5.ListName = "ToDoList";

                ListsManagementServices ListService = new ListsManagementServices(context);

                await ListService.CreateList(testLists5);

                var List1Answer = context.ListsTable.FirstOrDefault(c => c.ID == testLists5.ID);

                Assert.Equal(testLists5, List1Answer);
            }
        }

        //getonelist
        [Fact]
        public async void TestGetOneList()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("GetOneList").Options;

            using (PADbcontext context = new PADbcontext(options))
            {

                Lists testLists6 = new Lists();
                testLists6.ID = 1;
                testLists6.UserID = "aUserName";
                testLists6.ListName = "ToDoList";

                ListsManagementServices ListService = new ListsManagementServices(context);

                await ListService.CreateList(testLists6);

                var List2Answer = await ListService.GetOneList(testLists6.UserID);

                Assert.Equal(testLists6, List2Answer);
            }
        }

        //getalllists
        [Fact]
        public async void TestGetAllLists()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("GetAllLists").Options;

            using (PADbcontext context = new PADbcontext(options))
            {

                Lists testLists7 = new Lists();
                testLists7.ID = 1;
                testLists7.UserID = "aUserName";
                testLists7.ListName = "ToDoList";

                Lists testLists8 = new Lists();
                testLists8.ID = 2;
                testLists8.UserID = "aDiffUserName";
                testLists8.ListName = "DiffToDoList";

                ListsManagementServices ListService = new ListsManagementServices(context);

                await ListService.CreateList(testLists7);
                await ListService.CreateList(testLists8);

                var List3Answer = await ListService.GetAllLists();

                Assert.Equal(2, List3Answer.Count);
            }
        }

        //updatelists
        [Fact]
        public async void TestUpdateList()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("UpdateList").Options;

            using (PADbcontext context = new PADbcontext(options))
            {

                Lists testLists9 = new Lists();
                testLists9.ID = 1;
                testLists9.UserID = "aUserName";
                testLists9.ListName = "ToDoList";

                ListsManagementServices ListService = new ListsManagementServices(context);

                await ListService.CreateList(testLists9);
                testLists9.ListName = "aDiffToDoList";

                await ListService.UpdateList(testLists9);
                var expected1 = context.ListsTable.FirstOrDefault(c => c.ID == testLists9.ID);

                Assert.Equal(testLists9, expected1);
            }
        }

        //deletelists
        [Fact]
        public async void TestDeleteList()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("DeleteList").Options;

            using (PADbcontext context = new PADbcontext(options))
            {

                Lists testLists10 = new Lists();
                testLists10.ID = 1;
                testLists10.UserID = "aUserName";
                testLists10.ListName = "ToDoList";

                ListsManagementServices ListService = new ListsManagementServices(context);

                await ListService.CreateList(testLists10);

                await ListService.DeleteList(testLists10.ID);
                var expected2 = context.ListsTable.FirstOrDefault(c => c.ID == testLists10.ID);

                Assert.Null(expected2);
            }
        }

        //task=====================================================
        //getter listid
        [Fact]
        public void TestGetListID()
        {
            Tasks testTask1 = new Tasks();
            testTask1.ListID = 1;
            Assert.Equal(1, testTask1.ListID);
        }

        //setter listid
        [Fact]
        public void TestSetListID()
        {
            Tasks testTask2 = new Tasks();
            testTask2.ListID = 1;
            testTask2.ListID = 2;
            Assert.Equal(2, testTask2.ListID);
        }

        //getter Taskname
        [Fact]
        public void TestGetTaskName()
        {
            Tasks testTask3 = new Tasks();
            testTask3.TaskName = "aTaskName";
            Assert.Equal("aTaskName", testTask3.TaskName);
        }

        //setter taskname
        [Fact]
        public void TestSetTaskName()
        {
            Tasks testTask4 = new Tasks();
            testTask4.TaskName = "aTaskName";
            testTask4.TaskName = "NewTaskName";
            Assert.Equal("NewTaskName", testTask4.TaskName);
        }

        //getter description
        [Fact]
        public void TestGetDescription()
        {
            Tasks testTask5 = new Tasks();
            testTask5.Description = "aDescription";
            Assert.Equal("aDescription", testTask5.Description);
        }

        //setter description
        [Fact]
        public void TestSetDescription()
        {
            Tasks testTask6 = new Tasks();
            testTask6.Description = "aDescription";
            testTask6.Description = "NewDescription";
            Assert.Equal("NewDescription", testTask6.Description);
        }

        //getter datecreated
        [Fact]
        public void TestGetDateCreated()
        {
            Tasks testTask7 = new Tasks();
            DateTime testTime1 = new DateTime(2019, 3, 12, 1, 0, 0);
            testTask7.DateCreated = testTime1;
            Assert.Equal(testTime1, testTask7.DateCreated);
        }

        //setter datecreated
        [Fact]
        public void TestSetDateCreated()
        {
            Tasks testTask8 = new Tasks();
            DateTime testTime2 = new DateTime(2019, 3, 12, 1, 0, 0);
            DateTime testTime3 = new DateTime(2019, 3, 12, 11, 0, 0);
            testTask8.DateCreated = testTime2;
            testTask8.DateCreated = testTime3;
            Assert.Equal(testTime3, testTask8.DateCreated);
        }

        //getter planned date complete
        [Fact]
        public void TestGetPlannedDateCompleted()
        {
            Tasks testTask9 = new Tasks();
            DateTime testTime4 = new DateTime(2019, 3, 12, 1, 0, 0);
            testTask9.PlannedDateComplete = testTime4;
            Assert.Equal(testTime4, testTask9.PlannedDateComplete);
        }

        //setter planned date completed
        [Fact]
        public void TestSetPlannedDateCompleted()
        {
            Tasks testTask10 = new Tasks();
            DateTime testTime5 = new DateTime(2019, 3, 12, 1, 0, 0);
            DateTime testTime6 = new DateTime(2019, 3, 12, 11, 0, 0);
            testTask10.PlannedDateComplete = testTime5;
            testTask10.PlannedDateComplete = testTime6;
            Assert.Equal(testTime6, testTask10.PlannedDateComplete);
        }

        //getter completed date
        [Fact]
        public void TestGetCompletedDate()
        {
            Tasks testTask11 = new Tasks();
            DateTime testTime7 = new DateTime(2019, 3, 12, 1, 0, 0);
            testTask11.CompletedDate = testTime7;
            Assert.Equal(testTime7, testTask11.CompletedDate);
        }

        //setter completed date
        [Fact]
        public void TestSetCompletedDate()
        {
            Tasks testTask12 = new Tasks();
            DateTime testTime8 = new DateTime(2019, 3, 12, 1, 0, 0);
            DateTime testTime9 = new DateTime(2019, 3, 12, 11, 0, 0);
            testTask12.CompletedDate = testTime8;
            testTask12.CompletedDate = testTime8;
            Assert.Equal(testTime8, testTask12.CompletedDate);
        }

        //getter is complete
        [Fact]
        public void TestGetIsComplete()
        {
            Tasks testTask13 = new Tasks();
            testTask13.IsComplete = false;
            Assert.False(testTask13.IsComplete);
        }

        //setter is complete
        [Fact]
        public void TestSetIsComplete()
        {
            Tasks testTask14 = new Tasks();
            testTask14.IsComplete = false;
            testTask14.IsComplete = true;
            Assert.True(testTask14.IsComplete);
        }

        //create task
        [Fact]
        public async void TestCreateTask()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("CreateTask").Options;

            using (PADbcontext context = new PADbcontext(options))
            {
                DateTime testTime10 = new DateTime(2019, 3, 1, 11, 0, 0);
                DateTime testTime11 = new DateTime(2019, 3, 2, 11, 0, 0);
                DateTime testTime12 = new DateTime(2019, 3, 3, 11, 0, 0);
                Tasks testTask15 = new Tasks();
                testTask15.ID = 1;
                testTask15.ListID = 1;
                testTask15.TaskName = "aTask";
                testTask15.Description = "aDescription";
                testTask15.DateCreated = testTime10;
                testTask15.PlannedDateComplete = testTime11;
                testTask15.CompletedDate = testTime12;
                testTask15.IsComplete = false;

                TasksManagementServices TaskService = new TasksManagementServices(context);

                await TaskService.CreateTask(testTask15);

                var Task1Answer = context.TasksTable.FirstOrDefault(c => c.ID == testTask15.ID);

                Assert.Equal(testTask15, Task1Answer);
            }
        }

        //getonetask
        [Fact]
        public async void TestGetOneTask()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("GetOneTask").Options;

            using (PADbcontext context = new PADbcontext(options))
            {
                DateTime testTime13 = new DateTime(2019, 3, 4, 11, 0, 0);
                DateTime testTime14 = new DateTime(2019, 3, 5, 11, 0, 0);
                DateTime testTime15 = new DateTime(2019, 3, 6, 11, 0, 0);
                Tasks testTask16 = new Tasks();
                testTask16.ID = 1;
                testTask16.ListID = 1;
                testTask16.TaskName = "aTask";
                testTask16.Description = "aDescription";
                testTask16.DateCreated = testTime13;
                testTask16.PlannedDateComplete = testTime14;
                testTask16.CompletedDate = testTime15;
                testTask16.IsComplete = false;

                TasksManagementServices TaskService = new TasksManagementServices(context);

                await TaskService.CreateTask(testTask16);

                var Task2Answer = await TaskService.GetOneTask(testTask16.ListID);

                Assert.Equal(testTask16, Task2Answer);
            }
        }

        //get all tasks
        [Fact]
        public async void TestGetAllTasks()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("GetAllTask").Options;

            using (PADbcontext context = new PADbcontext(options))
            {
                DateTime testTime16 = new DateTime(2019, 3, 4, 11, 0, 0);
                DateTime testTime17 = new DateTime(2019, 3, 5, 11, 0, 0);
                DateTime testTime18 = new DateTime(2019, 3, 6, 11, 0, 0);
                Tasks testTask17 = new Tasks();
                testTask17.ID = 1;
                testTask17.ListID = 1;
                testTask17.TaskName = "aTask";
                testTask17.Description = "aDescription";
                testTask17.DateCreated = testTime16;
                testTask17.PlannedDateComplete = testTime17;
                testTask17.CompletedDate = testTime18;
                testTask17.IsComplete = false;

                DateTime testTime19 = new DateTime(2019, 3, 4, 11, 0, 0);
                DateTime testTime20 = new DateTime(2019, 3, 5, 11, 0, 0);
                DateTime testTime21 = new DateTime(2019, 3, 6, 11, 0, 0);
                Tasks testTask18 = new Tasks();
                testTask18.ID = 2;
                testTask18.ListID = 1;
                testTask18.TaskName = "aDiffTask";
                testTask18.Description = "aDiffDescription";
                testTask18.DateCreated = testTime19;
                testTask18.PlannedDateComplete = testTime20;
                testTask18.CompletedDate = testTime21;
                testTask18.IsComplete = false;


                TasksManagementServices TaskService = new TasksManagementServices(context);

                await TaskService.CreateTask(testTask17);
                await TaskService.CreateTask(testTask18);

                var Task3Answer = await TaskService.GetAllTasks();

                Assert.Equal(2, Task3Answer.Count);
            }
        }

        //update task
        [Fact]
        public async void TestUpdateTask()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("UpdateTask").Options;

            using (PADbcontext context = new PADbcontext(options))
            {
                DateTime testTime22 = new DateTime(2019, 3, 4, 11, 0, 0);
                DateTime testTime23 = new DateTime(2019, 3, 5, 11, 0, 0);
                DateTime testTime24 = new DateTime(2019, 3, 6, 11, 0, 0);
                Tasks testTask19 = new Tasks();
                testTask19.ID = 1;
                testTask19.ListID = 1;
                testTask19.TaskName = "aTask";
                testTask19.Description = "aDescription";
                testTask19.DateCreated = testTime22;
                testTask19.PlannedDateComplete = testTime23;
                testTask19.CompletedDate = testTime24;
                testTask19.IsComplete = false;

                TasksManagementServices TaskService = new TasksManagementServices(context);

                await TaskService.CreateTask(testTask19);
                testTask19.IsComplete = true;

                await TaskService.UpdateTask(testTask19);
                var expected3 = context.TasksTable.FirstOrDefault(c => c.ID == testTask19.ID);

                Assert.Equal(testTask19, expected3);
            }
        }

        //delete task
        [Fact]
        public async void TestDeleteTask()
        {
            DbContextOptions<PADbcontext> options = new DbContextOptionsBuilder<PADbcontext>().UseInMemoryDatabase("DeleteTask").Options;

            using (PADbcontext context = new PADbcontext(options))
            {
                DateTime testTime25 = new DateTime(2019, 3, 4, 11, 0, 0);
                DateTime testTime26 = new DateTime(2019, 3, 5, 11, 0, 0);
                DateTime testTime27 = new DateTime(2019, 3, 6, 11, 0, 0);
                Tasks testTask20 = new Tasks();
                testTask20.ID = 1;
                testTask20.ListID = 1;
                testTask20.TaskName = "aTask";
                testTask20.Description = "aDescription";
                testTask20.DateCreated = testTime25;
                testTask20.PlannedDateComplete = testTime26;
                testTask20.CompletedDate = testTime27;
                testTask20.IsComplete = false;

                TasksManagementServices TaskService = new TasksManagementServices(context);

                await TaskService.CreateTask(testTask20);

                await TaskService.DeleteTask(testTask20.ID);
                var expected4 = context.TasksTable.FirstOrDefault(c => c.ID == testTask20.ID);

                Assert.Null(expected4);
            }
        }

    }
}
