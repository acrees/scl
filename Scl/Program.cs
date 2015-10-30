using Scl.Commands;
using Scl.IO;
using Scl.Persistance;
using Scl.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeProvider = new SystemCurrentTimeProvider();

            var repo = new UserRepository();
            var getUser = new CreateOrRetrieveUserByName(repo);

            var output = new StandardOutput();
            var formatter = new PostFormatter(timeProvider);
            var printer = new PrintPosts(formatter, output);
            var printWall = new PrintWall(formatter, output);

            var publisher = new PublishPost(timeProvider);
            var follow = new FollowUser();

            var dispatcher = new CommandDispatcher(
                getUser, printer, publisher, follow, printWall);

            while(true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                dispatcher.Run(input.Split(' '));
            }
        }
    }
}
