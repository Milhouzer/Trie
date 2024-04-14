namespace Trie
{
    public class TrieStructure
    {
        private readonly TrieNode _root;
        public TrieNode Root { get { return _root;}}

        public TrieStructure()
        {
            _root = new TrieNode("");
        }

        public void AddNode(string word)
        {
            if (string.IsNullOrEmpty(word)) return;

            TrieNode cur = _root;
            for (int i = 0; i < word.Length; ++i)
            {
                if (!cur.Children.ContainsKey(word[i]))
                {
                    cur.Children.Add(word[i], new TrieNode(word[..(i + 1)]));
                }

                cur = cur.Children[word[i]];
                if (i == word.Length - 1)
                    cur.End = true;
            }
        }

        
        public static TrieStructure BuildTrieStructure(IEnumerator<string> it)
        {
            TrieStructure trieStruct = new TrieStructure();
            while (it.MoveNext())
            {
                trieStruct.AddNode(it.Current);
            }

            return trieStruct;
        }
    }
}