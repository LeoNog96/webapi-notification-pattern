using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NotificationPattern.Application.Validators
{
    public class BaseValidator
    {
		[JsonIgnore]
		public bool Valid { get; private set; }
		
		[JsonIgnore]
		public bool Invalid => !Valid;
		
		[JsonIgnore]
		public ValidationResult ValidationResult { get; private set; }

		public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
		{
			ValidationResult = validator.Validate(model);
			return Valid = ValidationResult.IsValid;
		}
	}
}
