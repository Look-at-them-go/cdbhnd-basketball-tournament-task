using static Team;
using static Game;

class Simulation{

    public static Game game_simulation(Team team1, Team team2){
        Random rand = new Random();

        if (team1.fiba_ranking > team2.fiba_ranking){
            team1.fiba_difference = (team1.fiba_ranking - team2.fiba_ranking) * (-1);
            team2.fiba_difference = team1.fiba_ranking - team2.fiba_ranking;
        } else {
            team1.fiba_difference = team2.fiba_ranking - team1.fiba_ranking;
            team2.fiba_difference = (team2.fiba_ranking - team1.fiba_ranking) * (-1);
        }

        team1.calculate_form();
        team2.calculate_form();

        int team1_score = 0;
        int team1_broj_koseva = 0;

        int team2_score = 0;
        int team2_broj_koseva = 0;
        
        bool surrender = false;
        string winner;
        string loser;
        int kos_razlika;

        for (int i = 0; i < 48; i++){

            if(team1_score - team2_score > 25){
                kos_razlika = Math.Abs(team1_broj_koseva-team2_broj_koseva);
                winner = team1.name;
                loser = team2.name;
                surrender = true;
                Console.WriteLine("        " + team1.name + " - " + team2.name + " (" + team1_score + ":" + team2_score + ")\n");
                return new Game(team1.name,team2.name,winner,loser,team1_score,team2_score,team1_broj_koseva,team2_broj_koseva,kos_razlika,surrender);
            } else if(team2_score - team1_score > 25){
                kos_razlika = Math.Abs(team1_broj_koseva-team2_broj_koseva);
                winner = team2.name;
                loser = team1.name;
                surrender = true;
                Console.WriteLine("        " + team1.name + " - " + team2.name + " (" + team1_score + ":" + team2_score + ")\n");
                return new Game(team1.name,team2.name,winner,loser,team1_score,team2_score,team1_broj_koseva,team2_broj_koseva,kos_razlika,surrender);
            }


            int team1_roll = rand.Next(0, 100) + team1.forma + team1.fiba_difference;
            int team2_roll = rand.Next(0, 100) + team2.forma;

            if (team1_roll >= 65){
                team1_score += 3;
                team1_broj_koseva++;
            } else if(team1_roll >= 30){
                team1_score += 2;
                team1_broj_koseva++;
            }

            if (team2_roll >= 65){
                team2_score += 3;
                team2_broj_koseva++;
            } else if(team2_roll >= 30){
                team2_score += 2;
                team2_broj_koseva++;
            }
        }

        kos_razlika = Math.Abs(team1_broj_koseva-team2_broj_koseva);
        winner = team1_score > team2_score ? team1.name : team2.name;
        loser = team1_score > team2_score ? team2.name : team1.name;

        Console.WriteLine("        " + team1.name + " - " + team2.name + " (" + team1_score + ":" + team2_score + ")\n");


        return new Game(team1.name,team2.name,winner,loser,team1_score,team2_score,team1_broj_koseva,team2_broj_koseva,kos_razlika,surrender);  
    }

}
