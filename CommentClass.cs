using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Restful_WebServices
{
    public class CommentClass
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            return $"postId = {postId}, \n id = {id}, \n name = {name}, \n email = {email}, \n body = {body} \n ";
        }

        public ICollection<CommentClass> GetCommentClassesFromPost(PostClass post)
        {
            string getCommentUrl = $@"https://jsonplaceholder.typicode.com/comments?postId={post.id}";

            HttpWebRequest requestComments = WebRequest.Create(getCommentUrl) as HttpWebRequest;

            string jsonComment = "";
            using (HttpWebResponse responseComment = requestComments.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(responseComment.GetResponseStream());
                jsonComment = reader.ReadToEnd();
            }
            ICollection<CommentClass> commentClasses = JsonConvert.DeserializeObject<ICollection<CommentClass>>(jsonComment);

            return commentClasses;
        }
    }
}
