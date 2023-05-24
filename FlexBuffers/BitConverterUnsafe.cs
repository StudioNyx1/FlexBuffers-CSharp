using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;

public static class BitConverterUnsafe
{
    private const byte ByteTrue = (byte)1;
    private const byte ByteFalse = (byte)0;

    /// <summary>
    /// Serializes a bool into a byte and assigns it to buffer at offset specified
    /// </summary>
    /// <param name="value">value to serialize</param>
    /// <param name="buffer"> writing buffer </param>
    /// <param name="offset"> starting index </param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static int GetBytes(bool value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 1))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }

        buffer[offset] = (value ? ByteTrue : ByteFalse);
        return 1;
    }

    /// <summary>
    /// Copies a byte into buffer at offset specified by offset
    /// Just a convenience method provided for generic use.
    /// This is just doing buffer[offset] = value;
    /// with range / overflow checking
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">writing byte buffer</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">offset and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(byte value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 1))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }

        fixed (byte* b = &buffer[offset])
            *((byte*)b) = (byte)value;
        return 1;
    }

    /// <summary>
    /// Serializes a char into two bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">writing byte buffer</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(char value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 2))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }
        Contract.EndContractBlock();

        //byte[] bytes = new byte[2];
        fixed (byte* b = &buffer[offset])
            *((short*)b) = (short)value;
        return 2;
    }

    /// <summary>
    /// Serializes a int into four bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">byte array buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(int value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 4))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }
        Contract.EndContractBlock();

        //byte[] bytes = new byte[4];
        fixed (byte* b = &buffer[offset])
            *((int*)b) = value;
        return 4;
    }

    /// <summary>
    /// Serializes a long into eight bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">byte array buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(long value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 8))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }
        Contract.EndContractBlock();

        //byte[] bytes = new byte[8];
        fixed (byte* b = &buffer[offset])
            *((long*)b) = value;
        return 8;
    }

    /// <summary>
    /// Serializes a uint / UInt32 into four bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">Span<byte> buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    //public static unsafe int GetBytes(uint value, Span<byte> buffer, int offset)
    //{
    //    if (buffer == null)
    //    {
    //        throw new ArgumentNullException("value cannot be null");
    //    }
    //    if (offset < 0)
    //    {
    //        throw new ArgumentOutOfRangeException(@"offset must be >= 0");
    //    }
    //    if (buffer.Length < (offset + 4))
    //    {
    //        throw new ArgumentOutOfRangeException(@"offset is out of range");
    //    }
    //    Contract.EndContractBlock();

    //    return GetBytes((int)value);
    //    fixed (byte* b = &buffer[offset])
    //        *((int*)b) = (int)value;
    //    return 4;
    //}

    /// <summary>
    /// Serializes a ulong / UInt64 into eight bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">byte array buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(ulong value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 8))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }
        Contract.EndContractBlock();

        //return GetBytes((long)value);

        fixed (byte* b = &buffer[offset])
            *((long*)b) = (long)value;
        return 8;
    }

    /// <summary>
    /// Serializes a single / float into four bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">byte array buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(float value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 4))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }
        Contract.EndContractBlock();

        //return GetBytes(*(int*)&value);
        fixed (byte* b = &buffer[offset])
            *((int*)b) = *(int*)&value;
        return 4;
    }

    /// <summary>
    /// Serializes a double into eight bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">byte array buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(double value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + 8))
        {
            throw new ArgumentOutOfRangeException(@"offset is out of range");
        }
        Contract.EndContractBlock();

        //return GetBytes(*(long*)&value);
        fixed (byte* b = &buffer[offset])
            *((long*)b) = *(long*)&value;
        return 8;
    }

    /// <summary>
    /// UTF8 Version: Serializes a string into an array of bytes and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="value">value to be serialized</param>
    /// <param name="buffer">byte array buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetBytesUTF8String(string value, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        int len = (value == null ? 0 : Encoding.UTF8.GetByteCount(value));
        if (buffer.Length < (offset + len))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (value == null) { return 0; }

        //ToFix: Find a better way that does not create byte[] intermediaries
        Array.Copy(Encoding.UTF8.GetBytes(value), 0, buffer, offset, len);
        return len;
    }

    /// <summary>
    /// Copies a byte into buffer at offset specified by offset
    /// Just a convenience method provided for consistency when using reflection or expression trees.
    /// This is just doing Array.Copy(array, 0, buffer, offset, array.Length);
    /// with range / overflow checking
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">byte array buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static int GetBytes(byte[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        Array.Copy(array, 0, buffer, offset, array.Length);
        return array.Length;
    }

    /// <summary>
    /// Serializes a bool array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(bool[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + array.Length))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (byte* b = &buffer[offset])
        {
            for (int I = 0; I < len; I++)
            {
                *((byte*)b + I) = (array[I] ? ByteTrue : ByteFalse);
            }
        }
        return len;
    }

    /// <summary>
    /// Serializes a char array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(char[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 2)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (char* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((short*)b + I) = *((short*)pArr + I);
                }
            }
        }
        return len * 2;
    }

    /// <summary>
    /// Serializes a short / UInt16 array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(short[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 2)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (short* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((short*)b + I) = *((short*)pArr + I);
                }
            }
        }
        return len * 2;
    }

    /// <summary>
    /// Serializes an int / Int32 array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(int[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 4)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (int* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((int*)b + I) = *((int*)pArr + I);
                }
            }
        }
        return len * 4;
    }

    /// <summary>
    /// Serializes a long / Int64 array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(long[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 8)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (long* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((long*)b + I) = *((long*)pArr + I);
                }
            }
        }
        return len * 8;
    }

    /// <summary>
    /// Serializes a ushort / UInt16 array into a byte array and assigns it to buffer at offset specified by offset
    /// Note: short[] and ushort[] are compatible therefore if using the same method name reflection invoke fails as it cannot differentiate betweent the two
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytesUShortArray(ushort[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 2)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (ushort* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((short*)b + I) = *((short*)pArr + I);
                }
            }
        }
        return len * 2;
    }

    /// <summary>
    /// Serializes a uint / UInt32 array into a byte array and assigns it to buffer at offset specified by offset
    /// Note: int[] and uint[] are compatible therefore if using the same method name reflection invoke fails as it cannot differentiate betweent the two
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytesUIntArray(uint[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 4)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (uint* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((int*)b + I) = *((int*)pArr + I);
                }
            }
        }
        return len * 4;
    }

    /// <summary>
    /// Serializes a ulong / UInt64 array into a byte array and assigns it to buffer at offset specified by offset
    /// Note: long[] and ulong[] are compatible therefore if using the same method name reflection invoke fails as it cannot differentiate betweent the two
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public unsafe static int GetBytesULongArray(ulong[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 8)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (ulong* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((long*)b + I) = *((long*)pArr + I);
                }
            }
        }
        return len * 8;
    }

    /// <summary>
    /// Serializes a Single / float array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(float[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 4)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (float* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((int*)b + I) = *((int*)pArr + I);
                }
            }
        }
        return len * 4;
    }

    /// <summary>
    /// Serializes a double array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(double[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 8)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (double* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((long*)b + I) = *((long*)pArr + I);
                }
            }
        }
        return len * 8;
    }

    /// <summary>
    /// Serializes a decimal array into a byte array and assigns it to buffer at offset specified by offset
    /// </summary>
    /// <param name="array">array to be serialized</param>
    /// <param name="buffer">buffer to write to</param>
    /// <param name="offset">starting index</param>
    /// <returns>number of bytes written</returns>
    /// <exception cref="ArgumentNullException">Buffer cannot be null</exception>
    /// <exception cref="ArgumentOutOfRangeException">start index and length of data must fit in range of buffer byte array</exception>
    public static unsafe int GetBytes(decimal[] array, byte[] buffer, int offset)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException("value cannot be null");
        }
        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(@"offset must be >= 0");
        }
        if (buffer.Length < (offset + (array == null ? 0 : array.Length * 16)))
        {
            throw new ArgumentOutOfRangeException(@"offset + length is out of range");
        }
        Contract.EndContractBlock();

        if (array == null || array.Length == 0) { return 0; }

        int len = array.Length;
        fixed (decimal* pArr = &array[0])
        {
            fixed (byte* b = &buffer[offset])
            {
                for (int I = 0; I < len; I++)
                {
                    *((decimal*)b + I) = *((decimal*)pArr + I);
                }
            }
        }
        return len * 16;
    }
}
