using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace PSPDFCatalog {
	public class BaseViewModel : INotifyPropertyChanged {
		public Settings Settings { get => Settings.Current; }
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged ([CallerMemberName] string name = "") => PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
	}
}
