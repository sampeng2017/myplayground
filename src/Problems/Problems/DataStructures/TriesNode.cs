using Problems.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures
{
    public class TriesNode
    {
        private bool validWordAtHere;
        public static TriesNode CreateRootNode()
        {
            return new TriesNode('^');
        }

        public static bool IsRoot(TriesNode node)
        {
            return '^' == node?.Value;
        }

        public TriesNode(char ch)
        {
            Value = Char.ToLower(ch);
            Children = new List<TriesNode>();
        }
        public char Value { get; }
        public bool ValidWordAtHere => this.validWordAtHere;
        public List<TriesNode> Children { get; }
        public TriesNode Parent { get; private set; }

        public void AddWord(IList<char> wordChars)
        {
            Helpers.Ensure(wordChars);

            if (wordChars.Count == 0)
            {
                this.validWordAtHere = true;
                return;
            }
            var child = FindNextChar(wordChars[0]);
            if (child == null)
            {
                child = new TriesNode(wordChars[0]);
                Children.Add(child);
                child.Parent = this;
            }
            child.AddWord(wordChars.Skip(1).ToList());
        }

        public TriesNode FindNextChar(char c)
        {
            return Children.FirstOrDefault((n) => n.Value == Char.ToLower(c));
        }

        public bool Match(string w)
        {
            if (string.IsNullOrEmpty(w))
                return false;

            TriesNode starts = null;
            char firstChar = w.First();
            if (IsRoot(this))
            {
                starts = FindNextChar(firstChar);
            }
            else
            {
                starts = firstChar == Value ? this : null;
            }
            int i = 1;
            while (starts != null && i < w.Length)
            {
                starts = starts.FindNextChar(w[i]);
                i++;
            }
            return starts != null && starts.ValidWordAtHere;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
