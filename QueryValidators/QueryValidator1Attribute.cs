using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;

namespace ODataWebApiAspNetCore.QueryValidators
{
    public class QueryValidator1Attribute : EnableQueryAttribute
    {
        private readonly DefaultQuerySettings defaultQuerySettings;
        public QueryValidator1Attribute()
        {
            defaultQuerySettings = new DefaultQuerySettings
            {
                EnableExpand = true,
                EnableSelect = true,
                EnableCount = true,
                EnableFilter = true
            };
        }
        public override void ValidateQuery(HttpRequest request, ODataQueryOptions queryOpts)
        {
            if (queryOpts.SelectExpand != null)
            {
                queryOpts.SelectExpand.Validator = new EmployeeSelectValidator(defaultQuerySettings);
            }
            //if(queryOpts.Filter != null)
            //{
            //    queryOpts.Filter.Validator = new FilterQueryValidator1(defaultQuerySettings);
            //}

            base.ValidateQuery(request, queryOpts);
        }
    }
}
