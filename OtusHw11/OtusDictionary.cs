namespace OtusHw11
{
    public class OtusDictionary
    {
        private const int InitialSize = 32;
        private (int key, string value)[] _items = new (int, string)[InitialSize];
        private int _count;

        public void Add(int key, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int index = key % _items.Length;
            while (_items[index].value != null)
            {
                if (_items[index].key == key)
                {
                    throw new ArgumentException("Элемент с таким же ключом уже существует.");
                }
                index = (index + 1) % _items.Length;
            }
            _items[index] = (key, value);
            _count++;

            if (_count == _items.Length)
            {
                Resize();
            }
        }

        private void Resize()
        {
            var oldItems = _items;
            _items = new (int, string)[_items.Length * 2];
            _count = 0;
            foreach (var item in oldItems)
            {
                if (item.value != null)
                {
                    Add(item.key, item.value);
                }
            }
        }

        public string Get(int key)
        {
            int index = key % _items.Length;
            while (_items[index].value != null)
            {
                if (_items[index].key == key)
                {
                    return _items[index].value;
                }
                index = (index + 1) % _items.Length;
            }
            return null;
        }

        public string this[int key]
        {
            get => Get(key);
            set => Add(key, value);
        }
    }
}
