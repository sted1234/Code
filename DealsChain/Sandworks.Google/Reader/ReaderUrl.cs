using System;

namespace Sandworks.Google.Reader
{
    public static class ReaderUrl
    {
        /// <summary>
        /// Base url for Atom services.
        /// </summary>
        public const string AtomUrl = "https://www.google.com/reader/atom/";

        /// <summary>
        /// Base url for API actions.
        /// </summary>
        public const string ApiUrl = "https://www.google.com/reader/api/0/";

        /// <summary>
        /// Feed url to be combined with the desired feed.
        /// </summary>
        public const string FeedUrl = AtomUrl + "feed/";

        /// <summary>
        /// State path.
        /// </summary>
        public const string StatePath = "user/-/state/com.google/";

        /// <summary>
        /// State url to be combined with desired state. For example: starred
        /// </summary>
        public const string StateUrl = AtomUrl + StatePath;

        /// <summary>
        /// Label path.
        /// </summary>
        public const string LabelPath = "user/-/label/";

        /// <summary>
        /// Label url to be combined with the desired label.
        /// </summary>
        public const string LabelUrl = AtomUrl + LabelPath;
    }
}
