using System;
using RestSharp.Portable;

namespace Wykop.ApiProvider.Model
{
    public class Link
    {
        internal Link(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Tags { get; private set; }
        public Uri Url { get; private set; }
        public Uri SourceUrl { get; private set; }
        public uint VoteCount { get; private set; }
        public uint CommentsCount { get; private set; }
        public uint ReportCount { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string AuthorUsername { get; private set; }

        internal static Link BuildFromRestResponse(IRestResponse restResponse)
        {
            return new Link(1);
        }
    }
}