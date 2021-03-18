namespace TestingClothe
{
    using NUnit.Framework;
    using Data.Entities;

    public class Tests
    {
        [Test]
        public void ClotheIdTest()
        {
            Clothe clothe = new Clothe();
            clothe.Id = 1;

            Assert.AreEqual(1, clothe.Id, "Clothe Id is different");
        }

        [Test]
        public void ClotheHasTypeTest()
        {
            Clothe clothe = new Clothe();
            clothe.Type = "Large";

            Assert.AreEqual("Large", clothe.Type, "Clothe has a different type");
        }

        [Test]
        public void ClotheHasANameTest()
        {
            Clothe clothe = new Clothe();
            clothe.Name = "Shirt";

            Assert.AreEqual("Shirt", clothe.Name, "Clothe has a different name");
        }

        [Test]
        public void ClotheQuantityTest()
        {
            Clothe clothe = new Clothe();
            clothe.Quantity = 5;

            Assert.AreEqual(5, clothe.Quantity, "Clothe has a different quantity");
        }

        [Test]
        public void ClotheHasAPriceTest()
        {
            Clothe clothe = new Clothe();
            clothe.Price = 29.99m;

            Assert.AreEqual(29.99m, clothe.Price, "Clothe has a different price");
        }

        [Test]
        public void ClotheIsSoldOfThisSexTest()
        {
            Clothe clothe = new Clothe();
            clothe.Sex = "Male";

            Assert.AreEqual("Male", clothe.Sex, "Clothe is for the opossite sex");
        }

        [Test]
        public void ClotheIsInThisSector()
        {
            Clothe clothe = new Clothe();
            clothe.Delivered = true;

            Assert.AreEqual(true, clothe.Delivered, "Clothe is for a different sector");
        }

        [Test]
        public void ClothingIsSoldInThisCity()
        {
            Clothe clothe = new Clothe();
            clothe.City = "Aytos";

            Assert.AreEqual("Aytos", clothe.City, "Clothing is sold in a different city");
        }
    }
}