using System;

namespace Sandworks.Google.Reader
{
    public static class ReaderCommandFormatter
    {
        /// <summary>
        /// Get the full url for a command.
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static string GetFullUrl(this ReaderCommand comm)
        {
            switch (comm)
            {
                case ReaderCommand.SubscriptionAdd:
                    return GetFullApiUrl("subscription/quickadd");
                case ReaderCommand.SubscriptionEdit:
                    return GetFullApiUrl("subscription/edit");
                case ReaderCommand.SubscriptionList:
                    return GetFullApiUrl("subscription/list");
                case ReaderCommand.TagAdd:
                    return GetFullApiUrl("edit-tag");
                case ReaderCommand.TagEdit:
                    return GetFullApiUrl("edit-tag");
                case ReaderCommand.TagList:
                    return GetFullApiUrl("tag/list");
                case ReaderCommand.TagRename:
                    return GetFullApiUrl("rename-tag");
                case ReaderCommand.TagDelete:
                    return GetFullApiUrl("disable-tag");
                case ReaderCommand.GetSearchItemIds:
                    return GetFullApiUrl("search/items/ids");
                case ReaderCommand.GetSearchItems:
                    return GetFullApiUrl("stream/items/contents");
                default:
                    return "";
            }
        }


        /// <summary>
        /// Get the full api url.
        /// </summary>
        /// <param name="append"></param>
        /// <returns></returns>
        private static string GetFullApiUrl(string append)
        {
            return String.Format("{0}{1}", ReaderUrl.ApiUrl, append);
        }
    }
}
