﻿using System;
using System.Collections.Generic;

namespace Quala
{
	using TType = System.Byte;

	partial class Extension
	{
		#region コピペで動くやつ

		/// <summary>
		/// for(var num=begin; num < to; num++){}
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static IEnumerable<TType> ToUp(this TType begin, TType to)
		{
			for(var num = begin; num < to; num++)
				yield return num;
		}

		/// <summary>
		/// for(var num=begin; num >= to; num--){}
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static IEnumerable<TType> ToDown(this TType begin, TType to)
		{
			for(var num = begin; num >= to; num--)
				yield return num;
		}

		/// <summary>
		/// (value >= min && value <= max)
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static bool IsRange(this TType value, TType min, TType max)
		{
			return (value >= min && value <= max);
		}

		/// <summary>
		/// Math.Min(Math.Max(min, value), max);
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static TType Limit(this TType value, TType min, TType max)
		{
			return value = Math.Min(Math.Max(min, value), max);
		}

		/// <summary>
		/// Math.Min(value, max);
		/// </summary>
		/// <param name="value"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static TType LimitMax(this TType value, TType max)
		{
			return value = Math.Min(value, max);
		}

		/// <summary>
		/// Math.Max(min, value);
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <returns></returns>
		public static TType LimitMin(this TType value, TType min)
		{
			return value = Math.Max(min, value);
		}

		#endregion
		#region 調整が必要なやつ

		/// <summary>
		/// 上位と下位の値から倍精度の値を生成します
		/// </summary>
		/// <param name="high">上位</param>
		/// <returns></returns>
		public static ushort MakeValue(this TType value, TType high)
		{
			return (ushort)(((high << 16) & 0xffff0000) | (ushort)value);
		}

		#endregion
	}
}
