﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public interface ILightManager : IManager
    {
        void SetLight(bool isOn, int lightID);

        void SetAllLights(bool isOn);
    }
}
