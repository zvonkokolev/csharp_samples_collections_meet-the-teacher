using System;

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
			return $"\t\t\t<tr>\n\t\t\t\t<td align=\"left\">{GetHtmlForName()}</td>\n\t\t\t\t<td align=\"left\">{_day}</td>\n\t\t\t\t<td align=\"left\">{_time}</td>\n\t\t\t\t<td align=\"left\">{_room}</td>\n\t\t\t</tr>\n";
		}
		public int CompareTo(Object other)
		{
			if (other == null)
			{
				throw new NullReferenceException($"{nameof(other)} ist kein Lehrer");
			}
			Teacher otherTeacher = other as Teacher;
			return Name.ToUpper().CompareTo(otherTeacher.Name.ToUpper());
			//return otherTeacher.Name.ToLower().CompareTo(Name.ToLower()); absteigend sortieren
		}
		//public override string ToString()
		//{
		//	return $"|{Name,-30}|{_day,-12}|{_hour,-12}|{_time,-18}|{_room,-10}|";
		//}
	}
}
