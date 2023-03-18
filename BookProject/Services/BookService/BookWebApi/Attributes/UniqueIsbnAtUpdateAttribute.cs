using BookBLL.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookWebApi.Attributes
{ 
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UniqueIsbnAtUpdateAttribute : ValidationAttribute
    {
        private readonly string idAbbreviation;
        private readonly string isbnAbbreviation;

        public UniqueIsbnAtUpdateAttribute(string idAbbreviation, string isbnAbbreviation)
        {
            this.idAbbreviation = idAbbreviation;
            this.isbnAbbreviation = isbnAbbreviation;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IUniqueISBN)validationContext.GetService(typeof(IUniqueISBN));

            if (service is null)
                throw new NullReferenceException($"{nameof(service)} is null check your attributes");

            var id = (int)value.GetType().GetProperty(this.idAbbreviation)?.GetValue(value);
            var isbn = (string)value.GetType().GetProperty(this.isbnAbbreviation)?.GetValue(value);


            return !service.IsUniqueAtUpdate(isbn, id).Result ? new ValidationResult($"ISBN has Existed yet") : null;
        }
    }
}
