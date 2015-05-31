namespace TtitterMvc.Infrastructure.Services.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Web;
    using Ttitter.Data.Data;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.Infrastructure.ValidationErrors;

    public class BaseService : IBaseService
    {
        private ITtitterData ttitterData;

        public BaseService(ITtitterData data)
        {
            this.Data = data;
        }

        public ITtitterData Data
        {
            get { return this.ttitterData; }
            private set
            {
                this.ttitterData = value;
            }
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            IEnumerable<DbEntityValidationResult> errors = this.Data.GetValidationErrors();
            return errors;
        }

        public int SaveChanges()
        {
            var errors = this.GetValidationErrors();
            if (errors.Any())
            {
                throw new DatabaseValidationErrors(errors);
            }
            else
            {
                try
                {
                    return this.Data.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}