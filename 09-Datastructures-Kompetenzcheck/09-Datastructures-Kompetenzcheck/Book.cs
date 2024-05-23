using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at.Schoefecker
{
    class Book
    {
        public Book(string title, bool isAvailable)
        {
            this.Title = title;
            this.IsAvailable = isAvailable;
        }

        public string Title { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return Title;
        }

    }
}
