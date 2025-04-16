using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace progr3
{
    public partial class Form1 : Form
    {
        private string inputText;
        private int currentPosition;
        private StringBuilder buffer;
        private List<string> keywords = new List<string>();
        private List<string> operators = new List<string>();
        private List<string> specialSymbols = new List<string>();
        private List<string> stringConstants = new List<string>();
        private List<string> numericConstants = new List<string>();
        private List<string> identifiers = new List<string>();

        private readonly HashSet<string> csharpKeywords = new HashSet<string>
        {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
            "char", "checked", "class", "const", "continue", "decimal", "default",
            "delegate", "do", "double", "else", "enum", "event", "explicit",
            "extern", "false", "finally", "fixed", "float", "for", "foreach",
            "goto", "if", "implicit", "in", "int", "interface", "internal",
            "is", "lock", "long", "namespace", "new", "null", "object", "operator",
            "out", "override", "params", "private", "protected", "public",
            "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof",
            "stackalloc", "static", "string", "struct", "switch", "this", "throw",
            "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
            "ushort", "using", "var", "virtual", "void", "volatile", "while",
            "begin", "end", "to", "do", "integer", "writeln"
        };

        public Form1()
        {
            InitializeComponent();
            buffer = new StringBuilder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnalyzeCode();
        }

        private void AnalyzeCode()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            keywords.Clear();
            operators.Clear();
            specialSymbols.Clear();
            stringConstants.Clear();
            numericConstants.Clear();
            identifiers.Clear();

            inputText = textBox1.Text;
            currentPosition = 0;

            if (string.IsNullOrEmpty(inputText)) return;

            inputText += "\uFFFF";
            int type = 0;
            while (StepLexAnalyze(ref type) > 0) { }
            DisplayResults();
        }

        private char GetInputChar()
        {
            if (currentPosition < inputText.Length)
                return inputText[currentPosition++];
            return '\0';
        }

        private void RevLit(char c)
        {
            if (currentPosition > 0) currentPosition--;
        }

        private void PutInBuf(char c)
        {
            buffer.Append(c);
        }

        private bool Number(char c)
        {
            return char.IsDigit(c);
        }

        private bool Letter(char c)
        {
            return char.IsLetter(c) || c == '_';
        }

        private int Buf_Intend_Key(ref int type)
        {
            string lexeme = buffer.ToString();
            buffer.Clear();

            if (csharpKeywords.Contains(lexeme))
            {
                if (!keywords.Contains(lexeme))
                    keywords.Add(lexeme);
                type = 1; // Ключевое слово
                return keywords.IndexOf(lexeme) + 1;
            }
            else
            {
                if (!identifiers.Contains(lexeme))
                    identifiers.Add(lexeme);
                type = 4; // Идентификатор
                return identifiers.IndexOf(lexeme) + 1;
            }
        }

        private int Buf_Oper(ref int type)
        {
            string lexeme = buffer.ToString();
            buffer.Clear();

            if (!operators.Contains(lexeme))
                operators.Add(lexeme);
            type = 2; // Оператор
            return operators.IndexOf(lexeme) + 1;
        }

        private int Buf_Spec(ref int type)
        {
            string lexeme = buffer.ToString();
            buffer.Clear();

            if (!specialSymbols.Contains(lexeme))
                specialSymbols.Add(lexeme);
            type = 3; // Специальный символ
            return specialSymbols.IndexOf(lexeme) + 1;
        }

        private int Buf_Num(ref int type)
        {
            string lexeme = buffer.ToString();
            buffer.Clear();

            if (!numericConstants.Contains(lexeme))
                numericConstants.Add(lexeme);
            type = 5; // Числовая константа
            return numericConstants.IndexOf(lexeme) + 1;
        }

        private int Buf_Str(ref int type)
        {
            string lexeme = buffer.ToString();
            buffer.Clear();
            if (lexeme.Length >= 2 && (lexeme[0] == '"' || lexeme[0] == '\'') &&
                lexeme[lexeme.Length - 1] == lexeme[0])
            {
                lexeme = lexeme.Substring(1, lexeme.Length - 2);
            }

            if (!stringConstants.Contains(lexeme))
                stringConstants.Add(lexeme);
            type = 6; // Строковая константа
            return stringConstants.IndexOf(lexeme) + 1;
        }

        private int StepLexAnalyze(ref int type)
        {
            char c;
            State T = State.S;

            do
            {
                c = GetInputChar();
                switch (T)
                {
                    case State.S:
                        if (c == ' ' || c == '\t' || c == '\r' || c == '\n') break;
                        if (c == '{') { T = State.cm; break; }
                        if (c == '"' || c == '\'') { PutInBuf(c); T = State.st; break; }
                        if (c == '\uFFFF') return 0;

                        PutInBuf(c);
                        if (Letter(c)) { T = State.id; break; }
                        if (c == '=' || c == '+' || c == '-' || c == '*' || c == '/' ||
                            c == '%' || c == '<' || c == '>' || c == '!' || c == '&' || c == '|')
                        {
                            char nextChar = GetInputChar();
                            if ((c == ':' && nextChar == '=') ||
                                (c == '<' && nextChar == '=') ||
                                (c == '>' && nextChar == '=') ||
                                (c == '=' && nextChar == '=') ||
                                (c == '!' && nextChar == '=') ||
                                (c == '&' && nextChar == '&') ||
                                (c == '|' && nextChar == '|'))
                            {
                                PutInBuf(nextChar);
                            }
                            else
                            {
                                RevLit(nextChar);
                            }
                            return Buf_Oper(ref type);
                        }
                        if (c == ':') { T = State.ss; break; }
                        if (c == '.' || c == ';' || c == ',' || c == '(' || c == ')' ||
                            c == '[' || c == ']' || c == '{' || c == '}')
                            return Buf_Spec(ref type);
                        if (Number(c)) { T = State.cf; break; }
                        return -1;

                    case State.id:
                        if (Number(c) || Letter(c)) { PutInBuf(c); break; }
                        else { RevLit(c); return Buf_Intend_Key(ref type); }

                    case State.ss:
                        if (c == '=')
                        {
                            PutInBuf(c);
                            return Buf_Oper(ref type);
                        }
                        RevLit(c);
                        return Buf_Spec(ref type);

                    case State.cf:
                        if (Number(c) || c == '.')
                        {
                            PutInBuf(c);
                            break;
                        }
                        RevLit(c);
                        return Buf_Num(ref type);

                    case State.st:
                        if (c == '"' || c == '\'')
                        {
                            PutInBuf(c);
                            return Buf_Str(ref type);
                        }
                        PutInBuf(c);
                        break;
                }
            } while (true);
        }

        private void DisplayResults()
        {
            // Служебные слова
            for (int i = 0; i < keywords.Count; i++)
            {
                textBox2.AppendText($"{i + 1} {keywords[i]}{Environment.NewLine}");
            }

            // Операции и отношения
            for (int i = 0; i < operators.Count; i++)
            {
                textBox3.AppendText($"{i + 1} {operators[i]}{Environment.NewLine}");
            }

            // Специальные символы
            for (int i = 0; i < specialSymbols.Count; i++)
            {
                textBox4.AppendText($"{i + 1} {specialSymbols[i]}{Environment.NewLine}");
            }

            // Строковые константы
            for (int i = 0; i < stringConstants.Count; i++)
            {
                textBox5.AppendText($"{i + 1} {stringConstants[i]}{Environment.NewLine}");
            }

            // Числовые константы
            for (int i = 0; i < numericConstants.Count; i++)
            {
                textBox6.AppendText($"{i + 1} {numericConstants[i]}{Environment.NewLine}");
            }

            // Идентификаторы
            for (int i = 0; i < identifiers.Count; i++)
            {
                textBox7.AppendText($"{i + 1} {identifiers[i]}{Environment.NewLine}");
            }
        }

        private enum State { S, cm, id, ss, cf, st }
    }
}