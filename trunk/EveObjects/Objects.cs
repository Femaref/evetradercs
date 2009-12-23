using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EveObjects;
using EveObjects.Resources;

namespace EveObjects
{
    public class Objects : Singleton<Objects>
    {
        public Autopilot Autopilot
        {
            get
            {
                return EveObjects.Autopilot.Instance;
            }
        }

        public Types Types
        {
            get
            {
                return EveObjects.Types.Instance;
            }
        }

        public Stations Stations
        {
            get
            {
                return EveObjects.Stations.Instance;
            }
        }

        public SolarSystems SolarSystems
        {
            get
            {
                return EveObjects.SolarSystems.Instance;
            }
        }

        public SolarSystemJumps SolarSystemJumps
        {
            get
            {
                return EveObjects.SolarSystemJumps.Instance;
            }
        }
        public void ClearResourceCache()
        {
            ResourceManager.ClearResourceCache();
        }
    }
}
