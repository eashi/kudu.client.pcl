using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kudu.Client.PCL
{
    // Inspired by Rehan Saeed from http://stackoverflow.com/questions/20268544/portable-class-library-pcl-version-of-httputility-parsequerystring
    public class NameValueCollection
    {
        private Collection<KeyValuePair<string, string>> _collection;

        public NameValueCollection()
        {
            _collection = new Collection<KeyValuePair<string, string>>();
        }

        public string this[string key]
        {
            get
            {
                var keyValuePairInCollection = _collection.Where(kvp => kvp.Key.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                return keyValuePairInCollection.Select(k => k.Value).Aggregate((first, second) => string.Format("{0}, {1}", first, second));
            }
            set
            {
                var originalKeyValuePair =
                    _collection.FirstOrDefault(kvp => kvp.Key.Equals(key, StringComparison.CurrentCultureIgnoreCase));

                if (!originalKeyValuePair.Equals(default(KeyValuePair<string, string>)))
                    _collection.Remove(originalKeyValuePair);
                _collection.Add(new KeyValuePair<string, string>(key, value));
            }
        }

        public string[] GetValues(string key)
        {
            return _collection.Where(kvp => kvp.Key.Equals(key, StringComparison.CurrentCultureIgnoreCase)).Select(kv => kv.Value).ToArray();
        }
    }
}