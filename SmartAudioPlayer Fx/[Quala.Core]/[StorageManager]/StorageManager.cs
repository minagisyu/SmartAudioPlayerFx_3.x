﻿using System;
using System.IO;
using System.Reflection;

namespace Quala
{
	public sealed partial class StorageManager
	{
		public DataPath AppDataDirectory { get; set; }
		public DataPath AppDirectory { get; set; }
	}
}
