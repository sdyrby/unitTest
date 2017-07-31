using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDY.UnitTestProject.TestsMSTestV2
{
    [TestClass]
    public class MSTESTUnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
            PlassGun gun = new PlassGun();
            gun = new PlassGun();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PlassGun gun = new PlassGun();
            gun.Recharge();
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void MSUnit_FireMultipleTimes(int fireCount)
        {
            Bug bug = new Bug();
            PlassGun gun = new PlassGun();

            for (int i = 0; i < fireCount; i++)
            {
                gun.FireAt(bug);
            }

            if (fireCount >= 3)
            {
                Assert.IsFalse(gun.HasAmmo());
            }
            else
            {
                Assert.IsTrue(gun.HasAmmo());
            }
        }

        [DataTestMethod]
        [DataRow(true, false)]
        [DataRow(false, true)]
        public void MSUnit_TestBugDodges(bool didDodge, bool shouldBeDead)
        {
            Bug bug = new Bug();
            PlassGun gun = new PlassGun();

            if (didDodge)
            {
                bug.Dodge();
            }

            gun.FireAt(bug);

            if (shouldBeDead)
            {
                Assert.IsTrue(bug.IsDead());
            }
            else
            {
                Assert.IsFalse(bug.IsDead());
            }
        }

        [TestMethod]
        public void MSUnit_TryShootBug()
        {
            Bug bug = new Bug();
            PlassGun gun = new PlassGun();

            gun.FireAt(bug);
            gun.FireAt(bug);
            gun.FireAt(bug);

            Assert.IsTrue(bug.IsDead());
            Assert.IsTrue(gun.HasAmmo());
        }

        [TestMethod]
        public void MSUnit_TryShootDodgingBug()
        {
            Bug bug = new Bug();
            PlassGun gun = new PlassGun();

            bug.Dodge();
            gun.FireAt(bug);

            bug.Dodge();
            gun.FireAt(bug);

            bug.Dodge();
            gun.FireAt(bug);

            Assert.IsFalse(bug.IsDead());
            Assert.IsFalse(gun.HasAmmo());
        }
    }
}
