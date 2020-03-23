using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Restful_WebServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ressources:
            // https://www.c-sharpcorner.com/article/working-with-json-in-C-Sharp/
            // https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8
            // https://www.youtube.com/watch?v=RKw5UM0Hi0g

            Console.WriteLine("Enter userId to see it's posts and related comments");
            string userIdInput = Console.ReadLine();

            PostClass postClass = new PostClass();
            ICollection<PostClass> postClasses = postClass.GetPostClassesFromUserId(userIdInput);


            foreach (PostClass post in postClasses)
            {
                Console.WriteLine("Post:");
                Console.WriteLine();
                Console.WriteLine(post);

                CommentClass commentClass = new CommentClass();
                ICollection<CommentClass> commentClasses = commentClass.GetCommentClassesFromPost(post);

                foreach (CommentClass comment in commentClasses)
                {
                    Console.WriteLine("comment:");
                    Console.WriteLine(comment);
                }

            }

            AlbumClass albumClass = new AlbumClass();
            ICollection<AlbumClass> albumClasses = albumClass.GetAlbumClassesFromUserId(userIdInput);

            foreach(AlbumClass album in albumClasses)
            {
                Console.WriteLine("Album:");
                Console.WriteLine();
                Console.WriteLine(album);

                PhotoClass photoClass = new PhotoClass();
                ICollection<PhotoClass> photoClasses = photoClass.GetPhotoClassFromAlbum(album);
                foreach(PhotoClass photo in photoClasses)
                {
                    Console.WriteLine(photo);
                }
            }

        }
    }
}
