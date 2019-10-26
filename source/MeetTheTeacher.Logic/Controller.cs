using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeetTheTeacher.Logic
{
	/// <summary>
	/// Verwaltung der Lehrer (mit und ohne Detailinfos)
	/// </summary>
	public class Controller
	{
		private List<Teacher> _teachers;
		private Dictionary<string, int> _details;
		private int _countTeachersWithDetails;
		private int _count;

		/// <summary>
		/// Liste für Sprechstunden und Dictionary für Detailseiten anlegen
		/// </summary>
		public Controller(string[] teacherLines, string[] detailsLines)
		{
			InitDetails(detailsLines);
			InitTeachers(teacherLines);
		}
		public Controller()
		{
		}
		public int Count
		{
			get => _count;
			set => _count = value;
		}

		public int CountTeachersWithoutDetails => Count - CountTeachersWithDetails;

		/// <summary>
		/// Anzahl der Lehrer mit Detailinfos in der Liste
		/// </summary>
		public int CountTeachersWithDetails
		{
			get => _countTeachersWithDetails;
			set => _countTeachersWithDetails = value;
		}

		public Dictionary<string, int> Details { get => _details; set => _details = value; }
		public List<Teacher> Teachers { get => _teachers; set => _teachers = value; }


		/// <summary>
		/// Aus dem Text der Sprechstundendatei werden alle Lehrersprechstunden 
		/// eingelesen. Dabei wird für Lehrer, die eine Detailseite haben
		/// ein TeacherWithDetails-Objekt und für andere Lehrer ein Teacher-Objekt angelegt.
		/// </summary>
		/// <returns>Anzahl der eingelesenen Lehrer</returns>
		private void InitTeachers(string[] lines)
		{
			Teachers = new List<Teacher>();
			foreach (string line in lines)
			{
				string[] part = new string[5];
				part = line.Split(';');
				Teacher teacher = new Teacher(part[0], part[1], part[2], part[3], part[4]);
				Teachers.Add(teacher);
				Count++;
			}
		}

		/// <summary>
		/// Lehrer, deren Name in der Datei IgnoredTeachers steht werden aus der Liste 
		/// entfernt
		/// </summary>
		public void DeleteIgnoredTeachers(string[] ignoredTeachersNames)
		{
			foreach (string ignoredTeacher in ignoredTeachersNames)
			{
				foreach (Teacher teacherOnList in Teachers)
				{
					if (teacherOnList.Name.ToLower() == ignoredTeacher.ToLower())
					{
						Teachers.Remove(teacherOnList);
						foreach (var teacherWithDetails in Details)
						{
							if (teacherOnList.Name.ToLower() == teacherWithDetails.Key.ToLower())
							{
								CountTeachersWithDetails--;
								Count--;
								break;
							}
							else
							{
								Count--;
								break;
							}
						}
						break;
					}
				}
			}
		}

		/// <summary>
		/// Sucht Lehrer in Lehrerliste nach dem Namen
		/// </summary>
		/// <param name="teacherName"></param>
		/// <returns>Index oder -1, falls nicht gefunden</returns>
		public int FindIndexForTeacher(string teacherName)
		{
			int check = -1;
			foreach (Teacher teacher in Teachers)
			{
				++check;
				if(teacher.Name.ToLower() == teacherName.ToLower())
				{
					break;
				}
			}
			return check;
		}


		/// <summary>
		/// Ids der Detailseiten für Lehrer die eine
		/// derartige Seite haben einlesen.
		/// </summary>
		public void InitDetails(string[] lines)
		{
			Details = new Dictionary<string, int>();
			foreach (string line in lines)
			{
				string[] part = new string[2];
				part = line.Split(';');
				Details.TryAdd(part[0], int.Parse(part[1]));
				CountTeachersWithDetails++;
			}
		}

		/// <summary>
		/// HTML-Tabelle der ganzen Lehrer aufbereiten.
		/// </summary>
		/// <returns>Text für die Html-Tabelle</returns>
		public string GetHtmlTable()
		{
			Teachers.Sort();
			StringBuilder sb = new StringBuilder();
			foreach (Teacher teacher in Teachers)
			{
				sb.AppendLine(teacher.GetHtmlForName());
			}
			return sb.ToString();
		}
	}
}
