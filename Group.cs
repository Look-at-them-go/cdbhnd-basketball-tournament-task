using static Team;
using static Game;
using static GameHistory;

class Group{

    public List<Team> group_A { get; set; }
    public List<Team> group_B { get; set; }
    public List<Team> group_C { get; set; }

    public GameHistory history { get; set; }


    public Group(List<Team> _group_A,List<Team> _group_B, List<Team> _group_C, GameHistory _history ){
        this.group_A = _group_A;
        this.group_B = _group_B;
        this.group_C = _group_C;
        this.history = _history;
    }

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

        for(int i=0;i < history.game_history.Count;i++){
            for(int j = 0; j < 4;j++){
                // winner points allocation
                if(group_A[j].name == history.game_history[i].winner){
                    group_A[j].bodovi += 2;
                }

                if(group_B[j].name == history.game_history[i].winner){
                    group_B[j].bodovi += 2;
                }

                if(group_C[j].name == history.game_history[i].winner){
                    group_C[j].bodovi += 2;
                }
                // loser points allocation

                if(group_A[j].name == history.game_history[i].loser){
                    group_A[j].bodovi++;
                }

                if(group_B[j].name == history.game_history[i].loser){
                    group_B[j].bodovi++;
                }

                if(group_C[j].name == history.game_history[i].loser){
                    group_C[j].bodovi++;
                }
            }
        }

        for(int i = 0;i < group_A.Count;i++){
            Console.WriteLine(group_A[i].name + " : " + group_A[i].bodovi + "\n");
        }
        Console.WriteLine("-----------------------------------------------\n");
        for(int i = 0;i < group_B.Count;i++){
            Console.WriteLine(group_B[i].name + " : " + group_B[i].bodovi + "\n");
        }
        Console.WriteLine("-----------------------------------------------\n");
        for(int i = 0;i < group_C.Count;i++){
            Console.WriteLine(group_C[i].name + " : " + group_C[i].bodovi + "\n");
        }
        

    }


    /*public List<Team> group_ranks(){

    }*/




}