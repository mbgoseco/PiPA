using PiPA.Models;
using System;
using Xunit;

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
            testList3.ListName = "aName";
            Assert.Equal("aName", testList3.ListName);
        }

        //setter for list name
        [Fact]
        public void TestsetLastName()
        {
            Lists testList4 = new Lists();
            testList4.ListName = "aName";
            testList4.ListName = "NewName";
            Assert.Equal("NewName", testList4.ListName);
        }

        //task=====================================================
        //getter listid
        [Fact]
        public void TestGetListID()
        {

        }

        //setter listid
        [Fact]
        public void TestSetListID()
        {

        }

        //getter Taskname
        [Fact]
        public void TestGetTaskName()
        {

        }

        //setter taskname
        [Fact]
        public void TestSetTaskName()
        {

        }

        //getter description
        [Fact]
        public void TestGetDescription()
        {

        }

        //setter description
        [Fact]
        public void TestSetDescription()
        {

        }

        //getter datecreated
        [Fact]
        public void TestGetDateCreated()
        {

        }

        //setter datecreated
        [Fact]
        public void TestSetDateCreated()
        {

        }

        //getter planned date complete
        [Fact]
        public void TestGetPlannedDateCompleted()
        {

        }

        //setter planned date completed
        [Fact]
        public void TestSetPlannedDateCompleted()
        {

        }

        //getter completed date
        [Fact]
        public void TestGetCompletedDate()
        {

        }

        //setter completed date
        [Fact]
        public void TestSetCompletedDate()
        {

        }

        //getter is complete
        [Fact]
        public void TestGetIsComplete()
        {

        }

        //setter is complete
        [Fact]
        public void TestSetIsComplete()
        {

        }



    }
}
