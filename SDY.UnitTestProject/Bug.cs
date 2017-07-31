namespace SDY.UnitTestProject
{
    public class Bug
    {
        private bool dead;
        private bool dodging;

        public void Dodge()
        {
            dodging = true;
        }

        public void Hit()
        {
            dead = true;
        }

        public bool IsDead()
        {
            return dead;
        }

        public bool IsDodging()
        {
            return dodging;
        }

        public void Miss()
        {
            dodging = false;
        }
    }
}
