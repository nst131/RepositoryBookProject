using BookBLL.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookWebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UniqueIsbnAtCreateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IUniqueISBN)validationContext.GetService(typeof(IUniqueISBN));

            if (service is null)
                throw new NullReferenceException($"{nameof(service)} is null check your attributes");

            return !service.IsUniqueAtCreate((string)value).Result ? new ValidationResult($"ISBN has Existed yet") : null;
        }
    }
}
