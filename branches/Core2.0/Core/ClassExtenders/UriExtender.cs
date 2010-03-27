using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using Core.Updaters.DataRequest.Parameters;

namespace Core.ClassExtenders
{
    public static class UriExtender
    {
        public static Uri AppendRequestParameters(this Uri uri, IList<RequestParameter> requestParameters)
        {
            NameValueCollection queryString = new NameValueCollection();
            string query = uri.Query.TrimStart('?');

            if (!string.IsNullOrEmpty(query))
            {
                queryString = HttpUtility.ParseQueryString(query);
            }

            foreach (RequestParameter requestParameter in requestParameters)
            {
                queryString.Set(requestParameter.Name, requestParameter.Value);
            }

            StringBuilder resultQuery = new StringBuilder();

            foreach (string key in queryString.AllKeys)
            {
                resultQuery.AppendFormat("{0}={1}&", key, queryString[key]);
            }

            return new Uri(uri.GetLeftPart(UriPartial.Path) + "?" + resultQuery.ToString().TrimEnd('&'));
        }
    }
}
