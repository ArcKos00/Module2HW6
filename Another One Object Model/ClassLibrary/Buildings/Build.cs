using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public abstract class Build : IBuilding, IProgressBar
    {
        private bool _isEnable;
        private float _maxHealth;
        private float _currentHealth;
        private int _cost;
        private string? _name;
        private float _buildTime;
        public Build(int cost, float buildingTime, float health)
        {
            _cost = cost;
            _maxHealth = health;
            _buildTime = buildingTime;
            Manager.GetInstance.MicroTimer += Building;
        }

        public int Cost
        {
            get { return _cost; }
        }

        public string Name
        {
            get { return _name; }
            init { _name = value; }
        }

        public float Health
        {
            get { return _maxHealth; }
        }

        public float BuildingTime
        {
            get { return _buildTime; }
        }

        public float CurrHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }

        public bool IsEnable
        {
            get { return _isEnable; }
        }

        public float Progress { get; set; }
        public void Building()
        {
            Buildings(Health / BuildingTime / 10);
        }

        public virtual void Buildings(float diff)
        {
            CurrHealth += diff;
            if (CurrHealth >= Health)
            {
                CurrHealth = Health;
                _isEnable = true;
                Manager.GetInstance.MicroTimer -= Building;
            }
        }

        public virtual void ProgressBar()
        {
        }
    }
}