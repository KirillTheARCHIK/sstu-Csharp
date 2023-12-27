using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практики
{
    //1. Описать базовый класс CStr - строка.
    //Обязательные поля класса CStr:
    //  поле для хранения символов строки,
    //  значение типа byte хранит длину строки в байтах.
    //Обязательные методы должны выполнять следующие действия:
    //  конструктор без параметров;
    //  конструктор, принима-ющий в качестве параметра строку типа string,
    //  конструктор, прини-мающий в качестве параметра символ;
    //Свойства:
    //  получение длины строки;
    //  очистка строки(сделать строку пустой).
    //Переопределить следующие операции:
    //  сложение(+) — конкатенация строк;
    //  операция(==) - проверка на равенство.
    //
    //Описать производный от СStr класс CDstr - десятичная строка.
    //Строки данного класса могут содержать только символы десятичных цифр и символы - и +, задающие знак числа.
    //Символы - или + могут находиться только в первой позиции числа, причем символ + может отсутствовать, в этом случае число считается положительным.
    //Если в составе инициализирующей строки будут встречены любые символы, отличные от допустимых, десятичная строка принимает нулевое значение.
    //Содержимое данной строки рассматривается как десятичное число.
    //Класс CDStr содержит следу-ющие методы:
    //  конструктор без параметров;
    //  конструктор, принимающий в качестве параметра строку типа string;
    //Свойства:
    //  метод, преобразующий данную строку в целое число.
    //Переопределить следующие операции:
    //  вычитание (-) — арифметическая разность строк;
    //  операция > - проверка на больше(по значению);
    //  операция < - проверка на меньше (по значению).
    //
    //Написать демонстрационную программу.
    //Для усложнённого использовать паттерн проектирования
    internal class Practice10 : SubProgram
    {
        public Practice10(History history) : base("p10", history, new Listeners()
        {
            ["start"] = delegate (Command command, History hist)
            {

            }
        })
        { }
    }

    //1. Описать базовый класс CStr - строка.
    //Обязательные поля класса CStr:
    //  поле для хранения символов строки,
    //  значение типа byte хранит длину строки в байтах.
    //Обязательные методы должны выполнять следующие действия:
    //  конструктор без параметров;
    //  конструктор, принимающий в качестве параметра строку типа string,
    //  конструктор, принимающий в качестве параметра символ;
    //Свойства:
    //  получение длины строки;
    //  очистка строки(сделать строку пустой).
    //Переопределить следующие операции:
    //  сложение(+) — конкатенация строк;
    //  операция(==) - проверка на равенство.
    internal class CStr
    {
        char[] chars;
        byte lengthInBytes;

        public CStr()
        {
            Chars = new char[0];
            lengthInBytes = 0;
        }
        public CStr(string str)
        {
            Array
            Chars = str.ToCharArray();
            lengthInBytes = (byte)(Chars.Length * sizeof(char));
        }
        public CStr(char c)
        {
            Chars = new char[1] { c };
            lengthInBytes = (byte)(Chars.Length * sizeof(char));
        }

        public virtual char[] Chars
        {
            get { return chars; }
            set
            {
                chars = value;
            }
        }
        public byte LengthInBytes { get { return lengthInBytes; } }
        public void Clear()
        {
            chars = new char[0];
            lengthInBytes = 0;
        }
        public override string ToString()
        {
            return new string(chars);
        }
        public override bool Equals(object obj)
        {
            if (obj is CStr)
            {
                if (this != null && obj != null)
                {
                    return this.chars.SequenceEqual((obj as CStr).chars);
                }
            }
            return base.Equals(obj);
        }

        public static CStr operator +(CStr a, CStr b)
        {
            var newStr = new CStr();
            var charList = new List<char>(a.chars);
            charList.AddRange(b.chars);
            newStr.chars = charList.ToArray();
            newStr.lengthInBytes = (byte)(a.lengthInBytes + b.lengthInBytes);
            return newStr;
        }

        public static bool operator ==(CStr a, CStr b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(CStr a, CStr b)
        {
            return !(a == b);
        }
    }
    //Описать производный от СStr класс CDstr - десятичная строка.
    //Строки данного класса могут содержать только символы десятичных цифр и символы - и +, задающие знак числа.
    //Символы - или + могут находиться только в первой позиции числа, причем символ + может отсутствовать, в этом случае число считается положительным.
    //Если в составе инициализирующей строки будут встречены любые символы, отличные от допустимых, десятичная строка принимает нулевое значение.
    //Содержимое данной строки рассматривается как десятичное число.
    //Класс CDStr содержит следующие методы:
    //  конструктор без параметров;
    //  конструктор, принимающий в качестве параметра строку типа string;
    //Свойства:
    //  метод, преобразующий данную строку в целое число.
    //Переопределить следую-щие операции:
    //  вычитание (-) — арифметическая разность строк;
    //  операция > — проверка на больше(по значению);
    //  операция < — про-верка на меньше (по значению).
    internal class CDstr : CStr
    {
        public CDstr() : this("0") { }
        public CDstr(string str)
        {
            Chars = str.ToCharArray();
        }
        public override char[] Chars
        {
            get => base.Chars;
            set
            {
                try
                {
                    var firstChar = value[0];
                    if (firstChar < '0' && firstChar > '9' && firstChar != '+' && firstChar != '-')
                    {
                        throw new ArgumentException("Входная строка должна содержать только цифры и знаки + и - в начале");
                    }
                    int.Parse(value.ToString());
                    Chars = value;
                }
                catch (Exception)
                {
                    Chars = new char[] { '0' };
                }
            }
        }
        public int ToInt()
        {
            return int.Parse(Chars.ToString());
        }
        public static CDstr operator -(CDstr a, CDstr b)
        {
            return new CDstr((a.ToInt() - b.ToInt()).ToString());
        }
        public static bool operator >(CDstr a, CDstr b)
        {
            return a.ToInt() > b.ToInt();
        }
        public static bool operator <(CDstr a, CDstr b)
        {
            return a.ToInt() < b.ToInt();
        }
    }
}
