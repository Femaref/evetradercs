using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;

namespace GoogleCode
{
    /// <summary>
    /// Uploads a file to the download section of a google code project
    /// </summary>
    public class FileUploader
    {
        /// <summary>
        /// Initializes a new instance of the FileUploader class
        /// </summary>
        /// <param name="projectName">Google code project name</param>
        /// <param name="userName">User name to use for the upload</param>
        /// <param name="password">Google code password (NOT global google account password)</param>
        public FileUploader(string projectName, string userName, string password)
        {
            ProjectName = projectName;

            if (userName.Contains("@gmail.com"))
                userName = userName.Substring(0, userName.IndexOf("@gmail.com"));
            UserName = userName;
            iPassword = password;

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                delegate(
                object sender,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        }

        /// <summary>
        /// Google Code password
        /// </summary>
        private string iPassword = "";

        /// <summary>
        /// Boundary string for the multi-part upload
        /// </summary>
        private const string Boundary = "Googlecode_boundary_reindeer_flotilla";

        /// <summary>
        /// LineFeed for the multi-part upload
        /// </summary>
        private const string LineFeed = "\r\n";

        /// <summary>
        /// Gets the Project name
        /// </summary>
        public string ProjectName { get; private set; }

        /// <summary>
        /// Gets the UserName
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Uploads a file to the specified google code project
        /// </summary>
        /// <param name="localPath">Local path to the file getting uploaded</param>
        /// <param name="summary">Summary for the upload</param>
        /// <param name="labels">Array of custom labels for the upload</param>
        public UploadInfo Upload(string localPath, string summary, params string[] labels)
        {
            List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
            postData.Add(new Tuple<string, string>("summary", summary));

            if (labels.Length > 0)
            {
                foreach (string s in labels)
                    postData.Add(new Tuple<string, string>("label", s));
            }

            var data = this.EncodeUpload(postData, localPath);

            string host = string.Format("https://{0}.googlecode.com:443", this.ProjectName) + "/files";

            byte[] auth = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", this.UserName, this.iPassword));

            string authToken = Convert.ToBase64String(auth);


            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(host));
            req.Headers.Add("Authorization", string.Format("Basic {0}", authToken));
            req.UseDefaultCredentials = true;
            req.AllowAutoRedirect = true;
            req.UserAgent = "Googlecode.com uploader v0.9.4";
            req.ContentType = data.ContentType;
            req.Method = "POST";

            req.ContentLength = data.Data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data.Data, 0, data.Data.Length);
            }
            try
            {
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    return new UploadInfo(res.StatusCode, res.StatusDescription, res.Headers[HttpResponseHeader.Location]);
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                return new UploadInfo(res.StatusCode, res.StatusDescription, "");
            }
        }

        /// <summary>
        /// Generates the body of the request
        /// </summary>
        /// <param name="postData">Represents custom data for the upload</param>
        /// <param name="filePath">Path to the file getting uploaded</param>
        /// <returns>Returns a tuple of Content-Type and the body, already encoded as UTF-8 byte[]</returns>
        private EncodedUploadData EncodeUpload(IEnumerable<Tuple<string, string>> postData, string filePath)
        {
            var body = new List<Tuple<string, string, string, string>>(postData.Select(t =>
                Tuple.Create(
                "--" + Boundary,
                string.Format("Content-Disposition: form-data; name=\"{0}\"", t.Item1),
                "",
                t.Item2)));

            FileInfo file = new FileInfo(filePath);

            byte[] data = File.ReadAllBytes(filePath);

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] stuff = Encoding.UTF8.GetBytes(FormatFormBody(body));

                ms.Write(stuff, 0, stuff.Length);

                byte[] buffer;

                buffer = Encoding.UTF8.GetBytes(LineFeed);
                ms.Write(buffer, 0, buffer.Length);

                buffer = Encoding.UTF8.GetBytes("--" + Boundary + LineFeed);
                ms.Write(buffer, 0, buffer.Length);
                
                buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"filename\"; filename=\"{0}\"", file.Name) + LineFeed);
                ms.Write(buffer, 0, buffer.Length);

                buffer = Encoding.UTF8.GetBytes("" + LineFeed);
                ms.Write(buffer, 0, buffer.Length);

                // write data
                ms.Write(data, 0, data.Length);

                buffer = Encoding.UTF8.GetBytes(LineFeed);
                ms.Write(buffer, 0, buffer.Length);

                buffer = Encoding.UTF8.GetBytes("--" + Boundary + "--" );
                ms.Write(buffer, 0, buffer.Length);

                buffer = Encoding.UTF8.GetBytes(LineFeed);
                ms.Write(buffer, 0, buffer.Length);

                ms.Position = 0;
                byte[] output = new byte[ms.Length];
                ms.Read(output, 0, output.Length);

                return new EncodedUploadData(string.Format("multipart/form-data; boundary={0}", Boundary), output);
            }
        }

        /// <summary>
        /// Formats a given set of custom form body tuples
        /// </summary>
        /// <param name="body">Tuple of elements, consisting of Boundary, Content-Disposition name, Empty line and data</param>
        /// <returns>Formatted string according to http rfc for multi-part requests</returns>
        private static string FormatFormBody(List<Tuple<string, string, string, string>> body)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < body.Count; i++)
            {
                builder.Append(body[i].Item1);
                builder.Append(LineFeed);
                builder.Append(body[i].Item2);
                builder.Append(LineFeed);
                builder.Append(body[i].Item3);
                builder.Append(LineFeed);
                builder.Append(body[i].Item4);
                if(i != (body.Count-1))
                    builder.Append(LineFeed);
            }

            return builder.ToString();
        }
    }
}
