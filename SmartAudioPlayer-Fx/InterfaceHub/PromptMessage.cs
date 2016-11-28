﻿using Quala;
using Reactive.Bindings;
using System;

namespace SmartAudioPlayer.InterfaceHub
{
	// ダイアログ表示を意図した仲介クラス
	// メッセージの表示、ユーザーレスポンスを期待をする
	// Domain層で利用され、View層はこれを参照して実装する
	[SingletonService]
	public sealed class PromptMessage
	{
		public event Action Clicked;
		public void RaiseClicked() => Clicked?.Invoke();

		public string Message { get; set; }
		public string Description { get; set; }

		public ReactiveCommand ShowDialog { get; } = new ReactiveCommand();

	}
}