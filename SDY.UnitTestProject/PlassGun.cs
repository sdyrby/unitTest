namespace SDY.UnitTestProject
{
    public class PlassGun
    {
        private int ammo = 3;

        public void FireAt(Bug bug)
        {
            if (HasAmmo())
            {
                if (bug.IsDodging())
                {
                    bug.Miss();
                }
                else
                {
                    bug.Hit();
                    //bug.Miss();
                }
                ammo--;
            }
        }

        public bool HasAmmo()
        {
            return ammo > 0;
        }

        public void Recharge()
        {
            ammo = 3;
        }
    }
}
