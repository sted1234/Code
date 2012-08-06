using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Net4ToNet2Adapter;


using System.ServiceModel.Syndication;
using Sandworks.Google;



namespace RSSFeedToBlog
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
            Links = new List<Link>();
            Content = new StringBuilder();
            dtStarredAfter.Value = DateTime.Now.Subtract(TimeSpan.FromHours(6));
        }

        public StringBuilder Content
        {
            get;
            set;
        }

        public List<Link> Links { get; set; }

        public string[] knownCategories { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {

            // Authenticate.
            string auth = ClientLogin.GetAuthToken("reader", tbUserName.Text, tbPassword.Text, "Sandworks.Google.App");

            

            // Query.
            using (GoogleSession session = new GoogleSession(auth))
            {

                long unixTime = session.GetUnixTimeNow();
                TimeSpan startTimeDiffenceFromNow = DateTime.UtcNow - dtStarredAfter.Value.ToUniversalTime();
                long starredItemsSinceTime = unixTime - (long)startTimeDiffenceFromNow.TotalSeconds;

                

                var feed = session.GetFeed(tbFeedUrl.Text,
                    new GoogleParameter("n", tbLinkCount.Text)
                    ,new GoogleParameter("ot", starredItemsSinceTime.ToString())
                        );

                knownCategories = tbKnownCategories.Text.Split(',');
                for (int i = 0; i < knownCategories.Length; i++)
                    knownCategories[i] = knownCategories[i].Trim();

                foreach (var item in feed.Items)
                {
                    string matchedCategory = string.Empty;
                    foreach (SyndicationCategory category in item.Categories)
                    {
                        matchedCategory = knownCategories.FirstOrDefault(cat => cat.Equals(category.Label, StringComparison.InvariantCultureIgnoreCase));
                        if (!string.IsNullOrEmpty(matchedCategory))
                            break;
                    }
                    bool isCategorized = !string.IsNullOrEmpty(matchedCategory);
                    Links.Add(new Link { Title = item.Title.Text, AuthorName = item.Authors[0].Name, HyperLink = item.Links[0].Uri.ToString(), Category = matchedCategory?? string.Empty, IsCategorized = isCategorized });
                }
            }
            BuildContent();
            DialogResult = DialogResult.OK;
            Dispose();
        }

        private void BuildContent()
        {

            if(Links.Count == 0)
                return;

            foreach(string linkCategory in knownCategories)
            {
                if(Links.Any(link => link.Category.Trim().Equals(linkCategory, StringComparison.InvariantCultureIgnoreCase)))
                {
                    // Build Header
                    Content.Append("<h4>");
                    Content.Append(linkCategory);
                    Content.Append("</h4>");

                    // Build List
                    Content.Append("<ul>");
                    foreach(Link link in Links.Where(link => link.Category.Equals(linkCategory, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        string lineItem = string.Format(@"<li><a href=""{0}"">{1}</a> [{2}]</li>", link.HyperLink, link.Title, link.AuthorName);
                        Content.Append(lineItem);
                    }
                    Content.Append("</ul>");

                }
            }

            Content.Append("<h4>Other Links</h4>");
            Content.Append("<ul>");
            foreach (Link link in Links.Where(li => li.IsCategorized == false))
            {
                string lineItem = string.Format(@"<li><a href=""{0}"">{1}</a> [{2}]</li>", link.HyperLink, link.Title, link.AuthorName);
                Content.Append(lineItem);
            }
            Content.Append("</ul>");

        }
    }
}


