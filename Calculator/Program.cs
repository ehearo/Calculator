using System;


public class CalcInfo
{
    public string tag;
    public Func<float, float, float> func;
    public CalcInfo(string tag, Func<float, float, float> func)
    {
        this.tag = tag;
        this.func = func;
    }
}
class program
{
    static CalcInfo[] configs = new CalcInfo[]
    {
    new CalcInfo("+",(a,b)=>a+ b),
    new CalcInfo("-",(a,b)=>a- b),
    new CalcInfo("*",(a,b)=>a* b),
    new CalcInfo("/",(a,b)=>a/ b),
    new CalcInfo("%",(a,b)=>a% b),
    };
    private static void CalcOneLine(string inputStr)
    {
        int index = -1;
        Func<float, float, float> func = null;
        for (int i = 0; i < configs.Length; i++)
        {
            var item = configs[i];
            index = inputStr.IndexOf(item.tag);
            if (index != -1)
            {
                func = item.func;
                break;
            }
        }
        if (index == -1)
        {
            Console.WriteLine("不支援運算");
            return;
        }
        CalcResult(inputStr, func, index);

    }
    private static void CalcResult(string inputStr, Func<float, float, float> func, int index)
    {
        float numStr1 = float.Parse(inputStr.Substring(0, index));
        float numStr2 = float.Parse(inputStr.Substring(index + 1, inputStr.Length - index - 1));
        float result = func(numStr1, numStr2);
        Console.WriteLine(result);
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("請輸入數字及運算(ex.8+9)");
            string inputStr = Console.ReadLine();
            CalcOneLine(inputStr);
        }
    }

}