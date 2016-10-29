﻿using Quala.Win32.Dialog;
using SmartAudioPlayerFx.MediaDB;
using SmartAudioPlayerFx.MediaPlayer;
using SmartAudioPlayerFx.Shortcut;
using SmartAudioPlayerFx.Views;
using SmartAudioPlayerFx.Views.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Threading;

namespace SmartAudioPlayerFx.Notification
{
	sealed class TasktrayIconView
	{
		NotifyIcon tray;
		ContextMenuManager _context_menu;

		public TasktrayIconView(NotificationManager notification, ContextMenuManager context_menu)
		{
			_context_menu = context_menu;

			if (App.Current != null && App.Current.Dispatcher != Dispatcher.CurrentDispatcher)
				throw new InvalidOperationException("call on UIThread!!");

			// Tasktray作成
			tray = new NotifyIcon();
			tray.Text = "SmartAudioPlayer Fx";
			tray.Icon = new Icon(App.GetResourceStream(new Uri("/Resources/SAPFx.ico", UriKind.Relative)).Stream);
			tray.BalloonTipClicked += (_, __) => BaloonTipClicked?.Invoke();
			tray.Visible = true;

			// NotificationService購読
			BaloonTipClicked += () => notification.RaiseNotifyClicked();
			notification.NotifyMessage.Where(o => string.IsNullOrWhiteSpace(o) == false)
				.Subscribe(o => tray.ShowBalloonTip((int)TimeSpan.FromSeconds(10).TotalMilliseconds, "SmartAudioPlayer Fx", o, ToolTipIcon.Info));
		}

		public event Action BaloonTipClicked;

		public void SetMenuItems()
		{
			if (tray == null) return;
			if (tray.ContextMenu != null) return;
			tray.ContextMenu = new ContextMenu();
			tray.ContextMenu.Popup += (s, _) =>
			{
				// メニュー内容を動的に変更
				var menu = s as ContextMenu;
				if (menu == null) return;
				menu.MenuItems.Clear();
				menu.MenuItems.AddRange(_context_menu.CreateWinFormsMenuItems());
			};
		}

	}
}
