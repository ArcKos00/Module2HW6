using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static BuildsManager Instance
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

        public void AddResize()
        {
            Build[] newArr = new Build[_builds.Length + 1];

            for (int i = 0; i < _builds.Length; i++)
            {
                newArr[i] = _builds[i];
            }

            _builds = newArr;
            _builds[_builds.Length - 1] = RandomBuild();
        }

        public void RemoveResize()
        {
            Build[] newArr = new Build[_builds.Length - 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = _builds[i];
            }

            _builds = newArr;
        }

        private Build RandomBuild()
        {
            switch (new Random().Next(0, 4))
            {
                case 0:
                    return BuildSpawner.SpawnFarm();
                    break;
                case 1:
                    return BuildSpawner.SpawnGoldMine();
                    break;
                case 2:
                    return BuildSpawner.SpawnIronMine();
                    break;
                case 3:
                    return BuildSpawner.SpawnBarracks();
                    break;
                default:
                    return null;
            }
        }
    }
}
