using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektor
{
	class Rainbow<T> : IComparable<Rainbow<T>>, IEquatable<Rainbow<T>> where T : struct
	{
		public T Value { get; set; }
		public string Name { get; set; }
		public int Lenght { get; set; }
		public Rainbow() { }
		public Rainbow(string Name, int Lenght)
		{
			this.Name = Name;
			this.Lenght = Lenght;
		}
		public void Draw()
		{
			Console.WriteLine("Цвет - {0}, длинна волны - {1} н.м.", this.Name, this.Lenght);
		}

		public int CompareTo(Rainbow<T> obj)
		{
			Rainbow<T> color = (Rainbow<T>)obj;
			if (this.Lenght > color.Lenght) return 1;
			if (this.Lenght < color.Lenght) return -1;
			return 0;
		}

		public bool Equals(Rainbow<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			};
			if (ReferenceEquals(this, other))
			{
				return true;
			};
			return this.Lenght == other.Lenght && int.Equals(this.Lenght, other.Lenght);
		}
	}
	//класс реализующий генератор векторов ДОДЕЛАТЬ
	class GeneratorCodeRainbow<T> : IEnumerable<Rainbow<T>> where T : struct
	{
		public GeneratorCodeRainbow(int count, int start = 0)
		{
			this.Start = start;
			this.Count = count;
		}
		public string c { get; set; }
		public int Start { get; private set; }
		public int Count { get; private set; }
		public IEnumerator<Rainbow<T>> GetEnumerator()
		{
			for (int i = Start; i < Start + Count; i++)
			{
				yield return new Rainbow<T>(c, i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var listcolor = new List<Rainbow<int>>();

			listcolor.Add(new Rainbow<int>("Оранжевый", 605));
			listcolor.Add(new Rainbow<int>("Зеленный", 530));
			listcolor.Add(new Rainbow<int>("Голубой", 495));
			listcolor.Add(new Rainbow<int>("Синий", 465));
			listcolor.Add(new Rainbow<int>("Красный", 700));
			listcolor.Add(new Rainbow<int>("Желтый", 580));
			listcolor.Add(new Rainbow<int>("Фиалетовый", 415));
			foreach (var item in listcolor)
			{
				item.Draw();
			}
			//сортировка через IComparable
			Console.WriteLine(" ");
			listcolor.Sort();
			Console.WriteLine("________________________________________");
			foreach (var item in listcolor)
			{
				item.Draw();
			}
			// сравнение цветов
			Console.WriteLine("________________________________________");
			var color1 = new Rainbow<int>("Красный", 700);
			var color2 = new Rainbow<int>("Синий", 465);
			Console.WriteLine("Сравнение {0} и {1}", color1.Name, color2.Name);
			if (color1.Equals(color2))
			{
				Console.WriteLine("Цвета совпадают");
			}
			else
			{
				Console.WriteLine("Цвета не совпадают");
			}
			//повторное сравнение цветов для проверки функции Equals
			Console.WriteLine("________________________________________");
			var color3 = new Rainbow<int>("Красный", 700);
			var color4 = new Rainbow<int>("Красный", 700);
			Console.WriteLine("Сравнение {0} и {1}", color3.Name, color4.Name);
			if (color3.Equals(color4))
			{
				Console.WriteLine("Цвета совпадают");
			}
			else
			{
				Console.WriteLine("Цвета не совпадают");
			}
			Console.WriteLine("________________________________________");
			Console.WriteLine(" ");
			Console.WriteLine("Генератор кода");
			Console.WriteLine(" ");
			//Генератор кода Радуги из новых цветов с возможностью указания длинный волны в методе генератора
			var lc = GetRainbowSimple();
			foreach (var item in lc)
			{
				item.Draw();
			}
			Console.ReadKey();
		}
		/// <summary>
		/// Метод заполняет список из объектов класса Rainbow. Метод использует тип double.
		/// </summary>
		/// <param name="start">начальный диапазон волны</param>
		/// <param name="count">конечный диапазон волны</param>
		/// <returns></returns>
		static IEnumerable<Rainbow<double>> GetRainbowSimple(int start = 415, int count = 700)
		{
			var results = new List<Rainbow<double>>();
			for (int i = start; i < count; i = i + 50)
			{
				results.Add(new Rainbow<double>("length color " + i, i));
			}
			return results;
		}
	}
}
