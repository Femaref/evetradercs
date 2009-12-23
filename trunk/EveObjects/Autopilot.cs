using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EveObjects
{
    public class Autopilot : Singleton<Autopilot>
    {
        public IList<SolarSystem> GetRoute(SolarSystem from, SolarSystem to)
        {
            return this.GetRoute(from.Id, to.Id);
        }
        public IList<SolarSystem> GetRoute(double fromSolarSystem, double toSolarSystem)
        {
            if (fromSolarSystem == toSolarSystem)
            {
                return new List<SolarSystem>();
            }

            MapWave wave = new MapWaveFactory(fromSolarSystem, toSolarSystem).Create();


            if (!wave.Wave.ContainsKey(toSolarSystem))
            {
                return new List<SolarSystem>();
            }

            double jump = toSolarSystem;
            IList<SolarSystem> route = new List<SolarSystem> {Objects.Instance.SolarSystems.GetSolarSystemById(jump)};

            while(wave.Rank > 0)
            {
                jump = this.TraceRoute(wave, jump);
                route.Add(Objects.Instance.SolarSystems.GetSolarSystemById(jump));
                wave.Rank --;
            }

            return route.Reverse().ToList();
        }

        private double TraceRoute(MapWave wave, double solarSystem)
        {
            foreach (SolarSystemJump jump in Objects.Instance.SolarSystemJumps.GetFromJumps(solarSystem))
            {   
                if (wave.Wave.ContainsKey(jump.ToId))
                {
                    if (wave.Wave[jump.ToId] < wave.Rank)
                    {
                        return jump.ToId;
                    }
                }
            }

            return 0;
        }
    }
}
