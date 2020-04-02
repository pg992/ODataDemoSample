using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using System.Linq;

namespace ODataWebApiAspNetCore.QueryValidators
{
    public class FilterQueryValidator1 : FilterQueryValidator
    {
        static readonly string[] allowedProperties = { "LastName" };

        public override void ValidateSingleValuePropertyAccessNode(
            SingleValuePropertyAccessNode propertyAccessNode,
            ODataValidationSettings settings)
        {
            string propertyName = null;
            if (propertyAccessNode != null)
            {
                propertyName = propertyAccessNode.Property.Name;
            }

            if (propertyName != null && !allowedProperties.Contains(propertyName))
            {
                throw new ODataException(
                    string.Format("Filter on {0} not allowed", propertyName));
            }
            base.ValidateSingleValuePropertyAccessNode(propertyAccessNode, settings);
        }

        public FilterQueryValidator1(DefaultQuerySettings defaultQuerySettings)
                                                    : base(defaultQuerySettings)
        {

        }
    }
}
