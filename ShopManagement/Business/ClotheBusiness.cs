namespace Business
{
    using Data;
    using System.Linq;
    using Data.Entities;
    using System.Collections.Generic;

    public class ClotheBusiness
    {
        private ClotheContext clotheContext;

        /// <summary>
        /// Get all clothes from the database
        /// </summary>
        public List<Clothe> GetAll()
        {
            using (clotheContext = new ClotheContext())
            {
                return clotheContext.Clothes.ToList();
            }
        }

        /// <summary>
        /// Get single clothe from the database by Id
        /// </summary>
        public Clothe Get(int id)
        {
            using (clotheContext = new ClotheContext())
            {
                return clotheContext.Clothes.Find(id);

            }
        }

        /// <summary>
        /// Add a product to the database
        /// </summary>
        public string Add(Clothe clothe)
        {
            using (clotheContext = new ClotheContext())
            {
                clotheContext.Clothes.Add(clothe);
                
                clotheContext.SaveChanges();
            }

            return "The element is added";
        }

        /// <summary>
        /// Update a single clothe in the database by Id.
        /// </summary>
        public void Update(Clothe clothe)
        {
            using (clotheContext = new ClotheContext())
            {
                var item = clotheContext.Clothes.Find(clothe.Id);
                if (item != null)
                {
                    clotheContext.Entry(item).CurrentValues.SetValues(clothe);
                    clotheContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deleate a clothe from the database by Id
        /// </summary>
        public string Delete(int id)
        {
            using (clotheContext = new ClotheContext())
            {
                var product = clotheContext.Clothes.Find(id);
                if (product != null)
                {
                    clotheContext.Clothes.Remove(product);
                    clotheContext.SaveChanges();
                    return "Clothe was deleted";
                }

                return "Clothe does not exist";
            }
        }
    }
}
