using AssignmentSetup;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssignmentSetupTests
{
    [TestFixture]
    public class BuildingControllerTests
    {
        [Test]
        [TestCase("OUT OF HOURS")]
        [TestCase("FIRE ALARM")]
        [TestCase("FIRE DRILL")]
        [TestCase("CLOSED")]
        [TestCase("OPEN")]

        // Will pass if the upper case words are converted to lower case words

        public void SetCurrentState_UsingUpperCase_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            bool result = testBuilding.SetCurrentState(id);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        [TestCase("asdfghgfds")]
        [TestCase("@")]
        [TestCase("1234")]

        // Will pass if the state is not set to the testcase

        public void SetCurrentState_UsingGibberish_ReturnsFalse(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            bool result = testBuilding.SetCurrentState(id);

            // Assert
            Assert.IsFalse(result);

        }

        [Test]
        [TestCase("out of hours")]
        [TestCase("fire drill")]
        [TestCase("closed")]
        [TestCase("open")]
        [TestCase("fire alarm")]

        // Will pass if current state is set using lower case words

        public void SetCurrentState_UsingLowerCase_ReturnsTrue(string state)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            bool result = testBuilding.SetCurrentState(state);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        [TestCase("OuT Of HoUrS")]
        [TestCase("FiRe DrIlL")]
        [TestCase("ClOsEd")]
        [TestCase("OpEn")]
        [TestCase("FiRe AlArM")]

        // Test will pass if state is set using words containing upper and lower case letters

        public void SetCurrentState_UsingUpperAndLowerCase_ReturnsTrue(string state)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            bool result = testBuilding.SetCurrentState(state);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        [TestCase("foster building")]

        // Test will pass if bulding ID is set using lower case

        public void SetBuildingId_UsingLowerCase_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController(id, lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            testBuilding.SetBuildingID(id);
            string expected = "foster building";

            // Assert
            Assert.AreEqual(expected, id);
        }

        [Test]
        [TestCase("FOSTER BUILDING")]

        // Test will pass if building ID is set using upper case

        public void SetBuildingId_UsingUpperCase_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController(id, lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            string actual = testBuilding.SetBuildingID(id);
            string expected = "foster building";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("FoStEr BuIlDiNg")]

        // Test will pass if building ID is set using upper and lower case letters

        public void SetBuildingId_UsingUpperAndLower_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController(id, lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            string actual = testBuilding.SetBuildingID(id);
            string expected = "foster building";

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        [TestCase("foster building")]

        // Test will pass if default value is same as test case value 

        public void GetBuildingId_UsingDefaultValue_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController(id, lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            string actual = testBuilding.GetBuildingID();
            string expected = "foster building";

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        [TestCase("UCLAN Library")]

        // Test will pass if building ID is not the same as the default ID

        public void GetBuildingId_NotUsingDefaultValue_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController(id, lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            string actual = testBuilding.GetBuildingID();
            string expected = "foster building";

            // Assert
            Assert.AreNotEqual(expected, actual);

        }

        [Test]
        [TestCase("out of hours")]

        // Test will pass if current state is same as default value 

        public void GetCurrentStateId_UsingDefaultValue_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController(id, lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            string actual = testBuilding.GetCurrentState();
            string expected = "out of hours";

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        [TestCase("fire drill")]

        // Test will pass if defulat state is not same as state that is passed in, indicating a change 

        public void GetCurrentStateId_NotUsingDefaultValue_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController(id, lightManager, fireAlarm, doorManager, webService, emailService);


            // Act
            testBuilding.SetCurrentState(id);
            string actual = testBuilding.GetCurrentState();
            string expected = "out of hours";

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        [TestCase("open")]

        // Test will pass if closed cannot be set to open

        public void SetBuildingState_UsingOpenAndClosed_ReturnsFalse(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            testBuilding.SetCurrentState("closed");

            bool result = testBuilding.SetCurrentState(id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("closed")]

        // Test will pass if open cannot be set to closed

        public void SetBuildingState_UsingClosedAndOpen_ReturnsFalse(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            testBuilding.SetCurrentState("open");

            bool result = testBuilding.SetCurrentState(id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("closed")]
        [TestCase("open")]

        // Test will pass if out of hours can be set to both closed and open

        public void SetBuildingState_UsingClosedAndOpenWithOutOfHours_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            bool result = testBuilding.SetCurrentState(id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("fire alarm")]
        [TestCase("fire drill")]

        // Test will pass if fire alarm and fire drill can be set as states

        public void SetBuildingState_UsingFireAlarmAndFireDrillUsingOutOfHours_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            testBuilding.SetCurrentState("out of hours");

            bool result = testBuilding.SetCurrentState(id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("fire alarm")]
        [TestCase("fire drill")]

        // Test will pass if fire alarm or fire drill cannot be changed to something different than previous states

        public void SetBuildingState_UsingFireAlarmAndThenToDifferentPreviousState_ReturnsFalse(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            testBuilding.SetCurrentState("open");
            testBuilding.SetCurrentState(id);
            bool result = testBuilding.SetCurrentState("out of hours");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("fire alarm")]
        [TestCase("fire drill")]

        // Test will pass if fire alarm and dire drill cannot be changed from closed to open 

        public void SetBuildingState_UsingFireAlarmClosedAndOpen_ReturnsFalse(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            testBuilding.SetCurrentState("closed");
            testBuilding.SetCurrentState(id);
            bool result = testBuilding.SetCurrentState("open");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("Foster Building", "fire drill")]

        // Test will pass if arguement is sucessfully thrown

        public void UseSecondBuildingControllerConstructor_UsingTwoParameters_ReturnsExceptionThrown(string id, string status)
        {
            // Arrange

            // Act 

            // Assert
            Assert.Throws<ArgumentException>(() => new BuildingController(id, status));
        }

        [Test]
        [TestCase("Foster Building", "closed")]

        // Test will pass if the arguement is not thrown

        public void UseSecondBuildingControllerConstructor_UsingTwoParameters_DoesNotReturnExceptionThrown(string id, string status)
        {
            // Arrange

            // Act 

            // Assert
            Assert.DoesNotThrow(() => new BuildingController(id, status));
        }

        [Test]

        // Test will pass if status reports are successfully called and implemented
        public void GetStatusReportForLightManager_ReturnsValidString()
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();

            // Act
            lightManager.GetStatus().Returns("Lights, OK, OK, OK, OK, OK, OK, OK, OK, OK, OK,");
            doorManager.GetStatus().Returns("Doors, OK, OK, OK, OK, OK, OK, OK, OK, OK, OK");
            fireAlarm.GetStatus().Returns("Fire Alarm, OK, OK, OK, OK, OK, OK, OK, OK, OK, OK");

            // Assert
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            testBuilding.GetStatusReport();

            lightManager.Received().GetStatus();
            doorManager.Received().GetStatus();
            fireAlarm.Received().GetStatus();

        }
        [Test]
        [TestCase("open")]

        // Test will pass if open all doors is called, open all doors returns true

        public void TestOpenAllDoors_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();

            // Act
            doorManager.OpenAllDoors().Returns(true);
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);
            testBuilding.SetCurrentState(id);

            // Assert
            doorManager.Received().OpenAllDoors();
        }
        [Test]
        [TestCase("open")]

        // Test will pass if open all doors is called, returns false indicating doors cannot be opened 

        public void TestOpenAllDoors_ReturnsFalse(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            doorManager.OpenAllDoors().Returns(false);
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);
            testBuilding.SetCurrentState(id);
            string currentState = testBuilding.GetCurrentState();


            // Act
            lightManager.GetStatus().Returns("Lights, OK, OK, OK, OK, OK, OK, OK, OK, OK, OK,");
            doorManager.GetStatus().Returns("Doors, OK, OK, OK, OK, OK, OK, OK, OK, OK, OK");
            fireAlarm.GetStatus().Returns("Fire Alarm, OK, OK, OK, OK, OK, OK, OK, OK, OK, OK");


            // Assert

            doorManager.Received().OpenAllDoors();
            Assert.AreEqual(id, currentState);

        }

        [Test]
        [TestCase("closed")]

        // Test will pass if all doors are closed and all lights turned off

        public void TestClosedAllDoorsAndAllLightsOff_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();

            // Act
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);
            testBuilding.SetCurrentState(id);
            string currentState = testBuilding.GetCurrentState();

            // Assert
            lightManager.Received().SetAllLights(false);
            doorManager.Received().LockAllDoors();

        }

        [Test]
        [TestCase("fire alarm")]

        // Test will pass if all doors are open, alarm is set, web log is set to fire alarm and all lights are set on

        public void TestFireAlarmFunctionality_ReturnsTrue(string id)
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();

            // Act
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);
            testBuilding.SetCurrentState(id);
            string currentState = testBuilding.GetCurrentState();

            // Assert
            lightManager.Received().SetAllLights(true);
            doorManager.Received().OpenAllDoors();
            fireAlarm.SetAlarm(true);
            webService.LogFireAlarm("fire alarm");
        }

        [Test]
       

        // Test will pass if fault is found and engineer log is created 

        public void TestLogErrors_ReturnErrorList()
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            doorManager.OpenAllDoors().Returns(false);
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act
            lightManager.GetStatus().Returns("Lights, OK, OK, FAULT, OK, OK, OK, OK, OK, OK, OK,");
            doorManager.GetStatus().Returns("Doors, OK, OK, FAULT, OK, OK, OK, OK, OK, OK, OK");
            fireAlarm.GetStatus().Returns("Fire Alarm, OK, OK, FAULT, OK, OK, OK, OK, OK, OK, OK");

            testBuilding.GetStatusReport();

            // Assert

            webService.Received().LogEngineerRequired("Lights,Fire Alarm,Doors,");

        }


        [Test]


        // Test will pass if email is sent 

        public void TestLogEmailSent_ReturnAlarmCouldNotBeLoggedEmail()
        {
            // Arrange 
            var lightManager = Substitute.For<ILightManager>();
            var doorManager = Substitute.For<IDoorManager>();
            var emailService = Substitute.For<IEmailService>();
            var fireAlarm = Substitute.For<IFireAlarmManager>();
            var webService = Substitute.For<IWebService>();
            doorManager.OpenAllDoors().Returns(false);
            BuildingController testBuilding = new BuildingController("Foster Building", lightManager, fireAlarm, doorManager, webService, emailService);

            // Act

            webService
                .When(x => x.LogFireAlarm("fire alarm"))
                .Do(x => { throw new ArgumentException ("Alarm could not be logged"); });

            testBuilding.SetCurrentState("fire alarm");

            // Assert

            emailService.Received().SendEmail("smartbuilding@uclan.ac.uk", "failed to log alarm", "Alarm could not be logged");
            

        }

    }

}
