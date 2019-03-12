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

                var List2Answer = await ListService.GetOneList(testLists6.ID);

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
                testLists9.ListName = "aDiffToDoList";

                ListsManagementServices ListService = new ListsManagementServices(context);

                await ListService.CreateList(testLists9);

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



    }
}
