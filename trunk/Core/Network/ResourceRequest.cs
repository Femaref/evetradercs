using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Core.Network
{
    public abstract class ResourceRequest
    {
        protected abstract ResourceRequestMethod Method { get; }
        protected abstract IList<ResourceRequestParameter> Parameters { get; }
        protected abstract Uri Uri { get; }

        protected ResourceRequest()
        {
        }

        protected Stream GetResponseStream()
        {
            HttpWebRequest httpWebRequest;
            
            switch (this.Method)
            {
                case ResourceRequestMethod.Get:
                    httpWebRequest = (HttpWebRequest) WebRequest.Create(this.AppendParametersToUri(this.Uri));
                    httpWebRequest.Method = "GET";
                    break;

                case ResourceRequestMethod.Post:
                    httpWebRequest = (HttpWebRequest) WebRequest.Create(this.Uri);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.KeepAlive = false;
                    httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                    httpWebRequest.Proxy = WebRequest.DefaultWebProxy;

                    this.AppendParametersToPostData(httpWebRequest);
                    break;

                default:
                    throw new Exception("undefined request method");
            }

            

            HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();

            return httpWebResponse.GetResponseStream();
        }

        private Uri AppendParametersToUri(Uri baseUri)
        {
            return new Uri(baseUri.GetLeftPart(UriPartial.Path) + "?" + this.JoinParameters());
        }
        private void AppendParametersToPostData(HttpWebRequest httpWebRequest)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] joinedParameters = encoding.GetBytes(this.JoinParameters());
            httpWebRequest.ContentLength = joinedParameters.Length;

            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(joinedParameters, 0, joinedParameters.Length);
            requestStream.Close();
        }
        private string JoinParameters()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (ResourceRequestParameter parameter in this.Parameters)
            {
                stringBuilder.Append(parameter.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
