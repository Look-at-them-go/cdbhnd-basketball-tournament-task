using static GameHistory;
class Team {

    public string name {get; set; }
    public string iso_code {get; set; }
    public int fiba_ranking {get; set; }

    public int fiba_difference {get; set; }

    public int bodovi {get; set; }

    public int forma {get; set; }

    private GameHistory history {get; set;}

    public Team(string _name, string _iso_code, int _fiba_ranking, GameHistory _history){
        this.name = _name;
        this.iso_code = _iso_code;  
        this.fiba_ranking = _fiba_ranking;
        this.fiba_difference = 0;
        this.bodovi = 0;
        this.history = _history;
        this.forma = 0;
    }


    public void calculate_form(){
        Game last_game = history.get_recent_game(this);
        int modifier = 0;

        if(last_game.winner == this.name){
            if(last_game.kos_razlika > 8){
                modifier++;
            }
            modifier++;
        } else {
            if(last_game.kos_razlika > 8){
                modifier--;
            }
            modifier--;
        }

        if(last_game.team1 == this.name && last_game.team1_broj_koseva > 30){
            modifier += 3;
        } else if (last_game.team2_broj_koseva > 30) {
            modifier += 3;
        }
        this.forma = modifier;
    }

}