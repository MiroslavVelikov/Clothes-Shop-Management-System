namespace TestClotheContext
{
    using Business;
    using Data.Entities;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class Tests
    {
        private ClotheBusiness clotheBusiness = new ClotheBusiness();
     
        [Test]
        public void ClotheCanBeAddedToDatabase()
        {
            Clothe clothe = new Clothe
            {
                Type = "Large",
                Name = "Shirt", 
                Quantity = 5,
                Price = 29.99m,
                Sex = "Male",
                City = "Aytos",
                Delivered = true
               
            };

            Assert.AreEqual("The element is added", clotheBusiness.Add(clothe),
                "Clothe can not be added to database");
        }

        [Test]
        public void GetAllClothesFromDatabase()
        {
            List<Clothe> clothes = clotheBusiness.GetAll();

            Assert.AreEqual(clothes.Count, clotheBusiness.GetAll().Count, "Clothe cant be added to database");
        }

        [Test]
        public void ClotheCanBeFoundById()
        {
            var clothes = clotheBusiness.GetAll();
            var lastClotheId = clothes[clothes.Count - 1].Id;

            Assert.AreEqual(lastClotheId, clotheBusiness.Get(lastClotheId).Id,
                "This clothe has a different Id");
        }

        [Test]
        public void UpdatingClothe()
        {

            var clothes = clotheBusiness.GetAll();
            var clothe = clothes[clothes.Count - 1];
            var clotheId = clothe.Id;
            clothe.Name = "Changed";
            clotheBusiness.Update(clothe);

            Assert.AreEqual("Changed", clotheBusiness.Get(clotheId).Name, "Clothe had to change");
        }

        [Test]
        public void DeletingClothe()
        {
            var clothes = clotheBusiness.GetAll();
            var clotheId = clothes[clothes.Count - 1].Id;

            Assert.AreEqual("Clothe was deleted", clotheBusiness.Delete(clotheId),
                "Clothe has a different name");
        }

        [Test]
        public void DeletingNotExistingClothe()
        {
            const int notExistingId = 9999999;

            Assert.AreEqual("Clothe does not exist", clotheBusiness.Delete(notExistingId),
                "Clothe exist");
        }
    }
}