import { useEffect } from "react";
// import GameCard from "./components/GameCard";
import MyGameCard from "./components/myGameCard";
import "./css/HomePage.css";
import NavBar from "./components/NavBar";
import { useGameContext } from "./GameContext";

const HomePage = () => {
  const { myGames, setMyGames } = useGameContext();

  const handleRemoveFromMyGames = (selectedGame) => {
    const updatedMesJeux = myGames.filter((myGame) => myGame !== selectedGame);
    setMyGames(updatedMesJeux);
  };

  useEffect(() => {
    fetch("/api/games")
      .then((response) => response.json())
      .then((data) => setGames(data))
      .catch((error) =>
        console.error("Erreur lors de la recuperation des jeux :", error)
      );
  }, []);

  return (
    <div>
      <NavBar />
      <h2>Mes jeux</h2>
      <div className="card-container">
        {myGames.map((selectedGame) => (
          <MyGameCard
            key={selectedGame.gameId}
            game={selectedGame}
            removeToMyGames={handleRemoveFromMyGames}
          />
        ))}
      </div>
    </div>
  );
};

export default HomePage;
