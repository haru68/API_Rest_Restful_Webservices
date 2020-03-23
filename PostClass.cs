using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Restful_WebServices
{
    public class PostClass
    {
        // Properties are the "options" available from the API (see https://jsonplaceholder.typicode.com/posts/1)
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            return $"UserId = {userId}, \n Id = {id}, \n Title : {title}, \n Body : {body}; \n \n";
        }


        public ICollection<PostClass> GetPostClassesFromUserId(string userId)
        {
            string url = $@"https://jsonplaceholder.typicode.com/posts?userId={userId}";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            string jsonValue = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
                reader.Close();
                response.Close();
                response.Dispose();
            }

            ICollection<PostClass> postClasses = JsonConvert.DeserializeObject<ICollection<PostClass>>(jsonValue);

            return postClasses;
        }
    }
}
