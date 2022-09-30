using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Services;

namespace ClassLibrary
{
    public class BuildsManager
    {
        private static BuildsManager _instance = new BuildsManager();
        private Build[] _builds;
        private BuildsManager()
        {
            _builds = new Build[0];
        }

        public static BuildsManager GetInstance
        {
            get
            {
                return _instance;
            }
            set
            {
                if (_instance == null)
                {
                    _instance = new BuildsManager();
                }
            }
        }

        public Build[] Builds
        {
            get { return _builds; }
        }

        public void Add(bool rand = true, string? build = null)
        {
            Service.AddResize<Build>(ref _builds);
            if (rand)
            {
                _builds[_builds.Length - 1] = RandomBuild();
            }
            else
            {
                _builds[_builds.Length - 1] = AddBuild(build);
            }
        }

        public void Remove(int index)
        {
            Manager.GetInstance.MicroTimer -= _builds[_builds.Length - 1].ProgressBar;
            Service.RemoveResize<Build>(ref _builds, index);
        }

        public Build AddBuild(string name)
        {
            switch (name)
            {
                case "Farm":
                    return BuildSpawner.SpawnFarm();
                case "Iron":
                    return BuildSpawner.SpawnIronMine();
                case "Gold":
                    return BuildSpawner.SpawnGoldMine();
                case "Barracks":
                    return BuildSpawner.SpawnBarracks();
                default:
                    return null;
            }
        }

        private Build RandomBuild()
        {
            switch (new Random().Next(0, 4))
            {
                case 0:
                    return BuildSpawner.SpawnFarm();
                case 1:
                    return BuildSpawner.SpawnGoldMine();
                case 2:
                    return BuildSpawner.SpawnIronMine();
                case 3:
                    return BuildSpawner.SpawnBarracks();
                default:
                    return null;
            }
        }
    }
}
