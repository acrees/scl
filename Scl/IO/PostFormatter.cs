using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.IO
{
    public class PostFormatter : IPostFormatter
    {
        public PostFormatter(ICurrentTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public string Print(Post post)
        {
            return String.Format(
                "{0} - {1} ({2})",
                post.User.Name,
                post.Message,
                TimeDifference(post.Timestamp, _timeProvider.CurrentTime()));
        }

        public string TimeDifference(DateTime first, DateTime second)
        {
            var difference = second - first;
            if (difference.Days > 1)
            {
                return difference.Days + " days ago";
            }
            else if (difference.Days == 1)
            {
                return "1 day ago";
            }
            else if (difference.Hours > 1)
            {
                return difference.Hours + " hours ago";
            }
            else if (difference.Hours == 1)
            {
                return "1 hour ago";
            }
            else if (difference.Minutes > 1)
            {
                return difference.Minutes + " minutes ago";
            }
            else if (difference.Minutes == 1)
            {
                return "1 minute ago";
            }
            else if (difference.Seconds > 1)
            {
                return difference.Seconds + " seconds ago";
            }
            else if (difference.Seconds == 1)
            {
                return "1 second ago";
            }
            else
            {
                return "just now";
            }
        }

        private ICurrentTimeProvider _timeProvider;
    }
}
