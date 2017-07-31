using NUnit.Framework;

namespace SDY.UnitTestProject.TestsNUnit3
{
    [TestFixture]
    public class NUnitUnitTest1
    {
        [SetUp]
        public void Initialize()
        {
            PlassGun gun = new PlassGun();
            gun = new PlassGun();
        }

        [TearDown]
        public void Cleanup()
        {
            PlassGun gun = new PlassGun();
            gun.Recharge();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void NUnit_FireMultipleTimes(int fireCount)
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

        [TestCase(true, false)]
        [TestCase(false, true)]
        public void NUnit_TestBugDodges(bool didDodge, bool shouldBeDead)
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

        [Test]
        public void NUnit_TryShootBug()
        {
            Bug bug = new Bug();
            PlassGun gun = new PlassGun();

            gun.FireAt(bug);

            Assert.IsTrue(bug.IsDead());
            Assert.IsTrue(gun.HasAmmo());
        }

        [Test]
        public void NUnit_TryShootDodgingBug()
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
