namespace Business
{
    using Data;
    using Data.Entities;

    public class LastLogBusiness
    {
        private LastLogContext lastLogContext;

        /// <summary>
        /// Get single log from the database by Id
        /// </summary>
        public LastLog Get(int id)
        {
            using (lastLogContext = new LastLogContext())
            {
                return lastLogContext.LastLog.Find(id);
            }
        }

        /// <summary>
        /// Update a single log in the database by Id.
        /// </summary>
        public string Update(LastLog log)
        {
            using (lastLogContext = new LastLogContext())
            {
                var item = lastLogContext.LastLog.Find(log.Id);
                if (item != null)
                {
                    lastLogContext.Entry(item).CurrentValues.SetValues(log);
                    lastLogContext.SaveChanges();
                }
            }

            return "The elemnt was updated";
        }
    }
}
