namespace WinAPIs
{
	using System;
	using System.Runtime.InteropServices;
	using System.Security;
	using System.Text;
	using System.IO;

	partial class WinAPI
	{
		const string Shlwapi = "shlwapi.dll";

		[DllImport(Shlwapi)]
		public static extern int StrCmpLogicalW(string psz1, string psz2);
	}
}
