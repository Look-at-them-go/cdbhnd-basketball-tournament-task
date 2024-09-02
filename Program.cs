using static Team;
using static Game;
using static GameHistory;
using static Group;
using static Elimination;

List<Team> group_A = new List<Team>();

List<Team> group_Z = new List<Team>();

List<Team> group_C = new List<Team>();


group_A.Add(new Team("Kanada","CAN",7));
group_A.Add(new Team("Australija","AUS",5));
group_A.Add(new Team("Grčka","GRE",14));
group_A.Add(new Team("Španija","ESP",2));

group_Z.Add(new Team("Nemačka","GER",3));
group_Z.Add(new Team("Francuska","FRA",9));
group_Z.Add(new Team("Brazil","BRA",12));
group_Z.Add(new Team("Japan","JPN",26));

group_C.Add(new Team("Sjedinjene Države","USA",1));
group_C.Add(new Team("Srbija","SRB",4));
group_C.Add(new Team("Južni Sudan","SSD",34));
group_C.Add(new Team("Puerto Riko","PRI",16));


GameHistory history = new GameHistory();

Group g = new Group(group_A,group_Z,group_C,history);

g.play_group_games();
g.rank_list();


Console.WriteLine("Plasirane Grupe: \n");
for(int i = 0; i < g.rankings.Count; i++){
    Console.WriteLine((i+1) + ". " + g.rankings[i].name);
}

Console.WriteLine("\n-----------------------------------------------\n");

Elimination e = new Elimination(g.rankings,history);

e.play_elimination();


