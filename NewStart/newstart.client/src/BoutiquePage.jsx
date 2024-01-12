import NavBar from "./components/NavBar";
import { useEffect, useState } from "react";
import GameCard from "./components/GameCard";
import { useGameContext } from "./GameContext";

const BoutiquePage = () => {
  const [games, setGames] = useState([]);

  const { myGames, setMyGames } = useGameContext();

  const handleAddToMyGames = (selectedGame) => {
    const isGameAlreadyAdded = myGames.some((game) => game === selectedGame);

    if (!isGameAlreadyAdded) {
      setMyGames((prevGames) => [...prevGames, selectedGame]);
    }
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
      <h2>Bibliotech de jeux</h2>
      <div className="card-container">
        {games.map((game) => (
          <GameCard
            key={game.gameId}
            game={game}
            onAddToMyGames={handleAddToMyGames}
          />
        ))}
      </div>
    </div>
  );
};

export default BoutiquePage;
