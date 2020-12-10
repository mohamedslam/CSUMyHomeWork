using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BinarySearchTree
{
    [XmlRoot("dictionary")]
    public  sealed class  MyDictionary<TKey, TValue> : 
                                         IDictionary<TKey, TValue>,                                        
                                         IXmlSerializable
    {
         
        #region Members.

        public bool AllowListEdit { get; private set; }
        public bool AllowItemEdit { get; private set; }
        private Dictionary<TKey, TValue> Dictionary { get; set; }

        #endregion Members.

        #region Constructors.

        public MyDictionary(bool allowListEdit, bool allowItemEdit)
        { 
            this.AllowListEdit = allowListEdit;
            this.AllowItemEdit = allowItemEdit; 
            this.Dictionary = new Dictionary<TKey, TValue>(); 
        }
        public MyDictionary(IEqualityComparer<TKey> comparer, bool allowListEdit, bool allowItemEdit)
        { 
            this.AllowListEdit = allowListEdit; 
            this.AllowItemEdit = allowItemEdit;
            this.Dictionary = new Dictionary<TKey, TValue>(comparer);
        }
        public MyDictionary(IDictionary<TKey, TValue> dictionary, bool allowListEdit = false, bool allowItemEdit = false) : this(allowListEdit, allowItemEdit)
        { 
            foreach (var pair in dictionary) 
            { this.Dictionary.Add(pair.Key, pair.Value); } 
        }
        public MyDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer, bool allowListEdit = false, bool allowItemEdit = false) : this(comparer, allowListEdit, allowItemEdit)
        {
            foreach (var pair in dictionary) { 
                this.Dictionary.Add(pair.Key, pair.Value); 
            }
        }

        #endregion Constructors.

        #region Properties.

        public int Count { get 
            { 
                return (this.Dictionary.Count);
            } 
        }
        public IEqualityComparer<TKey> Comparer {
            get { return (this.Dictionary.Comparer);
            } 
        }

        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
                return;

            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");

                reader.ReadStartElement("key");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();

                reader.ReadStartElement("value");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();

                this.Add(key, value);

                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("item");

                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();

                writer.WriteStartElement("value");
                TValue value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }


        #endregion
        #endregion Properties.

        #region Methods.

        private void ThrowItemReadOnlyException()
        { 
            if (this.AllowListEdit) 
            { 
                throw (new NotSupportedException("This collection does not allow editing items."));
            }
        }
        private void ThrowListReadOnlyException() { 
            if (this.AllowItemEdit) {
                throw (new NotSupportedException("This collection does not allow adding and removing items.")); 
            
            } 
        }
        public bool ContainsValue(TValue value) 
        {
            return (this.Dictionary.ContainsValue(value));
        }
        public void Clear() {
            this.ThrowListReadOnlyException(); this.Dictionary.Clear();
        }
       
        #endregion Methods.

        #region Interface Implementation: IEnumerable<KeyValuePair<TKey, TValue>>.

        IEnumerator IEnumerable.GetEnumerator() {
            return (this.Dictionary.GetEnumerator()); 
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            return (this.Dictionary.GetEnumerator());
        }

        #endregion Interface Implementation: IEnumerable<KeyValuePair<TKey, TValue>>.

        #region Interface Implementation: ICollection<KeyValuePair<TKey, TValue>>.
        public bool IsReadOnly {
            get { return (this.AllowListEdit);
            } 
        }

      
        

        #endregion Interface Implementation: ICollection<KeyValuePair<TKey, TValue>>.

        #region Interface Implementation: IDictionary<TKey, TValue>.

        //====================================================================================================
        // Interface Implementation: IDictionary<TKey, TValue>.
        //====================================================================================================

        public Dictionary<TKey, TValue>.KeyCollection Keys { 
            get {
                return (this.Dictionary.Keys);
            } 
        }
        public Dictionary<TKey, TValue>.ValueCollection Values 
        {
            get {
                return (this.Dictionary.Values); 
            } 
        }

        ICollection<TKey> IDictionary<TKey, TValue>
            .Keys => throw new NotImplementedException();
        ICollection<TValue> IDictionary<TKey, TValue>
            .Values => throw new NotImplementedException();

        public TValue this[TKey key] { 
            get { 
                return (this.Dictionary[key]);
            }
            set {
                this.ThrowItemReadOnlyException();
                this.Dictionary[key] = value;
            }
        }
        public void Add(TKey key, TValue value) {
            this.ThrowListReadOnlyException(); 
            this.Dictionary.Add(key, value);
        }
        public bool ContainsKey(TKey key) {
            return (this.Dictionary.ContainsKey(key));
        }
        public bool Remove(TKey key) { 
            this.ThrowListReadOnlyException();
            return (this.Dictionary.Remove(key)); }
        public bool TryGetValue(TKey key, out TValue value) {
            return (this.Dictionary.TryGetValue(key, out value)); 
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }


        #endregion Interface Implementation: IDictionary<TKey, TValue>.



    }
}
