using static Team;
using static Game;
using static GameHistory;

class Group{

    public List<Team> group_A { get; set; }
    public List<Team> group_B { get; set; }
    public List<Team> group_C { get; set; }

    public GameHistory history { get; set; }

    public void play_group_games(){
        
        Console.WriteLine("Grupna faza I kolo: \n");
        Console.WriteLine("    Grupa A:\n");
        history.game_history.Add(Simulation.game_simulation(group_A[0],group_A[2]));
        history.game_history.Add(Simulation.game_simulation(group_A[1],group_A[3]));

        Console.WriteLine("    Grupa B:\n");
        history.game_history.Add(Simulation.game_simulation(group_B[0],group_B[2]));
        history.game_history.Add(Simulation.game_simulation(group_B[1],group_B[3]));

        Console.WriteLine("    Grupa C:\n");
        history.game_history.Add(Simulation.game_simulation(group_C[0],group_C[2]));
        history.game_history.Add(Simulation.game_simulation(group_C[1],group_C[3]));

        Console.WriteLine("-----------------------------------------------\n");

        Console.WriteLine("Grupna faza II kolo: \n");
        Console.WriteLine("    Grupa A:\n");
        history.game_history.Add(Simulation.game_simulation(group_A[0],group_A[1]));
        history.game_history.Add(Simulation.game_simulation(group_A[2],group_A[3]));

        Console.WriteLine("    Grupa B:\n");
        history.game_history.Add(Simulation.game_simulation(group_B[0],group_B[1]));
        history.game_history.Add(Simulation.game_simulation(group_B[2],group_B[3]));

        Console.WriteLine("    Grupa C:\n");
        history.game_history.Add(Simulation.game_simulation(group_C[0],group_C[1]));
        history.game_history.Add(Simulation.game_simulation(group_C[2],group_C[3]));

        Console.WriteLine("-----------------------------------------------\n");

        Console.WriteLine("Grupna faza III kolo: \n");
        Console.WriteLine("    Grupa A:\n");
        history.game_history.Add(Simulation.game_simulation(group_A[0],group_A[3]));
        history.game_history.Add(Simulation.game_simulation(group_A[1],group_A[2]));

        Console.WriteLine("    Grupa B:\n");
        history.game_history.Add(Simulation.game_simulation(group_B[0],group_B[3]));
        history.game_history.Add(Simulation.game_simulation(group_B[1],group_B[2]));

        Console.WriteLine("    Grupa C:\n");
        history.game_history.Add(Simulation.game_simulation(group_C[0],group_C[3]));
        history.game_history.Add(Simulation.game_simulation(group_C[1],group_C[2]));


    }


    public Group(List<Team> _group_A,List<Team> _group_B, List<Team> _group_C, GameHistory _history ){
        this.group_A = _group_A;
        this.group_B = _group_B;
        this.group_C = _group_C;
        this.history = _history;
    }

}