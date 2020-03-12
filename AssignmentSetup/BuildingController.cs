using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public class BuildingController
    {
        private IDoorManager doorManager;
        private IEmailService emailService;
        private IFireAlarmManager fireAlarm;
        private ILightManager lightManager;
        private IWebService webService;

        public string buildingID { get; set; }

        public string previousState { get; set; }

        public string currentState { get; set; }
        public BuildingController (string id)
        {
            string idLower = id.ToLower();

            buildingID = idLower;

            currentState = "out of hours";
        }

        public BuildingController (string id, string startState)
        { // needs testing
            string idLower = id.ToLower();
            string startStateLower = startState.ToLower();
            currentState = "out of hours";
            buildingID = idLower;

            if (startStateLower == "closed" || startStateLower == "out of hours" || startStateLower == "open")
            {
                currentState = startStateLower;
            }
            else
            {
                throw new ArgumentException("Arguement Exception: BuildingController an only be initialised to the following states 'open', 'closed', 'out of hours'");

            }
        }

        public BuildingController (string id, ILightManager iLightManager, IFireAlarmManager iFireAlarmManager, 
                                    IDoorManager iDoorManager, IWebService iWebService, IEmailService iEmailService)
        {
            string idLower = id.ToLower();
            buildingID = idLower;
            currentState = "out of hours";
            lightManager = iLightManager;
            fireAlarm = iFireAlarmManager;
            doorManager = iDoorManager;
            webService = iWebService;
            emailService = iEmailService;
        }

        public string GetBuildingID()
        {
            return buildingID;
        }

        public string GetStatusReport()
        {
            char f = 'F';

            string errors = "";

            for (int i = 0; i < lightManager.GetStatus().Length; i++)
            {
                if (lightManager.GetStatus()[i] == f)
                {
                    errors = errors + "Lights,";
                    break;
                }
            }

            for (int i = 1; i < fireAlarm.GetStatus().Length; i++)
            {
                if (fireAlarm.GetStatus()[i] == f)
                {
                    errors = errors + "Fire Alarm,";
                    break;
                }
            }

            for (int i = 0; i < doorManager.GetStatus().Length; i++)
            {
                if (doorManager.GetStatus()[i] == f)
                {
                    errors = errors + "Doors,";
                    break;
                }
            }

            if (errors != "")
            {
                webService.LogEngineerRequired(errors);
            }
            return lightManager.GetStatus() + doorManager.GetStatus() + fireAlarm.GetStatus();

        }

        public string GetPreviousState()
        {
            return previousState;
        }

        public string SetBuildingID(string id)
        {
            string idLower = id.ToLower();

            buildingID = idLower;

            return buildingID;
        }

        public string SetPreviousState(string previous)
        {
            string stateLower = previous.ToLower();
            previousState = stateLower;

            return previousState;
            
        }

        public string GetCurrentState()
        {

            return currentState;
        }

        public bool SetCurrentState(string state)
        {
            string lowerState = state.ToLower();

            if (lowerState != "open" && lowerState != "closed" && lowerState != "fire alarm" && lowerState != "fire drill" && lowerState != "out of hours") return false;

            if (currentState == "open" && lowerState == "closed" || currentState == "closed" && lowerState == "open") return false;

            if (currentState == "fire drill" || currentState == "fire alarm" && lowerState != GetPreviousState()) return false;

            if (lowerState == "open")
            {
                doorManager.OpenAllDoors();
                if (doorManager.OpenAllDoors() == false) 
                    currentState = currentState;

            }
            if (lowerState == "closed")
            {
                doorManager.LockAllDoors();
                lightManager.SetAllLights(false);
            }
            if (lowerState == "fire alarm")
            {
                fireAlarm.SetAlarm(true);
                doorManager.OpenAllDoors();
                lightManager.SetAllLights(true);

                try
                {
                    webService.LogFireAlarm("fire alarm");
                }
                catch (ArgumentException e)
                {
                    emailService.SendEmail("smartbuilding@uclan.ac.uk", "failed to log alarm", e.Message);
                }
            }
            SetPreviousState(currentState);
            currentState = lowerState;
            return true;
        } 
    }
}
