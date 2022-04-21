using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMessageLibrary {
    public class ConsoleMessages {
        public static string GetString(string message) {
            Console.Write(message);
            string output = Console.ReadLine();
            return output;
        }

        public static void Welcome(int sleep) {
            Console.WriteLine(@"
 __      __       .__                                ___________      __________         __    __  .__           _________.__    .__        
/  \    /  \ ____ |  |   ____  ____   _____   ____   \__    ___/___   \______   \_____ _/  |__/  |_|  |   ____  /   _____/|  |__ |__|_____  
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \    |    | /  _ \   |    |  _/\__  \\   __\   __\  | _/ __ \ \_____  \ |  |  \|  \____ \ 
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/    |    |(  <_> )  |    |   \ / __ \|  |  |  | |  |_\  ___/ /        \|   Y  \  |  |_> >
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >   |____| \____/   |______  /(____  /__|  |__| |____/\___  >_______  /|___|  /__|   __/ 
       \/       \/          \/            \/     \/                           \/      \/                     \/        \/      \/   |__|    
");
            Thread.Sleep(TimeSpan.FromSeconds(sleep));
        }
    }
}
