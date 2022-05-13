using System.Collections.Generic;
using System.Linq;

namespace project.Client.Shared.Navigation
{
    public class PageHistoryState
    {
        public List<string> previousPages { get; set; }

        public PageHistoryState()
        {
            previousPages = new List<string>();
        }
        public void AddPage(string pageName)
        {
            previousPages.Add(pageName);
        }

        public bool CanGoBack()
        {
            return previousPages.Count > 1;
        }

        public string PreviousPage()
        {
            if (previousPages.Count > 1)
            {
                return previousPages.ElementAt(previousPages.Count - 2);
            }

            return previousPages.FirstOrDefault();
        }
    }
}
