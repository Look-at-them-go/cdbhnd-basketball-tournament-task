using static Team;
using static Game;
using static GameHistory;

class Group{

    public List<Team> group_A { get; set; }
    public List<Team> group_B { get; set; }
    public List<Team> group_C { get; set; }

    public List<Team> rankings { get; set; }

    public GameHistory history { get; set; }


    public Group(List<Team> _group_A,List<Team> _group_B, List<Team> _group_C, GameHistory _history ){
        this.group_A = _group_A;
        this.group_B = _group_B;
        this.group_C = _group_C;
        this.history = _history;
        this.rankings = new List<Team>();
    }

    public void play_group_games(){
        
        Console.WriteLine("\nGrupna faza I kolo: \n");
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

        Console.WriteLine("-----------------------------------------------\n");
        Console.WriteLine("Konacan plasman u grupama:");
        Console.WriteLine("    Grupa A (Ime - pobede/porazi/bodovi/postignuti koševi/primljeni koševi/koš razlika):");
        for(int i = 0; i < group_A.Count; i++){
            string spacing = "";
            for(int j = 0; j < (20 - (group_A[i].name).Length) ; j++){
                spacing += " ";
            }
            Console.WriteLine("        " + (i+1) +". " + group_A[i].name 
                                + spacing 
                                + history.number_of_wins(group_A[i]) 
                                + "/" + history.number_of_losses(group_A[i])
                                + "/" + group_A[i].bodovi
                                + "/" + history.get_broj_koseva(group_A[i])
                                + "/" + history.primljeni_kosevi(group_A[i])
                                + "/" + history.get_kos_razlika(group_A[i]));
        }

        Console.WriteLine("    Grupa B (Ime - pobede/porazi/bodovi/postignuti koševi/primljeni koševi/koš razlika):");
        for(int i = 0; i < group_B.Count; i++){
            string spacing = "";
            for(int j = 0; j < (20 - (group_B[i].name).Length) ; j++){
                spacing += " ";
            }
            Console.WriteLine("        " + (i+1) +". " + group_B[i].name 
                                + spacing 
                                + history.number_of_wins(group_B[i]) 
                                + "/" + history.number_of_losses(group_B[i])
                                + "/" + group_B[i].bodovi
                                + "/" + history.get_broj_koseva(group_B[i])
                                + "/" + history.primljeni_kosevi(group_B[i])
                                + "/" + history.get_kos_razlika(group_B[i]));
        }

        Console.WriteLine("    Grupa C (Ime - pobede/porazi/bodovi/postignuti koševi/primljeni koševi/koš razlika):");
        for(int i = 0; i < group_C.Count; i++){
            string spacing = "";
            for(int j = 0; j < (20 - (group_C[i].name).Length) ; j++){
                spacing += " ";
            }
            Console.WriteLine("        " + (i+1) +". " + group_C[i].name 
                                +  spacing
                                + history.number_of_wins(group_C[i]) 
                                + "/" + history.number_of_losses(group_C[i])
                                + "/" + group_C[i].bodovi
                                + "/" + history.get_broj_koseva(group_C[i])
                                + "/" + history.primljeni_kosevi(group_C[i])
                                + "/" + history.get_kos_razlika(group_C[i]));
        }

        Console.WriteLine("\n-----------------------------------------------\n");

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


    private List<Team> rank(Team a, Team b, Team c){
        List<Team> rank = new List<Team>();

        rank.Add(a);
        rank.Add(b);
        rank.Add(c);

        int a_razlika = history.get_kos_razlika(a);
        int b_razlika = history.get_kos_razlika(b);
        int c_razlika = history.get_kos_razlika(c);

        int a_broj_koseva = history.get_broj_koseva(a);
        int b_broj_koseva = history.get_broj_koseva(b);
        int c_broj_koseva = history.get_broj_koseva(c);

        Team tmp;

        if(a.bodovi == b.bodovi && b.bodovi == c.bodovi){
            if(a_razlika == b_razlika && b_razlika == c_razlika){
                for(int i = 0; i <= rank.Count - 2; i++){
                    for(int j = 0; j <= rank.Count - 2; j++){
                        if(history.get_broj_koseva(rank[j]) < history.get_broj_koseva(rank[j+1])){
                            tmp = rank[j+1];
                            rank[j+1] = rank[j];
                            rank[j] = tmp;
                        }
                    }
                }
            } else if(a_razlika == b_razlika){
                if(c_razlika > a_razlika){
                    rank[0] = c;
                    if(a_broj_koseva > b_broj_koseva){
                        rank[1] = a;
                        rank[2] = b;
                    } else {
                        rank[1] = b;
                        rank[2] = a;
                    }
                } else {
                    rank[2] = c;
                    if(a_broj_koseva > b_broj_koseva){
                        rank[0] = a;
                        rank[1] = b;
                    } else {
                        rank[0] = b;
                        rank[1] = a;
                    }
                }
                
            } else if(b_razlika == c_razlika){
                if(a_razlika > b_razlika){
                    rank[0] = a;
                    if(b_broj_koseva > c_broj_koseva){
                        rank[1] = b;
                        rank[2] = c;
                    } else {
                        rank[1] = c;
                        rank[2] = b;
                    }
                } else {
                    rank[2] = a;
                    if(b_broj_koseva > c_broj_koseva){
                        rank[0] = b;
                        rank[1] = c;
                    } else {
                        rank[0] = c;
                        rank[1] = b;
                    }
                }
            } else if(a_razlika == c_razlika){
                if(b_razlika > a_razlika){
                    rank[0] = b;
                    if(a_broj_koseva > c_broj_koseva){
                        rank[1] = a;
                        rank[2] = c;
                    } else {
                        rank[1] = c;
                        rank[2] = a;
                    }
                } else {
                    rank[2] = b;
                    if(a_broj_koseva > c_broj_koseva){
                        rank[0] = a;
                        rank[1] = c;
                    } else {
                        rank[0] = c;
                        rank[1] = a;
                    }
                }
            } else {
                for(int i = 0; i <= rank.Count - 2; i++){
                    for(int j = 0; j <= rank.Count - 2; j++){
                        if(history.get_kos_razlika(rank[j]) < history.get_kos_razlika(rank[j+1])){
                            tmp = rank[j+1];
                            rank[j+1] = rank[j];
                            rank[j] = tmp;
                        }
                    }
                }
            }
        } else if (a.bodovi == b.bodovi){
            if(c.bodovi > a.bodovi){
                rank[0] = c;
                if(a_razlika == b_razlika){
                    if(a_broj_koseva > b_broj_koseva){
                        rank[1] = a;
                        rank[2] = b;
                    } else {
                        rank[1] = b;
                        rank[2] = a;
                    }
                } else if(a_razlika > b_razlika){
                    rank[1] = a;
                    rank[2] = b;
                } else {
                    rank[1] = b;
                    rank[2] = a;
                }
            } else {
                rank[2] = c;
                if(a_razlika == b_razlika){
                    if(a_broj_koseva > b_broj_koseva){
                        rank[0] = a;
                        rank[1] = b;
                    } else {
                        rank[0] = b;
                        rank[1] = a;
                    }
                } else if(a_razlika > b_razlika){
                    rank[0] = a;
                    rank[1] = b;
                } else {
                    rank[0] = b;
                    rank[1] = a;
                }
            }
        } else if (b.bodovi == c.bodovi){
            if(a.bodovi > b.bodovi){
                rank[0] = a;
                if(b_razlika == c_razlika){
                    if(b_broj_koseva > c_broj_koseva){
                        rank[1] = b;
                        rank[2] = c;
                    } else {
                        rank[1] = c;
                        rank[2] = b;
                    }
                } else if(b_razlika > c_razlika){
                    rank[1] = b;
                    rank[2] = c;
                } else {
                    rank[1] = c;
                    rank[2] = b;
                }
            } else {
                rank[2] = a;
                if(b_razlika == c_razlika){
                    if(b_broj_koseva > c_broj_koseva){
                        rank[0] = b;
                        rank[1] = c;
                    } else {
                        rank[0] = c;
                        rank[1] = b;
                    }
                } else if(b_razlika > c_razlika){
                    rank[0] = b;
                    rank[1] = c;
                } else {
                    rank[0] = c;
                    rank[1] = b;
                }
            }
        } else if (a.bodovi == c.bodovi){
            if(b.bodovi > a.bodovi){
                rank[0] = b;
                if(a_razlika == c_razlika){
                    if(a_broj_koseva > c_broj_koseva){
                        rank[1] = a;
                        rank[2] = c;
                    } else {
                        rank[1] = c;
                        rank[2] = a;
                    }
                } else if(a_razlika > c_razlika){
                    rank[1] = a;
                    rank[2] = c;
                } else {
                    rank[1] = c;
                    rank[2] = a;
                }
            } else {
                rank[2] = b;
                if(a_razlika == c_razlika){
                    if(a_broj_koseva > c_broj_koseva){
                        rank[0] = a;
                        rank[1] = c;
                    } else {
                        rank[0] = c;
                        rank[1] = a;
                    }
                } else if(a_razlika > c_razlika){
                    rank[0] = a;
                    rank[1] = c;
                } else {
                    rank[0] = c;
                    rank[1] = a;
                }
            }
        } else {
            for(int i = 0; i <= rank.Count - 2; i++){
                for(int j = 0; j <= rank.Count - 2; j++){
                    if(rank[j].bodovi < rank[j+1].bodovi){
                        tmp = rank[j+1];
                        rank[j+1] = rank[j];
                        rank[j] = tmp;
                    }
                }
            }
        }
        
        
        return rank;
    }

    public void rank_list(){
        List<Team> prvoplasirani = rank(group_A[0], group_B[0], group_C[0]);
        List<Team> drugoplasirani = rank(group_A[1], group_B[1], group_C[1]);
        List<Team> treceplasirani = rank(group_A[2], group_B[2], group_C[2]);

        this.rankings = this.rankings.Concat(prvoplasirani).ToList();
        this.rankings = this.rankings.Concat(drugoplasirani).ToList();
        this.rankings = this.rankings.Concat(treceplasirani).ToList();

        this.rankings.RemoveAt(this.rankings.Count - 1);

    }


}


