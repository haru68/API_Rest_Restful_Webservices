using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Restful_WebServices
{
    public class PhotoClass
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }

        public override string ToString()
        {
            return $"albumId = {albumId}, \n id = {id}, \n title = {title}, \n url = {url}, \n thumbnailUrl = {thumbnailUrl}";
        }

        public ICollection<PhotoClass> GetPhotoClassFromAlbum(AlbumClass album)
        {
            string getCommentUrl = $@"https://jsonplaceholder.typicode.com/photos?albumId={album.id}";

            HttpWebRequest requestComments = WebRequest.Create(getCommentUrl) as HttpWebRequest;

            string jsonComment = "";
            using (HttpWebResponse responseComment = requestComments.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(responseComment.GetResponseStream());
                jsonComment = reader.ReadToEnd();
            }
            ICollection<PhotoClass> photoClasses = JsonConvert.DeserializeObject<ICollection<PhotoClass>>(jsonComment);

            return photoClasses;
        }
    }
}
