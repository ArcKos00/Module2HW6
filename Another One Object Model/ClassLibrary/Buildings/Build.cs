using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public abstract class Build : IBuilding
    {
        private bool _isEnable;
        private float _maxHealth;
        private float _currentHealth;
        private int _cost;
        private string _name;
        private float _buildTime;
        public Build(int cost, float buildingTime, float health)
        {
            _cost = cost;
            _maxHealth = health;
            _buildTime = buildingTime;
            Building(health / buildingTime);
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

        public virtual void Building(float diff)
        {
            while (!_isEnable)
            {
                CurrHealth += diff;
                if (CurrHealth >= Health)
                {
                    CurrHealth = Health;
                    _isEnable = true;
                }
            }
        }
    }
}