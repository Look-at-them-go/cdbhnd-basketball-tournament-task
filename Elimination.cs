using static Team;
using static GameHistory;

class Elimination{

    public List<Team> plasirani { get; set; }
    public GameHistory history { get; set; }

    public Elimination (List<Team> _plasirani, GameHistory _history){
        this.plasirani = _plasirani;
        this.history = _history;
    }

    private List<List<Team>> hat(){
        List<List<Team>> matchings = new List<List<Team>>();
        Random rand = new Random();

        Console.WriteLine("\n");
        Console.WriteLine("Sesiri:");
        Console.WriteLine("    Sesir D");
        Console.WriteLine("        " + plasirani[0].name);
        Console.WriteLine("        " + plasirani[1].name);
        Console.WriteLine("    Sesir E");
        Console.WriteLine("        " + plasirani[2].name);
        Console.WriteLine("        " + plasirani[3].name);
        Console.WriteLine("    Sesir F");
        Console.WriteLine("        " + plasirani[4].name);
        Console.WriteLine("        " + plasirani[5].name);
        Console.WriteLine("    Sesir G");
        Console.WriteLine("        " + plasirani[6].name);
        Console.WriteLine("        " + plasirani[7].name);
        Console.WriteLine("\n");

        int r = rand.Next(0,1);
        if(r == 0){
            if(history.match_winner(plasirani[0], plasirani[6]) == "No match was played"){
                matchings.Add(new List<Team> {plasirani[0], plasirani[6]});
                matchings.Add(new List<Team> {plasirani[1], plasirani[7]});
            } else {
                matchings.Add(new List<Team> {plasirani[0], plasirani[7]});
                matchings.Add(new List<Team> {plasirani[1], plasirani[6]});
            }
        } else if(r == 1){
            if(history.match_winner(plasirani[0], plasirani[7]) == "No match was played"){
                matchings.Add(new List<Team> {plasirani[0], plasirani[7]});
                matchings.Add(new List<Team> {plasirani[1], plasirani[6]});
            } else {
                matchings.Add(new List<Team> {plasirani[0], plasirani[6]});
                matchings.Add(new List<Team> {plasirani[1], plasirani[7]});
            }
        }
        r = rand.Next(0,1);
        if(r == 0){
            if(history.match_winner(plasirani[2], plasirani[4]) == "No match was played"){
                matchings.Add(new List<Team> {plasirani[2], plasirani[4]});
                matchings.Add(new List<Team> {plasirani[3], plasirani[5]});
            } else {
                matchings.Add(new List<Team> {plasirani[2], plasirani[5]});
                matchings.Add(new List<Team> {plasirani[3], plasirani[4]});
            }
        } else if(r == 1){
            if(history.match_winner(plasirani[2], plasirani[5]) == "No match was played"){
                matchings.Add(new List<Team> {plasirani[2], plasirani[5]});
                matchings.Add(new List<Team> {plasirani[3], plasirani[4]});
            } else {
                matchings.Add(new List<Team> {plasirani[2], plasirani[4]});
                matchings.Add(new List<Team> {plasirani[3], plasirani[5]});
            }
        }

        Console.WriteLine("-----------------------------------------------\n");

        Console.WriteLine("Eliminaciona faza: ");
        for(int i = 0; i < matchings.Count; i++){
            Console.WriteLine("    " + matchings[i][0].name + " - " + matchings[i][1].name);
        }
        Console.WriteLine("\n-----------------------------------------------\n");

        return matchings;
    }


    public void play_elimination(){
        List<List<Team>> matchings = hat();
        List<List<Team>> polufinale = new List<List<Team>>();
        List<Team> finale = new List<Team>();
        List<Team> medalje = new List<Team>();

        Console.WriteLine("Cetvrtfinale:\n");

        history.game_history.Add(Simulation.game_simulation(matchings[0][0],matchings[0][1]));

        if(history.game_history[^1].winner == matchings[0][0].name){
            polufinale.Add(new List<Team> {matchings[0][0]});
        }else {
            polufinale.Add(new List<Team> {matchings[0][1]});
        }

        history.game_history.Add(Simulation.game_simulation(matchings[1][0],matchings[1][1]));

        if(history.game_history[^1].winner == matchings[1][0].name){
            polufinale[0].Add(matchings[1][0]);
        }else {
            polufinale[0].Add(matchings[1][1]);
        }

        history.game_history.Add(Simulation.game_simulation(matchings[2][0],matchings[2][1]));

        if(history.game_history[^1].winner == matchings[2][0].name){
            polufinale.Add(new List<Team> {matchings[2][0]});
        }else {
            polufinale.Add(new List<Team> {matchings[2][1]});
        }

        history.game_history.Add(Simulation.game_simulation(matchings[3][0],matchings[3][1]));

        if(history.game_history[^1].winner == matchings[3][0].name){
            polufinale[1].Add(matchings[3][0]);
        }else {
            polufinale[1].Add(matchings[3][1]);
        }

        Console.WriteLine("\nPolufinale\n");

        Team t1_trece_mesto;
        Team t2_trece_mesto;


        history.game_history.Add(Simulation.game_simulation(polufinale[0][0],polufinale[0][1]));

        if(history.game_history[^1].winner == polufinale[0][0].name){
            finale.Add(polufinale[0][0]);
            t1_trece_mesto = polufinale[0][1];
        }else {
            finale.Add(polufinale[0][1]);
            t1_trece_mesto = polufinale[0][0];
        }

        history.game_history.Add(Simulation.game_simulation(polufinale[1][0],polufinale[1][1]));

        if(history.game_history[^1].winner == polufinale[1][0].name){
            finale.Add(polufinale[1][0]);
            t2_trece_mesto = polufinale[1][1];
        }else {
            finale.Add(polufinale[1][1]);
            t2_trece_mesto = polufinale[1][0];
        }

        Console.WriteLine("\nUtakmica za trece mesto:\n");

        history.game_history.Add(Simulation.game_simulation(t1_trece_mesto,t2_trece_mesto));

        if(history.game_history[^1].winner == t1_trece_mesto.name){
            medalje.Add(t1_trece_mesto);
        } else {
            medalje.Add(t2_trece_mesto);
        }

        Console.WriteLine("\nFinale\n");


        history.game_history.Add(Simulation.game_simulation(finale[0],finale[1]));

        if(history.game_history[^1].winner == finale[0].name){
            medalje.Add(finale[1]);
            medalje.Add(finale[0]);
        } else {
            medalje.Add(finale[0]);
            medalje.Add(finale[1]);
        }


        Console.WriteLine("Medalje: ");
        for(int i = 0; i < medalje.Count; i++){
            Console.WriteLine("    " + (i+1) + ". " + medalje[2-i].name);
        }

    }

}