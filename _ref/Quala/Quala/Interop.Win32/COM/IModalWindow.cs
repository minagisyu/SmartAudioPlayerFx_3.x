﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Quala.Interop.Win32.COM
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802")]
	[SuppressUnmanagedCodeSecurity]
	public interface IModalWindow
	{
		void Show(IntPtr hwndParent);
	}
}
