using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Endorblast
{
	public struct ByteBuffer : IDisposable
	{
		public ByteBuffer(int initialSize = 4)
		{
			this.Data = new byte[initialSize];
			this.Head = 0;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000024E7 File Offset: 0x000006E7
		public ByteBuffer(byte[] bytes)
		{
			this.Data = bytes;
			this.Head = 0;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000024F8 File Offset: 0x000006F8
		public void Dispose()
		{
			this.Data = null;
			this.Head = 0;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000250C File Offset: 0x0000070C
		public byte[] ToArray()
		{
			byte[] array = new byte[this.Head];
			Buffer.BlockCopy(this.Data, 0, array, 0, this.Head);
			return array;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002540 File Offset: 0x00000740
		public byte[] ToPacket()
		{
			byte[] array = new byte[4 + this.Head];
			Buffer.BlockCopy(BitConverter.GetBytes(this.Head), 0, array, 0, 4);
			Buffer.BlockCopy(this.Data, 0, array, 4, this.Head);
			return array;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000258C File Offset: 0x0000078C
		private void CheckSize(int length)
		{
			int num = this.Data.Length;
			bool flag = length + this.Head < num;
			if (!flag)
			{
				bool flag2 = num < 4;
				if (flag2)
				{
					num = 4;
				}
				int num2 = num * 2;
				while (length + this.Head >= num2)
				{
					num2 *= 2;
				}
				byte[] array = new byte[num2];
				Buffer.BlockCopy(this.Data, 0, array, 0, this.Head);
				this.Data = array;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002604 File Offset: 0x00000804
		public byte[] ReadBlock(int size)
		{
			bool flag = size <= 0 || this.Head + size > this.Data.Length;
			byte[] result;
			if (flag)
			{
				result = new byte[0];
			}
			else
			{
				byte[] array = new byte[size];
				Buffer.BlockCopy(this.Data, this.Head, array, 0, size);
				this.Head += size;
				result = array;
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002668 File Offset: 0x00000868
		public object ReadObject()
		{
			bool flag = this.Head + 4 > this.Data.Length;
			object result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int num = BitConverter.ToInt32(this.Data, this.Head);
				this.Head += 4;
				bool flag2 = num <= 0 || this.Head + num > this.Data.Length;
				if (flag2)
				{
					result = null;
				}
				else
				{
					MemoryStream memoryStream = new MemoryStream();
					memoryStream.SetLength((long)num);
					memoryStream.Read(this.Data, this.Head, num);
					this.Head += num;
					object obj = new BinaryFormatter().Deserialize(memoryStream);
					memoryStream.Dispose();
					result = obj;
				}
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002724 File Offset: 0x00000924
		public byte[] ReadBytes()
		{
			bool flag = this.Head + 4 > this.Data.Length;
			byte[] result;
			if (flag)
			{
				result = new byte[0];
			}
			else
			{
				int num = BitConverter.ToInt32(this.Data, this.Head);
				this.Head += 4;
				bool flag2 = num <= 0 || this.Head + num > this.Data.Length;
				if (flag2)
				{
					result = new byte[0];
				}
				else
				{
					byte[] array = new byte[num];
					Buffer.BlockCopy(this.Data, this.Head, array, 0, num);
					this.Head += num;
					result = array;
				}
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000027C8 File Offset: 0x000009C8
		public string ReadString()
		{
			bool flag = this.Head + 4 > this.Data.Length;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				int num = BitConverter.ToInt32(this.Data, this.Head);
				this.Head += 4;
				bool flag2 = num <= 0 || this.Head + num > this.Data.Length;
				if (flag2)
				{
					result = "";
				}
				else
				{
					string @string = Encoding.UTF8.GetString(this.Data, this.Head, num);
					this.Head += num;
					result = @string;
				}
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002868 File Offset: 0x00000A68
		public char ReadChar()
		{
			bool flag = this.Head + 2 > this.Data.Length;
			char result;
			if (flag)
			{
				result = '\0';
			}
			else
			{
				int num = (int)BitConverter.ToChar(this.Data, this.Head);
				this.Head += 2;
				result = (char)num;
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000028B8 File Offset: 0x00000AB8
		public byte ReadByte()
		{
			bool flag = this.Head + 1 > this.Data.Length;
			byte result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = (int)this.Data[this.Head];
				this.Head++;
				result = (byte)num;
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002904 File Offset: 0x00000B04
		public bool ReadBoolean()
		{
			bool flag = this.Head + 1 > this.Data.Length;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = BitConverter.ToBoolean(this.Data, this.Head) ? 1 : 0;
				this.Head++;
				result = (num != 0);
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000295C File Offset: 0x00000B5C
		public short ReadInt16()
		{
			bool flag = this.Head + 2 > this.Data.Length;
			short result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = (int)BitConverter.ToInt16(this.Data, this.Head);
				this.Head += 2;
				result = (short)num;
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000029AC File Offset: 0x00000BAC
		public ushort ReadUInt16()
		{
			bool flag = this.Head + 2 > this.Data.Length;
			ushort result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = (int)BitConverter.ToUInt16(this.Data, this.Head);
				this.Head += 2;
				result = (ushort)num;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000029FC File Offset: 0x00000BFC
		public int ReadInt32()
		{
			bool flag = this.Head + 4 > this.Data.Length;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = BitConverter.ToInt32(this.Data, this.Head);
				this.Head += 4;
				result = num;
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002A4C File Offset: 0x00000C4C
		public uint ReadUInt32()
		{
			bool flag = this.Head + 4 > this.Data.Length;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				int num = (int)BitConverter.ToUInt32(this.Data, this.Head);
				this.Head += 4;
				result = (uint)num;
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002A9C File Offset: 0x00000C9C
		public float ReadSingle()
		{
			bool flag = this.Head + 4 > this.Data.Length;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				double num = (double)BitConverter.ToSingle(this.Data, this.Head);
				this.Head += 4;
				result = (float)num;
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public long ReadInt64()
		{
			bool flag = this.Head + 8 > this.Data.Length;
			long result;
			if (flag)
			{
				result = 0L;
			}
			else
			{
				long num = BitConverter.ToInt64(this.Data, this.Head);
				this.Head += 8;
				result = num;
			}
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002B40 File Offset: 0x00000D40
		public ulong ReadUInt64()
		{
			bool flag = this.Head + 8 > this.Data.Length;
			ulong result;
			if (flag)
			{
				result = 0UL;
			}
			else
			{
				long num = (long)BitConverter.ToUInt64(this.Data, this.Head);
				this.Head += 8;
				result = (ulong)num;
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002B90 File Offset: 0x00000D90
		public double ReadDouble()
		{
			bool flag = this.Head + 8 > this.Data.Length;
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				double num = BitConverter.ToDouble(this.Data, this.Head);
				this.Head += 8;
				result = num;
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002BE5 File Offset: 0x00000DE5
		public void WriteBlock(byte[] bytes)
		{
			this.CheckSize(bytes.Length);
			Buffer.BlockCopy(bytes, 0, this.Data, this.Head, bytes.Length);
			this.Head += bytes.Length;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002C19 File Offset: 0x00000E19
		public void WriteBlock(byte[] bytes, int offset, int size)
		{
			this.CheckSize(size);
			Buffer.BlockCopy(bytes, offset, this.Data, this.Head, size);
			this.Head += size;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002C48 File Offset: 0x00000E48
		public void WriteObject(object value)
		{
			MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, value);
			byte[] array = memoryStream.ToArray();
			int value2 = array.Length;
			memoryStream.Dispose();
			this.WriteBlock(BitConverter.GetBytes(value2));
			this.WriteBlock(array);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002C90 File Offset: 0x00000E90
		public void WriteBytes(byte[] value, int offset, int size)
		{
			this.WriteBlock(BitConverter.GetBytes(size));
			this.WriteBlock(value, offset, size);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002CAA File Offset: 0x00000EAA
		public void WriteBytes(byte[] value)
		{
			this.WriteBlock(BitConverter.GetBytes(value.Length));
			this.WriteBlock(value);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002CC4 File Offset: 0x00000EC4
		public void WriteString(string value)
		{
			bool flag = value == null;
			if (flag)
			{
				this.WriteInt32(0);
			}
			else
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value);
				this.WriteInt32(bytes.Length);
				this.WriteBlock(bytes);
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002D06 File Offset: 0x00000F06
		public void WriteChar(char value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002D16 File Offset: 0x00000F16
		public void WriteByte(byte value)
		{
			this.CheckSize(1);
			this.Data[this.Head] = value;
			this.Head++;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002D3D File Offset: 0x00000F3D
		public void WriteBoolean(bool value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002D4D File Offset: 0x00000F4D
		public void WriteInt16(short value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002D5D File Offset: 0x00000F5D
		public void WriteUInt16(ushort value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002D6D File Offset: 0x00000F6D
		public void WriteInt32(int value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002D7D File Offset: 0x00000F7D
		public void WriteUInt32(uint value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002D8D File Offset: 0x00000F8D
		public void WriteSingle(float value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002D9D File Offset: 0x00000F9D
		public void WriteInt64(long value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002DAD File Offset: 0x00000FAD
		public void WriteUInt64(ulong value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002DBD File Offset: 0x00000FBD
		public void WriteDouble(double value)
		{
			this.WriteBlock(BitConverter.GetBytes(value));
		}

		// Token: 0x0400000B RID: 11
		public byte[] Data;

		// Token: 0x0400000C RID: 12
		public int Head;

	}
}
