using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;


namespace Restful_WebServices
{
    public class AlbumClass
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }

        public override string ToString()
        {
            return $"userId = {userId}, id = {id},  \n title = {title}";
        }

        public ICollection<AlbumClass> GetAlbumClassesFromUserId(string userId)
        {
            string url = $@"https://jsonplaceholder.typicode.com/albums?userId={userId}";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            string jsonValue = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
            }

            ICollection<AlbumClass> albumClasses = JsonConvert.DeserializeObject<ICollection<AlbumClass>>(jsonValue);

            return albumClasses;
        }
    }
}
