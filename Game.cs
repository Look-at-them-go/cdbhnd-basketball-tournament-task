public record Game{

    public string team1 {get; init;}
    public string team2 {get; init;}
    public string winner {get; init;}
    public string loser {get; init;}
    public int team1_points {get; init;}
    public int team2_points {get; init;}
    public int team1_broj_koseva  {get; init;}
    public int team2_broj_koseva {get; init;}
    public int kos_razlika {get; init;}

    public bool surrender {get; init;}

    public Game(string _team1, 
                string _team2, 
                string _winner, 
                string _loser, 
                int _team1_points, 
                int _team2_points,
                int _team1_broj_koseva,
                int _team2_broj_koseva,
                int _kos_razlika,
                bool _surrender)
    {
        this.team1 = _team1;
        this.team2 = _team2;
        this.winner = _winner;
        this.loser = _loser;
        this.team1_points = _team1_points;
        this.team2_points = _team2_points;
        this.team1_broj_koseva = _team1_broj_koseva;
        this.team2_broj_koseva = _team2_broj_koseva;
        this.kos_razlika = _kos_razlika;
        this.surrender = _surrender;
    }
    

}