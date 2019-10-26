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
		public string GetTeacherHtmlRow()
		{
			return $"<tr><td align=\"left\">{GetHtmlForName()}</td><td align=\"left\">{_day,-12}</td><td align=\"left\">{_time,-18}</td><td align=\"left\">{_room,-10}</td></tr>";
		}
		public int CompareTo(Object other)
		{
			if (other == null)
			{
				throw new NullReferenceException($"{nameof(other)} ist kein Lehrer");
			}
			Teacher otherTeacher = other as Teacher;
			return Name.ToUpper().CompareTo(otherTeacher.Name.ToUpper());
			//return otherTeacher.Name.ToLower().CompareTo(Name.ToLower()); 
		}
		//public override string ToString()
		//{
		//	return $"|{Name,-30}|{_day,-12}|{_hour,-12}|{_time,-18}|{_room,-10}|";
		//}
	}
}
