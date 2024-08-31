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

        
        group_ranks(group_A);
        group_ranks(group_B);
        group_ranks(group_C);


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


    private void group_ranks(List<Team> g){
        Team tmp;
        for(int i = 0; i <= g.Count - 2; i++){
            for(int j = 0; j <= g.Count - 2; j++){
                if(g[j].bodovi < g[j+1].bodovi){
                    tmp = g[j+1];
                    g[j+1] = g[j];
                    g[j] = tmp;
                }
            }
        }

        // the first 3 can be the same and the last 3 can be the same

        bool krug = false;
        int a = 0;
        int b = 0;
        int c = 0;

        if(g[0].bodovi == g[1].bodovi){
            if(g[1].bodovi == g[2].bodovi){
                krug = true;
                a=0;
                b=1;
                c=2;
            }
        }
        if(g[1].bodovi == g[2].bodovi){
            if(g[2].bodovi == g[3].bodovi){
                krug = true;
                a=1;
                b=2;
                c=3;
            }
        }
        if(krug){
            int team1_diff = 0;
            int team2_diff = 0;
            int team3_diff = 0;
            if(history.match_winner(g[a],g[b]) == g[a].name){
                team1_diff += history.get_point_difference(g[a],g[b]);
            } else {
                team2_diff += history.get_point_difference(g[a],g[b]);
            }

            if(history.match_winner(g[a],g[c]) == g[a].name){
                team1_diff += history.get_point_difference(g[a],g[c]);
            } else {
                team3_diff += history.get_point_difference(g[a],g[c]);
            }

            if(history.match_winner(g[b],g[c]) == g[b].name){
                team2_diff += history.get_point_difference(g[b],g[c]);
            } else {
                team3_diff += history.get_point_difference(g[b],g[c]);
            }

            if(team1_diff < team2_diff){
                if(team2_diff < team3_diff){
                    tmp = g[a];
                    g[a] = g[c];
                    g[c] = tmp;
                } else {
                    tmp = g[a];
                    g[a] = g[b];
                    g[b] = tmp;
                }
            } else {
                if(team1_diff < team3_diff){
                    tmp = g[a];
                    g[a] = g[c];
                    g[c] = tmp;

                    tmp = g[b];
                    g[b] = g[c];
                    g[c] = tmp;                    
                } else if(team2_diff < team3_diff){
                    tmp = g[b];
                    g[b] = g[c];
                    g[c] = tmp;
                }
            }
            
        } else if (g[0].bodovi == g[1].bodovi){
            if(history.match_winner(g[0],g[1]) == g[1].name){
                tmp = g[0];
                g[0] = g[1];
                g[1] = tmp;
            }
        } else if (g[2].bodovi == g[3].bodovi){
            if(history.match_winner(g[2],g[3]) == g[3].name){
                tmp = g[2];
                g[2] = g[3];
                g[3] = tmp;
            }
        }
    }

    /*public List<Team> rank_list(){

    }*/


}