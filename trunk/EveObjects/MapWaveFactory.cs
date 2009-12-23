using System.Collections;
using System.Collections.Generic;

namespace EveObjects
{
    public class MapWaveFactory
    {
        private Stack currentLevelStack;
        private Stack nextLevelStack;
        private MapWave wave;
        private double waveFromSolarSystemId;
        private double waveToSolarSystemId;

        public MapWaveFactory(double fromSolarSystemId)
        {
            this.waveFromSolarSystemId = fromSolarSystemId;
        }
        
        public MapWaveFactory(double fromSolarSystemId, double toSolarSystemId) : this(fromSolarSystemId)
        {
            this.waveToSolarSystemId = toSolarSystemId;
        }

        public MapWave Create()
        {
            this.InitializeWave();

            while (this.ExpandWave(this.waveToSolarSystemId))
            {
            }

            return this.wave;
        }

        private void InitializeWave()
        {
            this.wave = new MapWave();
            this.wave.Rank = 0;
            this.currentLevelStack = new Stack();
            this.nextLevelStack = new Stack();

            currentLevelStack.Push(this.waveFromSolarSystemId);
            this.wave.Wave.Add(this.waveFromSolarSystemId, this.wave.Rank);
        }
        private bool ExpandWave(double toSolarSystem)
        {
            if (this.currentLevelStack.Count == 0)
            {
                return false;
            }

            this.wave.Rank ++;

            while (this.currentLevelStack.Count > 0)
            {
                double solarSystem = (double) this.currentLevelStack.Pop();

                foreach (SolarSystemJump jump in Objects.Instance.SolarSystemJumps.GetFromJumps(solarSystem))
                {   
                    if (!this.wave.Wave.ContainsKey(jump.ToId))
                    {
                        this.wave.Wave.Add(jump.ToId, this.wave.Rank);    
                        this.nextLevelStack.Push(jump.ToId);

                        if (jump.ToId == toSolarSystem)
                        {
                            return false;
                        }
                    }
                }
            }

            this.currentLevelStack = this.nextLevelStack;
            this.nextLevelStack = new Stack();

            return true;
        }
    }
}