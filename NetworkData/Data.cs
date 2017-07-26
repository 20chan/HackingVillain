using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkData
{
    public class Data
    {
        private byte[] _bytes;
        public bool IsSplited { get; private set; }
        public int MaxIndex { get; private set; }
        public int CurrentIndex { get; private set; }
        public int CurrentSize { get; private set; }
        public int DataType { get; private set; }

        public static int DefaultMaxSize = 2048;
        public static int DataSize => DefaultMaxSize - 17;

        protected Data(byte[] bytes, int type, bool splited = false, int max = -1, int cur = -1)
        {
            IsSplited = splited;
            DataType = type;
            MaxIndex = max;
            CurrentIndex = cur;
            CurrentSize = bytes.Length;

            _bytes = new byte[DataSize];
            Buffer.BlockCopy(bytes, 0, _bytes, 0, bytes.Length);
        }

        public byte[] Serialize()
        {
            var sp = BitConverter.GetBytes(IsSplited);
            var mi = BitConverter.GetBytes(MaxIndex);
            var ci = BitConverter.GetBytes(CurrentIndex);
            var cs = BitConverter.GetBytes(CurrentSize);
            var dt = BitConverter.GetBytes(DataType);
            var result = new byte[sp.Length + mi.Length + ci.Length + cs.Length + dt.Length + _bytes.Length];
            Buffer.BlockCopy(sp, 0, result, 0, sp.Length);
            Buffer.BlockCopy(mi, 0, result, sp.Length, mi.Length);
            Buffer.BlockCopy(ci, 0, result, sp.Length + mi.Length, ci.Length);
            Buffer.BlockCopy(cs, 0, result, sp.Length + mi.Length + ci.Length, cs.Length);
            Buffer.BlockCopy(dt, 0, result, sp.Length + mi.Length + ci.Length + cs.Length, dt.Length);
            Buffer.BlockCopy(_bytes, 0, result, sp.Length + mi.Length + ci.Length + cs.Length + dt.Length, _bytes.Length);
            return result;
        }

        public static Data Deserialize(byte[] bytes)
        {
            bool splited = BitConverter.ToBoolean(bytes, 0);
            var maxIndex = BitConverter.ToInt32(bytes, 1);
            var currentIndex = BitConverter.ToInt32(bytes, 5);
            var currentSize = BitConverter.ToInt32(bytes, 9);
            var dataType = BitConverter.ToInt32(bytes, 13);

            var result = new byte[bytes.Length - 17];
            Buffer.BlockCopy(bytes, 17, result, 0, result.Length);
            return new Data(result, dataType, splited, maxIndex, currentIndex);
        }

        public static List<Data> SplitToDatas(byte[] bytes, int dataType)
        {
            if (bytes.Length > DataSize)
            {
                var result = new List<Data>();
                int currentSize = 0;
                for (int i = 0; i * DataSize < bytes.Length; i++)
                {
                    byte[] cur = new byte[currentSize + DataSize > bytes.Length ?
                        bytes.Length - currentSize
                        :DataSize];

                    Buffer.BlockCopy(bytes, currentSize, cur, 0, cur.Length);
                    Data d = new Data(cur, dataType, true, bytes.Length / DataSize, i);
                    currentSize += cur.Length;
                    result.Add(d);
                }
                return result;
            }
            else
            {
                return new List<Data>() { new Data(bytes, dataType) };
            }
        }

        public static byte[] Combine(List<Data> splited)
        {
            splited.Sort((d1, d2) => d1.CurrentIndex.CompareTo(d2.CurrentIndex));

            int size = DataSize * (splited.Count - 1) + splited.Last().CurrentSize;
            byte[] result = new byte[size];
            int index = 0;
            foreach(var s in splited)
            {
                Buffer.BlockCopy(s._bytes, 0, result, index, s.CurrentSize);
                index += DataSize;
            }

            return result;
        }
    }
}
