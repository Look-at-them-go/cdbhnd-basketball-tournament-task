using static Game;
class GameHistory{

    public List<Game> game_history {get; set;}

    public GameHistory(){
        game_history = new List<Game>();
    }


    public string match_winner(Team t1, Team t2){
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t1.name){
                if(game_history[i].team2 == t2.name){
                    return game_history[i].winner;
                }
            }
        }

        return "No match was played";
    }

    public int get_point_difference(Team t1, Team t2){
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t1.name){
                if(game_history[i].team2 == t2.name){
                    return Math.Abs(game_history[i].team1_points - game_history[i].team2_points) ;
                }
            }
        }

        return 0;
    }

}