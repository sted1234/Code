using System;
using System.Collections.Generic;
using System.Text;
using WindowsLive.Writer.Api;

using System.Windows.Forms;
using System.Windows.Forms.Layout;


namespace RSSFeedToBlog
{
    [InsertableContentSource("RSS To Blog")]
    [WriterPlugin("f3f1e05c-323b-4a87-a2f8-993bc0c820cf", "RSS To Blog", HasEditableOptions = false)]
    public class RSSToBlogWriter : ContentSource 
    { 
        public override DialogResult CreateContent(IWin32Window dialogOwner, ref string content) 
        {
            using (Editor editor = new Editor())
            {
                DialogResult result = editor.ShowDialog();
                if (result == DialogResult.OK)
                    content = editor.Content.ToString();
                return result;

            }
            
        }
    }

    [InsertableContentSource("Post Title")]
    [WriterPlugin("E36BBF07-591E-4959-97AE-D439CBA392FB", "Post Title", HasEditableOptions = false)]
    public class PostTitle : ContentSource
    {
        public override DialogResult CreateContent(IWin32Window dialogOwner, ref string content)
        {
            content = DateTime.Now.ToString("MMMM dd, yyyy") + " Links";
            return DialogResult.OK;
        }
    }

  
}