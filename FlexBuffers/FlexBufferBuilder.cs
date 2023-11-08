using System;

namespace FlexBuffers
{
    public class FlexBufferBuilder
    {
        public static byte[] Map(Action<IFlexBufferMapBuilder> map)
        {
            var buffer = new FlexBuffer();
            var start = buffer.StartVector();
            var builder = new FlexBufferMapBuilder(buffer);
            map(builder);
            buffer.SortAndEndMap(start);
            return buffer.Finish();
        }

        public static byte[] Vector(Action<IFlexBufferVectorBuilder> vector)
        {
            var buffer = new FlexBuffer();
            var start = buffer.StartVector();
            var builder = new FlexBufferVectorBuilder(buffer);
            vector(builder);
            buffer.EndVector(start, false, false);
            return buffer.Finish();
        }
    }

    public interface IFlexBufferMapBuilder
    {
        void AddNull(string key);
        void Add(string key, long value, bool indirect = false);
        void Add(string key, long x, long y);
        void Add(string key, long x, long y, long z);
        void Add(string key, long x, long y, long z, long w);
        void Add(string key, ulong value, bool indirect = false);
        void Add(string key, ulong x, ulong y);
        void Add(string key, ulong x, ulong y, ulong z);
        void Add(string key, ulong x, ulong y, ulong z, ulong w);
        void Add(string key, double value, bool indirect = false);
        void Add(string key, double x, double y);
        void Add(string key, double x, double y, double z);
        void Add(string key, double x, double y, double z, double w);
        void Add(string key, bool value);
        void Add(string key, string value);
        void Add(string key, byte[] value);
        void Add(string key, double[] value, bool indirect = false);
        void Add(string key, float[] value, bool indirect = false);
        void Map(string key, Action<IFlexBufferMapBuilder> map);
        void Vector(string key, Action<IFlexBufferVectorBuilder> vector);
    }
    

    public interface IFlexBufferVectorBuilder
    {
        void AddNull();
        void Add(long value, bool indirect = false);
        void Add(int[] value, bool indirect = false);
        void Add(long x, long y);
        void Add(long x, long y, long z);
        void Add(long x, long y, long z, long w);
        void Add(ulong value, bool indirect = false);
        void Add(ulong x, ulong y);
        void Add(ulong x, ulong y, ulong z);
        void Add(ulong x, ulong y, ulong z, ulong w);
        void Add(double value, bool indirect = false);
        void Add(float value, bool indirect = false);
        void Add(double x, double y);
        void Add(double x, double y, double z);
        void Add(double x, double y, double z, double w);
        void Add(bool value);
        void Add(string value);
        void Add(byte[] value);
        void Add(float[] value, bool indirect = false);
        void Add(double[] value, bool indirect = false);
        void Map(Action<IFlexBufferMapBuilder> map);
        void Vector(Action<IFlexBufferVectorBuilder> vector);
    }

    internal struct FlexBufferMapBuilder : IFlexBufferMapBuilder
    {
        private readonly FlexBuffer _buffer;

        internal FlexBufferMapBuilder(FlexBuffer buffer)
        {
            _buffer = buffer;
        }

        public void AddNull(string key)
        {
            _buffer.AddKey(key);
            _buffer.AddNull();
        }

        public void Add(string key, long value, bool indirect = false)
        {
            _buffer.AddKey(key);
            if (indirect)
            {
                _buffer.AddIndirect(value);
            }
            else
            {
                _buffer.Add(value);
            }
        }

        public void Add(string key, long x, long y)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, long x, long y, long z)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, long x, long y, long z, long w)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.Add(w);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, ulong value, bool indirect = false)
        {
            _buffer.AddKey(key);
            if (indirect)
            {
                _buffer.AddIndirect(value);
            }
            else
            {
                _buffer.Add(value);
            }
        }

        public void Add(string key, ulong x, ulong y)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, ulong x, ulong y, ulong z)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, ulong x, ulong y, ulong z, ulong w)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.Add(w);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, double value, bool indirect = false)
        {
            _buffer.AddKey(key);
            if (indirect)
            {
                _buffer.AddIndirect(value);
            }
            else
            {
                _buffer.Add(value);
            }
        }

        public void Add(string key, double x, double y)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, double x, double y, double z)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, double x, double y, double z, double w)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.Add(w);
            _buffer.EndVector(start, true, true);
        }

        public void Add(string key, bool value)
        {
            _buffer.AddKey(key);
            _buffer.Add(value);
        }

        public void Add(string key, string value)
        {
            _buffer.AddKey(key);
            _buffer.Add(value);
        }

        public void Add(string key, byte[] value)
        {
            _buffer.AddKey(key);
            _buffer.Add(value);
        }

        public void Add(string key, double[] value, bool indirect = false)
        {
            foreach (double v in value)
            {
                Add(key, v, indirect);
            }
        }

        public void Add(string key, float[] value, bool indirect = false)
        {
            _buffer.AddKey(key);
            _buffer.Add(value);
        }

        public void Map(string key, Action<IFlexBufferMapBuilder> map)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            var builder = new FlexBufferMapBuilder(_buffer);
            map(builder);
            _buffer.SortAndEndMap(start);
        }

        public void Vector(string key, Action<IFlexBufferVectorBuilder> vector)
        {
            _buffer.AddKey(key);
            var start = _buffer.StartVector();
            var builder = new FlexBufferVectorBuilder(_buffer);
            vector(builder);
            _buffer.EndVector(start, false, false);
        }
    }

    internal struct FlexBufferVectorBuilder : IFlexBufferVectorBuilder
    {
        private readonly FlexBuffer _buffer;

        internal FlexBufferVectorBuilder(FlexBuffer buffer)
        {
            _buffer = buffer;
        }

        public void AddNull()
        {
            _buffer.AddNull();
        }
        public void Add(long value, bool indirect = false)
        {
            if (indirect)
            {
                _buffer.AddIndirect(value);
            }
            else
            {
                _buffer.Add(value);
            }
        }

        public void Add(int[] value, bool indirect = false)
        {
            foreach (int l in value)
            {
                Add(l, indirect);
            }
        }

        public void Add(long x, long y)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.EndVector(start, true, true);
        }

        public void Add(long x, long y, long z)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.EndVector(start, true, true);
        }

        public void Add(long x, long y, long z, long w)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.Add(w);
            _buffer.EndVector(start, true, true);
        }

        public void Add(ulong value, bool indirect = false)
        {
            if (indirect)
            {
                _buffer.AddIndirect(value);
            }
            else
            {
                _buffer.Add(value);
            }
        }

        public void Add(ulong x, ulong y)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.EndVector(start, true, true);
        }

        public void Add(ulong x, ulong y, ulong z)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.EndVector(start, true, true);
        }

        public void Add(ulong x, ulong y, ulong z, ulong w)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.Add(w);
            _buffer.EndVector(start, true, true);
        }

        public void Add(double value, bool indirect = false)
        {
            if (indirect)
            {
                _buffer.AddIndirect(value);
            }
            else
            {
                _buffer.Add(value);
            }
        }

        public void Add(float value, bool indirect = false)
        {
            if (indirect)
            {
                _buffer.AddIndirect(value);
            }
            else
            {
                _buffer.Add(value);
            }
        }

        public void Add(float[] value, bool indirect = false)
        {
            foreach (var f in value)
            {
                Add(f, indirect);
            }
        }

        public void Add(double[] value, bool indirect = false)
        {
            foreach (var v in value)
            {
                Add(v, indirect);
            }
        }

        public void Add(double x, double y)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.EndVector(start, true, true);
        }

        public void Add(double x, double y, double z)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.EndVector(start, true, true);
        }

        public void Add(double x, double y, double z, double w)
        {
            var start = _buffer.StartVector();
            _buffer.Add(x);
            _buffer.Add(y);
            _buffer.Add(z);
            _buffer.Add(w);
            _buffer.EndVector(start, true, true);
        }

        public void Add(bool value)
        {
            _buffer.Add(value);
        }

        public void Add(string value)
        {
            _buffer.Add(value);
        }

        public void Add(byte[] value)
        {
            _buffer.Add(value);
        }

        public void Map(Action<IFlexBufferMapBuilder> map)
        {
            var start = _buffer.StartVector();
            var builder = new FlexBufferMapBuilder(_buffer);
            map(builder);
            _buffer.SortAndEndMap(start);
        }

        public void Vector(Action<IFlexBufferVectorBuilder> vector)
        {
            var start = _buffer.StartVector();
            var builder = new FlexBufferVectorBuilder(_buffer);
            vector(builder);
            _buffer.EndVector(start, false, false);
        }
    }

public class FlexBufferInPlaceBuilder
{
    private FlexBuffer _buffer;

    public FlexBufferInPlaceBuilder(FlexBuffer buffer) => Buffer1 = buffer;

    public FlexBuffer Buffer1
    {
        get => _buffer;
        set => _buffer = value;
    }

    public int StartVector() => Buffer1.StartVector();

    public int EndVector(int start, bool typed = false, bool fix = false) => Buffer1.EndVector(start, typed, fix);

    public void EndMap(int start)
    {
        Buffer1.SortAndEndMap(start);
    }

    public void AddKey(byte[] key)
    {
        Buffer1.AddKey(key);
    }

    public void AddKey(string key)
    {
        Buffer1.AddKey(key);
    }

    public void AddNull()
    {
        Buffer1.AddNull();
    }

    public void Add(long value, bool indirect = false)
        {
            if (indirect)
            {
                Buffer1.AddIndirect(value);
            }
            else
            {
                Buffer1.Add(value);
            }
        }

        public void Add(int[] value, bool indirect = false)
        {
            foreach (int l in value)
            {
                Add(l, indirect);
            }
        }

        public void Add(long x, long y)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(long x, long y, long z)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.Add(z);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(long x, long y, long z, long w)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.Add(z);
            Buffer1.Add(w);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(ulong value, bool indirect = false)
        {
            if (indirect)
            {
                Buffer1.AddIndirect(value);
            }
            else
            {
                Buffer1.Add(value);
            }
        }

        public void Add(ulong x, ulong y)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(ulong x, ulong y, ulong z)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.Add(z);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(ulong x, ulong y, ulong z, ulong w)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.Add(z);
            Buffer1.Add(w);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(double value, bool indirect = false)
        {
            if (indirect)
            {
                Buffer1.AddIndirect(value);
            }
            else
            {
                Buffer1.Add(value);
            }
        }

        public void Add(float value, bool indirect = false)
        {
            if (indirect)
            {
                Buffer1.AddIndirect(value);
            }
            else
            {
                Buffer1.Add(value);
            }
        }

        public void Add(float[] value, bool indirect = false)
        {
            foreach (var f in value)
            {
                Add(f, indirect);
            }
        }

        public void Add(double[] value, bool indirect = false)
        {
            var start = Buffer1.StartVector();
            foreach (var v in value)
            {
                Add(v, indirect);
            }
            Buffer1.EndVector(start, false, true);
        }

        public void Add(double x, double y)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(double x, double y, double z)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.Add(z);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(double x, double y, double z, double w)
        {
            var start = Buffer1.StartVector();
            Buffer1.Add(x);
            Buffer1.Add(y);
            Buffer1.Add(z);
            Buffer1.Add(w);
            Buffer1.EndVector(start, true, true);
        }

        public void Add(bool value)
        {
            Buffer1.Add(value);
        }

        public void Add(bool[] values)
        {
            foreach (bool b in values)
            {
                Buffer1.Add(b);
            }
        }

        public void Add(string value)
        {
            Buffer1.Add(value);
        }

        public void Add(byte[] value)
        {
            Buffer1.Add(value);
        }

        public void AddStringAsBytes(byte[] bytes)
        {
            Buffer1.AddStringAsBytes(bytes);
        }

        public void AddDoubleArrayAsPtr(IntPtr ptr, ulong length)
        {
            Buffer1.AddDoubleArrayAsPtr(ptr, length);
        }
}

}
