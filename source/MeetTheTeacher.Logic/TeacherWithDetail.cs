using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Klasse, die einen Detaileintrag mit Link auf dem Namen realisiert.
    /// </summary>
    public class TeacherWithDetail : Teacher
    {
		//fields
		private int _id;
		//constructor
		public TeacherWithDetail
			(string name, string tag, string stunden, string zeit, string raum, int id)
			: base(name, tag, stunden, zeit, raum)
		{
			_id = id;
		}
		public override string GetHtmlForName()
		{
			return $"<a href=\"?id={_id}\">{Name}</a>";
		}
		public override string GetTeacherHtmlRow()
		{
			return $"<td align=\"left\"><a href=\"?id={_id}\">{Name}</a></td>";
		}
	}
}
