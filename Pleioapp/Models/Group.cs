﻿using System;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Pleioapp
{
	public class Group : IEquatable<Group>, INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;
		private int _activitiesUnreadCount;

		[JsonProperty]
		public string guid { get; set; }

		[JsonProperty(PropertyName="time_created")]
		public DateTime timeCreated { get; set; }

		[JsonProperty]
		public string name { get; set; }

		[JsonProperty]
		public string description { get; set; }

		[JsonProperty]
		public string membership { get; set; }

		public bool Equals(Group other) {
			return string.Equals (guid, other.guid);
		}
			
		public bool hasActivitiesUnread { 
			get {
				return _activitiesUnreadCount != 0;
			}
		}

		[JsonProperty(PropertyName="activities_unread_count")]
		public int activitiesUnreadCount { 
			get { return _activitiesUnreadCount; }
			set { 
				_activitiesUnreadCount = value;
				OnPropertyChanged ("activitiesUnreadCount");
				OnPropertyChanged ("hasActivitiesUnread");
			}
		}

		public void MarkAsRead() {
			_activitiesUnreadCount = 0;
			OnPropertyChanged ("activitiesUnreadCount");
			OnPropertyChanged ("hasActivitiesUnread");
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

