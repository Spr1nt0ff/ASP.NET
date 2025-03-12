namespace RequestProcessingPipeline
{
    public static class SignUpExtensions
    {
        public static IApplicationBuilder UseFromElevenToNineteen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SignUpMiddleware>();
        }
    }
}
