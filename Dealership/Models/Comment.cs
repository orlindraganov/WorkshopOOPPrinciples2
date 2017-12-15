using Bytes2you.Validation;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;

        private string author;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                Guard.WhenArgument(value, "Comment content").IsNullOrEmpty().Throw();
                this.content = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                Guard.WhenArgument(value, "Comment author").IsNullOrEmpty().Throw();
                this.author = value;
            }
        }
    }
}