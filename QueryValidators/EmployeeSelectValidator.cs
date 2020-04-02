using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.OData;
using ODataWebApiAspNetCore.Models;

namespace ODataWebApiAspNetCore.QueryValidators
{
    public class EmployeeSelectValidator : SelectExpandQueryValidator
    {
        public EmployeeSelectValidator(DefaultQuerySettings defaultQuerySettings)
        : base(defaultQuerySettings)
        {

        }
        public override void Validate(SelectExpandQueryOption selectExpandQueryOption,
            ODataValidationSettings validationSettings)
        {
            if (selectExpandQueryOption.RawExpand != null && selectExpandQueryOption.RawExpand.Contains(nameof(Employee.Company)))
            {
                throw new ODataException(
                    $"Query on {nameof(Employee.Company)} not allowed");
            }

            base.Validate(selectExpandQueryOption, validationSettings);
        }
    }
}
