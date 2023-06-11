using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps
{
    public class Postfix
    {
        private string expression;
        Stack<string> S = new Stack<string>();

        /// <summary>
        /// Postfix ifade sonucu dondurur.
        /// </summary>
        /// <returns>String S.Pop()</returns>
        public string Expression()
        {
            // İslem durumuna gececek degiskenler.
            int val_1, val_2, result;

            // Postfix ifade uzunlugu kadar doner.
            for (int i = 0; i < expression.Length; i++)
            {
                // indexten sonraki ilk karakteri alir.
                string chr = expression.Substring(i, 1);
                if (chr.Equals("*"))
                {
                    // Son degerleri toplar  1 2 + Pop 2 Pop 1 and add
                    val_1 = int.Parse(S.Pop());
                    val_2 = int.Parse(S.Pop());
                    result = val_2 * val_1;

                    // Sonucu stağe atar
                    S.Push(result.ToString());
                }
                else if (chr.Equals("/"))
                {
                    val_1 = int.Parse(S.Pop());
                    val_2 = int.Parse(S.Pop());
                    result = val_2 / val_1;

                    S.Push(result.ToString());
                }
                else if (chr.Equals("+"))
                {
                    val_1 = int.Parse(S.Pop());
                    val_2 = int.Parse(S.Pop());
                    result = val_2 + val_1;

                    S.Push(result.ToString());
                }
                else if (chr.Equals("-"))
                {
                    val_1 = int.Parse(S.Pop());
                    val_2 = int.Parse(S.Pop());
                    result = val_2 - val_1;

                    S.Push(result.ToString());
                }
                else
                {
                    // Eger bir islem operatoru değilse stack' e ekle.
                    S.Push(chr);
                }
            }

            // Elde edilen en son sonucu dondurur.
            return S.Pop();
        }

        /// <summary>
        /// Gonderilen Postfix ifadesini isler. 
        /// </summary>
        /// <param name="expression">String arguman</param>
        /// <returns>Stack result</returns>
        public static string Run(string expression)
        {
            Postfix postfix = new Postfix();
            postfix.expression = expression;
            return postfix.Expression();
        }
    }
}
