using static Team;
using static Game;
using static GameHistory;
using static Group;
using static Elimination;

List<Team> group_A = new List<Team>();

List<Team> group_Z = new List<Team>();

List<Team> group_C = new List<Team>();


GameHistory history = new GameHistory();

history.game_history.Add(new Game("Nemačka","Francuska","Francuska","Nemačka",66,90,25,30,24,false));
history.game_history.Add(new Game("Japan","Srbija","Srbija","Japan",100,119,25,30,19,false));
history.game_history.Add(new Game("Sjedinjene Države","Južni Sudan","Sjedinjene Države","Južni Sudan",101,100,25,30,1,false));
history.game_history.Add(new Game("Kanada","Puerto Riko","Kanada","Puerto Riko",103,93,25,30,10,false));
history.game_history.Add(new Game("Australija","Brazil","Australija","Brazil",90,75,25,30,15,false));
history.game_history.Add(new Game("Grčka","Španija","Španija","Grčka",100,80,25,30,20,false));

group_A.Add(new Team("Kanada","CAN",7, history)); 
group_A.Add(new Team("Australija","AUS",5, history)); 
group_A.Add(new Team("Grčka","GRE",14, history));
group_A.Add(new Team("Španija","ESP",2, history));

group_Z.Add(new Team("Nemačka","GER",3, history)); 
group_Z.Add(new Team("Francuska","FRA",9, history)); 
group_Z.Add(new Team("Brazil","BRA",12, history)); 
group_Z.Add(new Team("Japan","JPN",26, history)); 

group_C.Add(new Team("Sjedinjene Države","USA",1, history)); 
group_C.Add(new Team("Srbija","SRB",4, history)); 
group_C.Add(new Team("Južni Sudan","SSD",34, history)); 
group_C.Add(new Team("Puerto Riko","PRI",16, history)); 


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


