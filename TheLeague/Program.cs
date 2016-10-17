using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data of all Leagues, Teams, Players, Coaches to be processed
            string AllData = "<American Football Conference>, *Denver Broncos*, Austin Davis, Paxton Lynch, Trevor Siemian, C.J. Anderson, Kapri Bibbs, Devontae Booker, Andy Janovich, Bennie Fowler, Cody Latimer, Jordan Norwood, Emmanuel Sanders, Jordan Taylor, Demaryius Thomas, Virgil Green, Jeff Heuerman, John Phillips, Sam Brenner, James Ferentz, Matt Paradis, Max Garcia, Connor McGovern, Russell Okung, Ty Sambrailo, Michael Schofield, Donald Stephenson,  Darrion Weems,  Jared Crick, Adam Gotsis, Vance Walker, Billy Winn, Derek Wolfe, Darius Kilgo, Sylvester Williams, Zaire Anderson, Shaquil Barrett, Todd Davis, Brandon Marshall, Von Miller, Corey Nelson, Shane Ray, DeMarcus Ware, Dekoda Watson, Lorenzo Doss, Chris Harris Jr., Bradley Roby, Aqib Talib, Kayvon Webster, Shiloh Keo, Will Parks, Justin Simmons, Darian Stewart, T.J. Ward, Brandon McManus, Riley Dixon, Casey Kreiter, _Gary Kubiak_, _Wade Phillups_, _Rick Dennison_, _Joe Decamillis_, *Kansas City Chiefs*, Alex Smith, Jamal Charrells, _Andy Reid_, *Oakland Raiders*, Derik Carr, some other fucking raider, _Jack DelRio_, *San Diego Chargers*, Fucking Rivers, Antonio Gates, _Adam Gates_";

            Sport nfl = new Sport("National Football League", SportType.Football);

            League lastLeagueSeen = null;
            Team lastTeamSeen = null;
            Player lastPlayerSeen = null;
            Coach lastCoachSeen = null;

            Action<string> process = str =>
            {
                if (str.IndexOf("<") == 0)
                //check for first instense of league and add to sport
                {
                    lastLeagueSeen = new League(str.Substring(1, str.Length - 1));
                    nfl.leagues = nfl.leagues.Concat(new League[] { lastLeagueSeen });
                }
                else if (str.IndexOf("*") == 0)
                // check for first intense of Team and add to sport and league
                {
                    lastTeamSeen = new Team(str.Substring(1, str.Length - 1), "Hometown");
                    nfl.teams = nfl.teams.Concat(new Team[] { lastTeamSeen });
                    lastLeagueSeen.teams = lastLeagueSeen.teams.Concat(new Team[] { lastTeamSeen });
                }
                else if (str.IndexOf("_") == 0)
                //check for first instence of coach and add to team
                {
                    lastCoachSeen = new Coach(str.Substring(1, str.Length - 1));
                    lastTeamSeen.coaches = lastTeamSeen.coaches.Concat(new Coach[] { lastCoachSeen });
                }
                else
                // if not league coach or team then is player and add to team
                {
                    lastPlayerSeen = new Player(str.Substring(1, str.Length - 1), 27);
                    lastTeamSeen.players = lastTeamSeen.players.Concat(new Player[] { lastPlayerSeen });
                }
            };

            foreach (string s in AllData.Split(new char[] { ',' }))
            {
                process(s.Trim());

                Console.WriteLine(nfl.leagues.ToString());
                Console.WriteLine(nfl.teams.ToString());
                Console.WriteLine(lastLeagueSeen.teams.ToString());
                Console.WriteLine(lastTeamSeen.players.ToString());
                Console.WriteLine(lastTeamSeen.coaches.ToString());

            }
            Console.ReadLine();
        }
    }


    public enum SportType
    {
        Football,
        BascketBall,
        Futball,
        Hockey,
        Baseball
    }
    class Sport
    {
        public IEnumerable<League> leagues = new League[2];
        public SportType type;
        string name;
        public IEnumerable<Team> teams = new Team[32];

        // List<Team> getALLTeams();
        //Player getPlayerOfTheYear();
        //Coach getCoachOfTheYear();
        public Sport(string name, SportType type)
        {
            this.name = name;
            this.type = type;

        }
        public override string ToString()
        {
            return $"{name}";
        }



    }

    class League
    {
        public IEnumerable<Team> teams = new List<Team>();
        string name;
        public League(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }

    class Team
    {
        public IEnumerable<Coach> coaches = new Coach[4];
        public IEnumerable<Player> players = new Player[53];
        string name;
        string hometown;
        public Team(string name, string hometown)
        {
            this.name = name;
            this.hometown = hometown;
        }
        public override string ToString()
        {
            return $"{name}";
        }

    }

    class Coach
    {
        string name;
        public Coach(string name)
        {
            this.name = name;

        }
        public override string ToString()
        {
            return $"{name}";
        }

    }
    class Player
    {
        string name;
        int points;
        public Player(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }


















}
