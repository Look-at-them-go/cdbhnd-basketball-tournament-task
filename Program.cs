using static Team;
using static Game;
using static GameHistory;
using static Group;


List<Team> group_A = new List<Team>();

List<Team> group_B = new List<Team>();

List<Team> group_C = new List<Team>();


group_A.Add(new Team("Kanada","CAN",7));
group_A.Add(new Team("Australija","AUS",5));
group_A.Add(new Team("Grčka","GRE",14));
group_A.Add(new Team("Španija","ESP",2));

group_B.Add(new Team("Nemačka","GER",3));
group_B.Add(new Team("Francuska","FRA",9));
group_B.Add(new Team("Brazil","BRA",12));
group_B.Add(new Team("Japan","JPN",26));

group_C.Add(new Team("Sjedinjene Države","USA",1));
group_C.Add(new Team("Srbija","SRB",4));
group_C.Add(new Team("Južni Sudan","SSD",34));
group_C.Add(new Team("Puerto Riko","PRI",16));


GameHistory history = new GameHistory();

Group g = new Group(group_A,group_B,group_C,history);

g.play_group_games();


void print_game(Game g){
    Console.WriteLine("GAMES RESULT\n");
    Console.WriteLine("TEAM 1 : " + g.team1 + "\n"
                    + "TEAM 2 : " + g.team2 + "\n"
                    + "WINNER : " + g.winner + "\n"
                    + "LOSER : " + g.loser + "\n"
                    + "TEAM 1 POINTS : " + g.team1_points + "\n"
                    + "TEAM 2 POINTS : " + g.team2_points + "\n"
                    + "TEAM 1 BROJ KOSEVA : " + g.team1_broj_koseva + "\n"
                    + "TEAM 2 BROJ KOSEVA : " + g.team2_broj_koseva + "\n"
                    + "KOS RAZLIKA : " + g.kos_razlika + "\n");
}
