using System.Text;

namespace RequestProcessingPipeline
{
    public class FromOneToTenMiddleware
    {
        private readonly RequestDelegate _next;

        public FromOneToTenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (int.TryParse(context.Request.Query["number"], out var number))
            {
                if (number < 1 || number > 100000)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid number range. Must be between 1 and 100000.");
                    return;
                }

                var result = ConvertNumberToWords(number);
                await context.Response.WriteAsync(result);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Please provide a 'number' query parameter.");
            }
        }

        private string ConvertNumberToWords(int number)
        {
            if (number == 100000) return "one hundred thousand";
            if (number < 1 || number > 100000) return "Number out of valid range";

            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] hundreds = { "", "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" };

            var result = new StringBuilder();

            if (number >= 1000)
            {
                var thousands = number / 1000;
                result.Append(HandleThousands(thousands));
                number %= 1000;
            }

            if (number >= 100)
            {
                result.Append(hundreds[number / 100] + " ");
                number %= 100;
            }

            if (number >= 20)
            {
                result.Append(tens[number / 10] + " ");
                number %= 10;
            }

            if (number >= 10)
            {
                result.Append(teens[number - 10]);
            }
            else if (number > 0)
            {
                result.Append(units[number]);
            }

            return result.ToString().Trim();
        }

        private string HandleThousands(int thousands)
        {
            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            string result = "";

            if (thousands >= 10)
            {
                result += teens[thousands - 10] + " thousand ";
            }
            else if (thousands > 0)
            {
                result += units[thousands] + " thousand ";
            }

            return result;
        }
    }
}
