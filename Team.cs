class Team {

    public string name {get; set; }
    public string iso_code {get; set; }
    public int fiba_ranking {get; set; }

    public int fiba_difference {get; set; }

    public int bodovi {get; set; }

    public Team(string _name, string _iso_code, int _fiba_ranking){
        this.name = _name;
        this.iso_code = _iso_code;  
        this.fiba_ranking = _fiba_ranking;
        this.fiba_difference = 0;
        this.bodovi = 0;
    }

}