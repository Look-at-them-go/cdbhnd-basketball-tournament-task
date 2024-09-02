using static Game;
class GameHistory{

    public List<Game> game_history {get; set;}

    public GameHistory(){
        game_history = new List<Game>();
    }


    public string match_winner(Team t1, Team t2){
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t1.name || game_history[i].team2 == t2.name ){
                return game_history[i].winner;
            }
        }

        return "No match was played";
    }

    public int get_point_difference(Team t1, Team t2){
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t1.name || game_history[i].team2 == t2.name){
                return Math.Abs(game_history[i].team1_points - game_history[i].team2_points) ;
            }
        }

        return 0;
    }

    public int get_kos_razlika(Team t){
        int kos_razlika = 0;
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t.name || game_history[i].team2 == t.name){
                if(game_history[i].winner == t.name){
                    kos_razlika += game_history[i].kos_razlika;
                } else {
                    kos_razlika -= game_history[i].kos_razlika;
                }
            }
        }

        return kos_razlika;
    }

    public int get_broj_koseva(Team t){
        int broj_koseva = 0;
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t.name){
                broj_koseva += game_history[i].team1_broj_koseva;
            }
            if(game_history[i].team2 == t.name){
                broj_koseva += game_history[i].team2_broj_koseva;
            }
        }

        return broj_koseva;
    }

    public int number_of_wins(Team t){
        int wins = 0;
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t.name || game_history[i].team2 == t.name){
                if(game_history[i].winner == t.name){
                    wins++;
                }
            }
        }
        return wins;
    }

    public int number_of_losses(Team t){
        int losses = 0;
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t.name || game_history[i].team2 == t.name){
                if(game_history[i].loser == t.name){
                    losses++;
                }
            }
        }
        return losses;
    }

    public int primljeni_kosevi(Team t){
        int primljeni_kosevi = 0;
        for(int i=0; i < game_history.Count; i++){
            if(game_history[i].team1 == t.name){
                primljeni_kosevi += game_history[i].team2_broj_koseva;
            }
            if(game_history[i].team2 == t.name){
                primljeni_kosevi += game_history[i].team1_broj_koseva;
            }
        }

        return primljeni_kosevi;
    }

    public Game get_recent_game(Team t){
        Game g;
        for(int i = game_history.Count - 1 ; i >= 0; i--){
            if(game_history[i].team1 == t.name || game_history[i].team2 == t.name){
                return g = game_history[i];
            }
        }
        return null;
    }

}