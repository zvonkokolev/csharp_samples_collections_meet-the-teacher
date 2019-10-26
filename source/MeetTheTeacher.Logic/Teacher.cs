using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
	/// <summary>
	/// Verwaltet einen Eintrag in der Sprechstundentabelle
	/// Basisklasse für TeacherWithDetail
	/// </summary>
	public class Teacher : IComparable
	{
		//fields
		private readonly string _day;
		private readonly string _hour;
		private readonly string _room;
		private readonly string _time;
		//properties
		public string Name { get; set; }
		//constructors
		public Teacher(string name, string tag, string stunden,  string zeit, string raum)
		{
			Name = name;
			_day = tag;
			_hour = stunden;
			_time = zeit;
			_room = raum;
		}

		public Teacher()
		{
		}

		//methods
		public virtual string GetHtmlForName()
		{
			return Name;
		}
		public virtual string GetTeacherHtmlRow()
		{
			return $"<td align=\"left\">{Name}</td>";
		}
		public int CompareTo(Object other)
		{
			if (other == null)
			{
				throw new NullReferenceException($"{nameof(other)} ist kein Lehrer");
			}
			Teacher otherTeacher = other as Teacher;
			return this.Name.ToLower().CompareTo(otherTeacher.Name.ToLower());
		}
		public override string ToString()
		{
			return $"{Name} {_day} {_hour} {_time} {_room}";
		}
	}
}
