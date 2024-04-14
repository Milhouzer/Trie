namespace Trie
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public string Key;
        public bool End;

        public TrieNode(string key)
        {
            Children = new Dictionary<char, TrieNode>();
            Key = key;
            End = false;
        }
    }
}