namespace TodoListProject
{
    public class Log
    {
        public Log()
        {
            
        }

        public void LogError(string errorMessage)
        {
            try
            {
                // LogError to console
                Console.WriteLine($"Error: {errorMessage}");

            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during logging
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }
        public void LogInformation(string info) {

            try
            {
                // LogInformation to console
                Console.WriteLine($"info: {info}");

            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during logging
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }
    }
}
