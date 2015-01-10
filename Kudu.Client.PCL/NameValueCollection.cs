using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kudu.Client.PCL
{
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
                var keyValuePairInCollection = _collection.FirstOrDefault(kvp => kvp.Key.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                return keyValuePairInCollection.ToString();
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
    }
}