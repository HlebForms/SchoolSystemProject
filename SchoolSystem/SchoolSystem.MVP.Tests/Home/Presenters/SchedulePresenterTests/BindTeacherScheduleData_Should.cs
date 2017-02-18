using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Home.Models;
using SchoolSystem.MVP.Home.Presenter;
using SchoolSystem.MVP.Home.Views;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Home.Presenters.SchedulePresenterTests
{
    [TestFixture]
    public class BindTeacherScheduleData_Should
    {
        [Test]
        public void Set_TeacherSchduleToModel_WhenArgumentsAreValid()
        {
            var mockedScheduleView = new Mock<IScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();

            var expectedSchedule = new List<ScheduleModel>()
            {
                new ScheduleModel(),
                new ScheduleModel(),
                new ScheduleModel()
            };

            var mockedModel = new ScheduleControlModel();
            var userName = "Test1";

            mockedScheduleView.SetupGet(x => x.Model)
                .Returns(mockedModel);
            mockedScheduleService.Setup(x => x.GetTeacherScheduleForTheDay(It.IsAny<DayOfWeek>(), userName))
                .Returns(expectedSchedule);

            var schedulePresenter = new SchedulePresenter(mockedScheduleView.Object, mockedScheduleService.Object);

            var args = new ScheduleEventargs() { Username = userName };

            mockedScheduleView.Raise(x => x.EventBindTeacherScheduleData += null, args);

            CollectionAssert.AreEquivalent(expectedSchedule, mockedScheduleView.Object.Model.TeacherSchedule);
        }
    }
}
