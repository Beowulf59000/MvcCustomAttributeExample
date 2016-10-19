using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvcCustomAttributeExample.CustomAttributes
{
    /// <summary>
    /// Spécifie qu'une valeur de champ de données est requise et est liée à une case à cocher
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredWithRadioButtonAttribute : ValidationAttribute
    {
        /// <summary>
        /// Nom de la propriété de la case à cocher
        /// </summary>
        private String _radioButtonProperty;

        /// <summary>
        /// Valeur de la case à cocher à tester
        /// </summary>
        private String _valueToCompare;

        /// <summary>
        /// Initialise une nouvelle instance de la classe RequiredWithRadioButton
        /// </summary>
        /// <param name="radioButtonProperty"></param>
        /// <param name="radioButtonValue"></param>
        public RequiredWithRadioButtonAttribute(String radioButtonProperty, String radioButtonValue)
        {
            _radioButtonProperty = radioButtonProperty;
            _valueToCompare = radioButtonValue;
        }

        /// <summary>
        /// Vérifie que la valeur du champ de données requis n'est pas vide.
        /// </summary>
        /// <param name="value">Valeur de champ de données à valider.</param>
        /// <param name="validationContext"></param>
        /// <returns>true si la validation réussit ; sinon, false.</returns>
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(this._radioButtonProperty);
            Object otherPropertyValue = propertyInfo.GetGetMethod().Invoke(validationContext.ObjectInstance, null);

            if (!(otherPropertyValue is String))
                throw new NotSupportedException("La propriété de comparaison doit être de type string");

            String sValue = (String)otherPropertyValue;

            Boolean isEmptyValue = (value is String) ? String.IsNullOrEmpty((String)value) : (value == null); // Si on a une TextBox, elle renverra une chaine vide plutôt que null

            if (isEmptyValue && String.Equals(sValue, _valueToCompare))
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

            return ValidationResult.Success;
        }
    }
}
