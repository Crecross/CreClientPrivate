using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CreClient.Settings
{
    
		public static class Security
		{
			// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
			public static string EncodeBase64(this string value)
			{
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
			}

			// Token: 0x06000002 RID: 2 RVA: 0x00002064 File Offset: 0x00000264
			public static string DecodeBase64(this string value)
			{
				byte[] bytes = Convert.FromBase64String(value);
				return Encoding.UTF8.GetString(bytes);
			}

			// Token: 0x06000003 RID: 3 RVA: 0x00002084 File Offset: 0x00000284
			public static string SHA256(string value)
			{
				HashAlgorithm hashAlgorithm = new SHA256Managed();
				StringBuilder stringBuilder = new StringBuilder();
				foreach (byte b in hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(value)))
				{
					stringBuilder.Append(b.ToString("x2"));
				}
				return stringBuilder.ToString();
			}
		}
}
